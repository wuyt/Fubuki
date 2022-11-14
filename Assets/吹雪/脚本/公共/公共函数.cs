using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;
using System.Linq;
using Unity.Linq;

namespace 吹雪
{
    public static class 公共函数
    {
        public static string 获取完整路径(GameObject _场景对象)
        {
            Transform _变换 = _场景对象.transform;
            string _路径 = _场景对象.name;
            while (_变换.parent != null)
            {
                _变换 = _变换.parent;
                _路径 = string.Format("{0}/{1}", _变换.name, _路径);
            }
            _路径 = String.Format("/{0}", _路径);
            return _路径;
        }

        public static List<GameObject> 根据目标获取游戏对象(目标信息SO _目标信息)
        {
            List<GameObject> _运行时目标 = new List<GameObject>();

            switch (_目标信息._目标类型)
            {
                case 目标类型.选择场景对象:
                    _运行时目标 = 根据完整路径获取游戏对象(_目标信息);
                    break;
                case 目标类型.对象完整路径:
                    _运行时目标 = 根据完整路径获取游戏对象(_目标信息);
                    break;
                case 目标类型.根子对象名称:
                    _运行时目标 = 根据根子名称获取游戏对象(_目标信息);
                    break;
            }

            return _运行时目标;
        }

        private static List<GameObject> 根据完整路径获取游戏对象(目标信息SO _目标信息)
        {
            List<GameObject> _运行时目标 = new List<GameObject>();

            foreach (var _路径 in _目标信息._完整路径)
            {
                GameObject _目标 = GameObject.Find(_路径);

                if (_目标 == null)
                {
                    Debug.LogError(string.Format("生成时完整路径错误=>{0}" + _路径));
                }
                else
                {
                    switch (_目标信息._选择类型)
                    {
                        case 选择类型.对象自身:
                            _运行时目标.Add(_目标);
                            break;
                        case 选择类型.所有子对象:
                            _运行时目标 = _运行时目标.Union(_目标.Children().ToList()).ToList();
                            break;
                        case 选择类型.对象下对应标签:
                            foreach (var tag in _目标信息._标签)
                            {
                                _运行时目标 = _运行时目标.Union(_目标.Descendants().Where(x => x.CompareTag(tag))).ToList();
                            }
                            break;
                    }
                }
            }

            return _运行时目标;
        }

        private static List<GameObject> 根据根子名称获取游戏对象(string _根名称, string _子名称)
        {
            //获取场景中的根节点
            GameObject[] _场景根对象 = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
            List<GameObject> _运行时目标 = new List<GameObject>();

            //如果根节点不存在返回false
            if (_场景根对象.Where(x => x.name.Equals(_根名称)).Count() == 0)
            {
                Debug.LogError(string.Format("场景中不存在根节点=>{0}" + _根名称));
                return _运行时目标;
            }
            var _根对象 = _场景根对象.Where(x => x.name.Equals(_根名称));

            foreach (var _项目 in _根对象)
            {
                if (_项目.Descendants().Where(x => x.name.Equals(_子名称)).Count() > 0)
                {
                    _运行时目标 = _运行时目标.Union(_项目.Descendants().Where(x => x.name.Equals(_子名称)).ToList()).ToList();
                }
            }

            return _运行时目标;
        }

        private static List<GameObject> 根据根子名称获取游戏对象(目标信息SO _目标信息)
        {
            List<GameObject> _运行时目标 = new List<GameObject>();
            foreach (var _项目 in _目标信息._根子名称)
            {
                List<GameObject> _目标对象 = 根据根子名称获取游戏对象(_项目._根对象名称, _项目._子对象名称);

                switch (_目标信息._选择类型)
                {
                    case 选择类型.对象自身:
                        _运行时目标 = _运行时目标.Union(_目标对象).ToList();
                        break;
                    case 选择类型.所有子对象:
                        foreach (var _对象 in _目标对象)
                        {
                            _运行时目标 = _运行时目标.Union(_对象.Children().ToList()).ToList();
                        }
                        break;
                    case 选择类型.对象下对应标签:
                        foreach (var _对象 in _目标对象)
                        {
                            foreach (var tag in _目标信息._标签)
                            {
                                _运行时目标 = _运行时目标.Union(_对象.Descendants().Where(x => x.CompareTag(tag))).ToList();
                            }
                        }
                        break;
                }
            }
            return _运行时目标;
        }
    }
}
