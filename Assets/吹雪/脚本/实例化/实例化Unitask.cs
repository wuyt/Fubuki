using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;

namespace 吹雪
{
    public class 实例化Unitask : 基础Unitask
    {
        public 实例化信息SO _实例化信息;

        public override async UniTask 执行(UniTaskCompletionSource utcs)
        {
            await 实例化管理器.实例.异步实例化(_实例化信息);
            await 结束(utcs);
        }
    }
}
