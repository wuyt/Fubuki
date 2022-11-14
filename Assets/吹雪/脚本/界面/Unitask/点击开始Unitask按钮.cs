using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine.UI;
namespace 吹雪
{
    public class 点击开始Unitask按钮 : 基础Unitask
    {
        public Button _要点击的按钮;

        private void Start()
        {
            if (_要点击的按钮)
            {
                _要点击的按钮.onClick.AddListener(() =>
                {
                    Debug.Log(string.Format("<color=fuchsia>按钮点击开始新动作</color>=> {0} | {1}", _要点击的按钮.name, Time.time));
                    启动().Forget();
                });
            }
            else
            {
                Debug.LogError("点击按钮开始动作时按钮为空");
            }
        }
    }
}
