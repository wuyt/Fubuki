using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;

namespace 吹雪
{
    [CreateAssetMenu(menuName = "吹雪/游戏配置")]
    public class 游戏配置SO : 基础SO
    {
        public 场景SO _默认场景;
    }
}
