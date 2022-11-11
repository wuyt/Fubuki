using Cysharp.Threading.Tasks;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.UI;

namespace 吹雪
{
    public class 启动加载 : MonoBehaviour
    {
        public string _场景名称;
        public Slider _进度条;
        public TMP_Text _百分数;
        private AsyncOperationHandle<SceneInstance> _场景;
        private async void Start()
        {
            var _进度 = Progress.Create<float>(显示进度);
            _场景 = Addressables.LoadSceneAsync(_场景名称);
            if (_场景.OperationException != null) Debug.LogError(string.Format("启动时未在资源文件中找到场景=>{0}", _场景名称));
            try
            {
                Debug.Log(("启动应用"));
                await _场景.ToUniTask(progress: _进度);
            }
            catch (Exception ex)
            {
                Debug.LogError(string.Format("启动加载场景资源出错=>{0}", ex));
            }
        }

        private void 显示进度(float value)
        {
            _进度条.value = _场景.GetDownloadStatus().Percent;
            _百分数.text = _场景.GetDownloadStatus().Percent.ToString("P2");
        }
    }
}

