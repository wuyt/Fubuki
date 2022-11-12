using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;
using Sirenix.OdinInspector;

namespace 吹雪
{
    [Serializable]
    public class 根子名称
    {
        [Required("根对象名称不可以为空")]
        public string _根对象名称;
        [Required("子对象名称不可以为空")]
        public string _子对象名称;
    }
}
