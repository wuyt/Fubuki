using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;

namespace 吹雪
{
    [CreateAssetMenu(menuName = ("吹雪/实例化信息"))]
    public class 实例化信息SO : 基础SO
    {
        public List<实例化信息> _实例化信息;
    }
}
