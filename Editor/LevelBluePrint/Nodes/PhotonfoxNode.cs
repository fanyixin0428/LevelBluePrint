using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Unity.Collections;
using UnityEngine;
using XNode;

namespace LevelBluePrintUtil.Hidden 
{
    public class PhotonfoxNode : Node
    {

        [Input(ShowBackingValue.Never, ConnectionType.Override), HideLabel] public Node pre;
        [Output, HideLabel] public Node next;

        /// <summary>
        /// 是否有输出数据
        /// </summary>
        public virtual bool OutputData
        {
            get => true;
        }

        /// <summary>
        /// 节点类型
        /// </summary>
        public virtual int type
        {
            get => -999;
        }

        // 存储 node count
        [HideInInspector]
        public int index;

        public bool NoInputLink()
        {
            var nextP = Ports.GetEnumerator();
            while (nextP.MoveNext())
            {
                if (nextP.Current.IsInput)
                {
                    return nextP.Current.Connection == null;
                }
            }

            return true;
        }

        public override object GetValue(NodePort port)
        {
            return null;
        }

        public virtual void Transform()
        {
        }

        // 获取上个链接节点
        public PhotonfoxNode GetLast()
        {
            var lstPort = Ports.Where(p => p.IsInput)?.First();
            if (lstPort != null && lstPort.ConnectionCount > 0)
                return (lstPort.GetConnections()?.First()?.node as PhotonfoxNode);
            return null;
        }

    }
}