using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine.UI;

namespace 吹雪
{
    [RequireComponent(typeof(Button))]
    public class 加载场景按钮 : MonoBehaviour
    {
        public 场景SO _场景;

        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(() => {
                场景管理器.实例.异步加载场景(_场景).Forget();
            });
        }
    }
}
