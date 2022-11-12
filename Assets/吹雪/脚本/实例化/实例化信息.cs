using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using System;
using System.Linq;
namespace 吹雪
{
    [Serializable]
    public class 实例化信息
    {
        [FoldoutGroup("$_标题")]
        [HideInInspector]
        public string _标题;

        [FoldoutGroup("$_标题")]
        [OnValueChanged("设置标题")]
        [AssetsOnly]
        [Required("预制件不可以为空")]
        public List<GameObject> _预制件;

        [FoldoutGroup("$_标题")]
        public bool _直接实例化 = false;

        [FoldoutGroup("$_标题")]
        [HideIf("_直接实例化")]
        public List<目标信息SO> _目标信息;

        [FoldoutGroup("$_标题")]
        [HideIf("_直接实例化")]
        public bool _作为目标子对象 = true;

        private void 设置标题()
        {
            _标题 = _预制件.Count == 0 ? "预制件为空无法生成" : _预制件.First().name;
        }
    }
}
