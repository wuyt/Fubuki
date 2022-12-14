using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;

namespace 吹雪
{
    [CreateAssetMenu(menuName = "吹雪/项目路径")]
    public class 项目路径SO : 基础SO
    {
        public 游戏配置SO _游戏配置;
        [FolderPath]
        public string _目标对象路径;
        [FolderPath]
        public string _实例化对象路径;
        [FolderPath]
        public string _场景对象路径;
    }
}
