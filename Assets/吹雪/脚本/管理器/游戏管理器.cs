using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;

namespace 吹雪
{
    public class 游戏管理器 : 单实例<游戏管理器>
    {
        public 游戏配置SO _游戏配置 = default;

        private void Start()
        {
            if (_游戏配置._默认场景 != null) 场景管理器.实例.异步加载场景(_游戏配置._默认场景).Forget();
        }
    }
}
