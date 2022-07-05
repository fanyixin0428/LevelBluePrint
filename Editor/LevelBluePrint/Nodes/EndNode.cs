using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using XNode;

namespace LevelBluePrintUtil.Hidden {
	[NodeTintAttribute("#a60f21")]
	[NodeTitle("结束")]
	public class EndNode : PhotonfoxNode
	{
		// Use this for initialization
		
		public override int type 
		{
			get => (int)NodeType.END;
		}
	}
}