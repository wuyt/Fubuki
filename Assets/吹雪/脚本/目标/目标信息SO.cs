using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
namespace 吹雪
{
    [CreateAssetMenu(menuName = "吹雪/目标信息")]
    public class 目标信息SO : 基础SO
    {
        [OnValueChanged("重置")]
        public 目标类型 _目标类型 = 目标类型.选择场景对象;

        [ShowIf("_目标类型", 目标类型.选择场景对象)]
        [OnValueChanged("生成完整路径")]
        public List<GameObject> _场景目标;

        [ShowIf("@this._目标类型==目标类型.选择场景对象 || this._目标类型==目标类型.对象完整路径")]
        public List<string> _完整路径;

        [ShowIf("_目标类型", 目标类型.根子对象名称)]
        public List<根子名称> _根子名称;

        public 选择类型 _选择类型;

        [ShowIf("_选择类型", 选择类型.对象下对应标签)]
        public List<string> _标签;

        public List<GameObject> 获取对象()
        {
            return 公共函数.根据目标获取游戏对象(this);
        }

        #region 只影响编辑器

        [ShowIf("_目标类型", 目标类型.选择场景对象)]
        [Button]
        private void 生成完整路径()
        {
            if (_场景目标.Count == 0) return;
            _完整路径 = new List<string>();

            foreach (var _项目 in _场景目标)
            {
                if (_项目) _完整路径.Add(公共函数.获取完整路径(_项目));
            }
        }

        private void 重置()
        {
            _完整路径 = null;
            _根子名称 = null;
            _场景目标 = null;
        }
        #endregion
    }
}
