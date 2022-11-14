using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using System;

namespace 吹雪
{
    public class 基础Unitask : MonoBehaviour
    {
        [Tooltip("为空则不继续")]
        public 基础Unitask _下一个;

        public async UniTask 启动()
        {
            await 执行(new UniTaskCompletionSource());
        }

        public virtual async UniTask 执行(UniTaskCompletionSource utcs)
        {
            await 结束(utcs);
        }

        public async UniTask 结束(UniTaskCompletionSource utcs)
        {
            if (_下一个 == null)
            {
                utcs.TrySetResult();
                GC.Collect();
            }
            else
            {
                if (utcs.Task.Status == UniTaskStatus.Pending) await _下一个.执行(utcs);
            }
        }

        public virtual async UniTask 脚本反馈()
        {
            await UniTask.Yield();
        }
    }
}
