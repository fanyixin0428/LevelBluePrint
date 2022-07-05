using System;
using System.Collections.Generic;
using LevelBluePrintUtil.Hidden;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using XNode;
using XNodeEditor;

namespace LevelBluePrintUtil
{
	[CreateNodeMenu(menuName:"关卡蓝图/任务节点"),Title("任务节点")]
	[NodeTitle("任务")]
	[NodeWidthAttribute(280)]
	public class TaskNode : PhotonfoxNode
	{
		[ReadOnly]
		public int id;
		/// <summary>
		/// 可能不是必须的一些属性
		/// </summary>
		[LabelText("基本属性")] public BasicProperty basic;
		[FoldoutGroup("剧情表属性"), HideLabel, LabelWidth(140)] public TaskProperty property;
		
		[Button("初始化数值",ButtonSizes.Medium)]
		private void InitializationProperty()
		{
			property.mergeTag = "新增";
			property.csgen = "[\"default\"]";
			property.id = 0;
			property.taskId = 0;
			property.relateMapId = 0;
			property.taskOrder = 0;
			property.taskType = "event_story";

			property.entry = TaskEntry.COMMON;
			property.mapGroupInfo = "{}";
			property.targetIconType = "[]";
			property.giftBuilding = "[]";
			property.giftBuildingIcon = "[]";



		}

		



			
		
		// Use this for initialization
		protected override void Init()
		{
			base.Init();

		}

		// Return the correct value of an output port when requested
		public override object GetValue(NodePort port)
		{
			return null; // Replace this
		}
	}

}
