using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using System;

namespace 吹雪
{
    public class 等待X秒Unitask : 基础Unitask
    {
        public float _等待时长;

        public override async UniTask 执行(UniTaskCompletionSource utcs)
        {
            Debug.Log(string.Format("<color=fuchsia>开始等待</color>=>等待{0}秒", _等待时长));
            await UniTask.Delay(TimeSpan.FromSeconds(_等待时长), ignoreTimeScale: false);
            await 结束(utcs);
        }
    }
}
