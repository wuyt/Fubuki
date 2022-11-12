using Cysharp.Threading.Tasks;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.UI;

namespace 吹雪
{
    public class 场景管理器 : 单实例<场景管理器>
    {
        [SerializeField]
        private Slider _进度条;
        [SerializeField]
        private TMP_Text _百分比;
        [SerializeField]
        private Canvas _进度画布;

        private AsyncOperationHandle<SceneInstance> _场景;

        public UnityAction<场景SO> 事件开始加载场景;
        public UnityAction<场景SO> 事件完成场景加载;

        private string _当前场景 = "";

        private void Start()
        {
            _进度画布.gameObject.SetActive(false);
        }

        public async UniTask 异步加载场景(场景SO _场景SO)
        {
            if (_场景SO == null)
            {
                Debug.LogError("加载的场景脚本化对象为空");
                return;
            }

            if (_场景SO._场景名称.Length == 0)
            {
                Debug.LogError(string.Format("加载的场景脚本化对象中场景名称为空=>{0}", _场景SO.name));
                return;
            }

            //判断如果要加载的场景是当前场景则不继续
            if (_当前场景.Length > 0)
            {
                if (_当前场景.Equals(_场景SO.name))
                {
                    Debug.Log(string.Format("<color=red>当前场景已经加载</color>=>{0}", _场景SO.name));
                    return;
                }
            }

            var _进度 = Progress.Create<float>(显示进度);
            _场景 = Addressables.LoadSceneAsync(_场景SO._场景名称);

            if (_场景.OperationException != null)
            {
                Debug.LogError(string.Format("{0}=>{1}", "未在资源文件中找到场景", _场景SO._场景名称));
                return;
            }

            try
            {
                Debug.Log(string.Format("{0}=> {1} | {2}", "开始加载场景", _场景SO._场景名称, Time.time));
                事件开始加载场景?.Invoke(_场景SO);
                await _场景.ToUniTask(progress: _进度);
                _当前场景 = _场景SO.name;
                Debug.Log(string.Format("<color=orange>{0}</color>=> {1} | {2}", "场景加载完成", _场景SO._场景名称, Time.time));
                事件完成场景加载?.Invoke(_场景SO);
            }
            catch (Exception ex)
            {
                Debug.LogError(string.Format("{0}=> {1}", "加载场景资源出错", ex));
            }

            //实例化预制件
            if (_场景SO._实例化信息 != null)
            {
                if (_场景SO._实例化信息.Count > 0)
                {
                    foreach (var _项目 in _场景SO._实例化信息)
                    {
                        await 实例化管理器.实例.异步实例化(_项目);
                    }
                }
            }
        }

        private void 显示进度(float value)
        {
            _进度条.value = _场景.GetDownloadStatus().Percent;
            _百分比.text = _场景.GetDownloadStatus().Percent.ToString("P2");
        }
    }
}
