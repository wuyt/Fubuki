using UnityEngine;

namespace 吹雪
{
    public class 单实例<泛型> : MonoBehaviour where 泛型 : 单实例<泛型>
    {
        private static 泛型 _实例;
        public static 泛型 实例
        {
            get { return _实例; }
        }
        protected virtual void Awake()
        {
            if (_实例 != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _实例 = (泛型)this;
            }
            DontDestroyOnLoad(gameObject);
        }
        public static bool 已初始化
        {
            get { return _实例 != null; }
        }
        protected virtual void OnDestory()
        {
            if (_实例 == this)
            {
                _实例 = null;
            }
        }
    }
}
