using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;

namespace 吹雪
{
    public class 实例化管理器 : 单实例<实例化管理器>
    {
        public async UniTask 异步实例化(实例化信息SO _实例化信息)
        {
            foreach (var _项目 in _实例化信息._实例化信息)//遍历生成列表
            {
                if (_项目._直接实例化)
                {
                    foreach (var _预制件 in _项目._预制件)
                    {
                        await 协程实例化(_预制件, null, false).ToUniTask(this);
                    }
                }
                else
                {
                    foreach (var _目标信息 in _项目._目标信息)//遍历目标列表
                    {
                        foreach (var _目标 in _目标信息.获取对象())//遍历目标列表中的游戏对象
                        {
                            foreach (var _预制件 in _项目._预制件)//遍历要生成的预制件
                            {
                                await 协程实例化(_预制件, _目标, _项目._作为目标子对象).ToUniTask(this);
                            }
                        }
                    }
                }
            }
        }

        private IEnumerator 协程实例化(GameObject _预制件, GameObject _父对象, bool _作为子对象)
        {
            if (_预制件 == null)
            {
                Debug.LogError("要实例化的预制件为空。");
                yield return null;
            }

            Debug.Log(string.Format("开始实例化=> {0} | {1}", _预制件.name, Time.time));

            GameObject _实例化 = null;
            if (_父对象 == null)
            {
                yield return _实例化 = Instantiate(_预制件);
            }
            else
            {
                if (_作为子对象)
                {
                    yield return _实例化 = Instantiate(_预制件, _父对象.transform);
                }
                else
                {
                    yield return _实例化 = Instantiate(_预制件, _父对象.transform.position, _父对象.transform.rotation);
                }
            }
            _实例化.name = _预制件.name;

            Debug.Log(string.Format("<color=orange>实例化完成</color>=> {0} | {1}", _预制件.name, Time.time));
        }
    }
}
