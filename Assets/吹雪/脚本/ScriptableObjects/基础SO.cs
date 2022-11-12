using UnityEngine;

namespace 吹雪
{
    public class 基础SO : ScriptableObject
    {
        [Tooltip("该字段不参与运算逻辑，只是为了更好识别")]
        [TextArea]
        public string _资源描述;
    }
}
