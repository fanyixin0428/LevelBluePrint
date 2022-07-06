using System.Collections;
using System.Collections.Generic;
using LevelBluePrintUtil.Hidden;
using Sirenix.OdinInspector;
using UnityEngine;
using XNode;

namespace LevelBluePrintUtil {
	[CreateNodeMenu(menuName: "任务内容配置/任务触发条件")]
	[NodeTitle("任务触发条件")]
    [NodeWidthAttribute(350)]
	public class TaskTriggerConditionNode : PhotonfoxNode{

		[LabelText("触发条件"), LabelWidth(120)]
		[ShowInInspector]
		[InlineProperty]
		[ListDrawerSettings(ShowPaging = false, Expanded = true)]
		//[Output(backingValue = ShowBackingValue.Never,
		//connectionType = ConnectionType.Override,
		//dynamicPortList = true)]
		//[OnCollectionChanged(After = "OnDynamicPortListChange")]
		public List<TaskTriggerConditionData> options = new List<TaskTriggerConditionData>();
		// Use this for initialization
		protected override void Init() {
		base.Init();
		
	}

	// Return the correct value of an output port when requested
	public override object GetValue(NodePort port) {
		return null; // Replace this
	}
}
}