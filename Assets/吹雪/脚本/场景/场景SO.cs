using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;

namespace 吹雪
{
    [CreateAssetMenu(menuName = "吹雪/场景")]
    public class 场景SO : 基础SO
    {
        [Tooltip("场景名称需要和场景文件名以及addressable里的名称对应上。")]
        public string _场景名称;

        [Tooltip("该列表中的预制件会在场景加载的时候一同加载。")]
        public List<实例化信息SO> _实例化信息;
    }
}
