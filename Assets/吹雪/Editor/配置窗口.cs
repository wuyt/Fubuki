using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using Sirenix.Utilities.Editor;
using Sirenix.Utilities;

namespace 吹雪
{
    public class 配置窗口 : OdinMenuEditorWindow
    {
        private 项目路径SO _项目路径;

        [MenuItem("吹雪/配置窗口")]
        private static void 打开窗口()
        {
            var window = GetWindow<配置窗口>();
            window.position = GUIHelper.GetEditorWindowRect().AlignCenter(800, 600);
        }

        protected override OdinMenuTree BuildMenuTree()
        {
            //添加菜单和首页
            OdinMenuTree _菜单 = new OdinMenuTree(supportsMultiSelect: false)
            {
                { "首页",this},
            };

            _菜单.Config.DrawSearchToolbar = true;

            //获取路径
            _项目路径 = (项目路径SO)AssetDatabase.LoadAssetAtPath("Assets/吹雪/配置/项目路径设置.asset", typeof(项目路径SO));

            if (_项目路径 != null)
            {
                _菜单.Add("项目路径设置", _项目路径);
                if (_项目路径._游戏配置 != null) _菜单.Add("基础配置", _项目路径._游戏配置);
            }

            return _菜单;
        }
    }
}
