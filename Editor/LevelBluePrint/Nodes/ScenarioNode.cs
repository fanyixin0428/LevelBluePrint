using System;
using System.Collections.Generic;
using LevelBluePrintUtil.Hidden;
using Sirenix.OdinInspector;
using System.IO;
using UnityEditor;
using UnityEngine;
using XNode;
using XNodeEditor;
using OfficeOpenXml;

namespace LevelBluePrintUtil
{
	[CreateNodeMenu(menuName: "关卡蓝图/剧情节点")]
	[NodeTitle("剧情")]
	[NodeTintAttribute("#1a6a9c"), NodeWidthAttribute(280)]
	public class ScenarioNode : PhotonfoxNode
	{
		[ReadOnly]
		public int id;

		[LabelText("剧情编号")]
		public int nodeScenarioIndex;
		[LabelText("剧情描述"), MultiLineProperty(2)]
		public string nodeScenarioBrief;
		[LabelText("大致剧情"), MultiLineProperty(5)]
		public string nodeMultTex;


		[PropertyTooltip("表示这个脚本的触发方式。\n" +
		"1：解锁云层触发\n" +
		"2：完成任务触发\n" +
		"3：首次进入某个地图\n" +
		"4：解锁水晶球\n" +
		"5：达到某个等级触发\n" +
		"6：领取任务奖励触发\n" +
		"7：通过flag解锁剧情\n" +
		"8：通过转动柱子的游戏触发的剧情，\n" +
		"9：消除block触发的剧情，\n" +
		"10：建筑升级完成触发剧情\n" +
		"柱子分组在pillar_group列写入")]
		[LabelText("选择触发条件")]
		public ScenarioTrigger scenarioTrigger;
		[LabelText("触发的值")]
		public string configContent;

		[LabelText("Lua脚本文件名")]
		public string luaFileName;

		[LabelText("备注免得忘了"), MultiLineProperty(2)]
		public string memoContent;

		[PropertySpace]
		[PropertyOrder(1),Button("点这个按钮填入配置", ButtonSizes.Medium)]
		public void InitTable()
		{
			Debug.LogWarning("触发条件没选");
            switch (scenarioTrigger)
            {
				case ScenarioTrigger.CLOUD_UNLOCK:
					ResetScenarioNodeTable();
					property.cloudMapId = property.mapId;
					property.cloudId = Int32.Parse(configContent);
					break;
				case ScenarioTrigger.TASK_COMPLETE:
					ResetScenarioNodeTable();
					property.taskId = Int32.Parse(configContent);

					break;
				case ScenarioTrigger.MAP_FIRST_ENTRY:
					ResetScenarioNodeTable();
					property.mapFirstEntryId = property.mapId;

					break;
				case ScenarioTrigger.CRISTAL_UNLOCK:
					ResetScenarioNodeTable();
					break;
				case ScenarioTrigger.LEVEL_REACH:
					ResetScenarioNodeTable();
					property.levelReach = Int32.Parse(configContent);
					break;
				case ScenarioTrigger.TASK_REWARD_RECEIVE:
					ResetScenarioNodeTable();
					property.taskId = Int32.Parse(configContent);
					break;
				case ScenarioTrigger.FLAG_UNLOCK:
					ResetScenarioNodeTable();
					property.triggerFlag = Int32.Parse(configContent);
					break;
				case ScenarioTrigger.PILLAR_TURN:
					ResetScenarioNodeTable();
					property.pillarGroup = Int32.Parse(configContent);
					break;
				case ScenarioTrigger.BUIDLING_UPGRAGE:
					ResetScenarioNodeTable();
					property.cloudMapId = property.mapId;
					property.buildingId = Int32.Parse(configContent);
					break;
				case ScenarioTrigger.BLOCK_REMOVE:
					ResetScenarioNodeTable();
					property.cloudMapId = property.mapId;
					property.mapBlock = Int32.Parse(configContent);
					break;
				default:
					break;
            }

        }


		/// <summary>
		/// 配置表的属性
		/// </summary>
		[PropertyOrder(2), FoldoutGroup("剧情表属性"), HideLabel, LabelWidth(140)] public ScenarioProperty property;


		public ScenarioNode() : base()
		{
			property = new ScenarioProperty();
			property.mergeTag = "新增";
			property.scenarioId = 0;
			property.mapId = 0;
			property.cloudMapId = -99999;
			property.cloudId = -99999;
			property.taskId = -99999;
			property.taskStage = -99999;
			property.mapFirstEntryId = -99999;
			property.levelReach = -99999;
			property.blockInvisible = "[]";
			property.cloudUnlockJsonArray = "[]";
			property.item = "[]";
			property.triggerFlag = -99999;
			property.pillarGroup = -99999;
			property.mapBlock = -99999;
			property.buildingId = -99999;
		}


        public void ResetScenarioNodeTable()
        {
			property.comment = nodeScenarioBrief;
			property.triggerType = scenarioTrigger;
			property.luaFile = luaFileName;
			property.cloudMapId = -99999;
			property.cloudId = -99999;
			property.taskId = -99999;
			property.taskStage = -99999;
			property.mapFirstEntryId = -99999;
			property.levelReach = -99999;
			property.blockInvisible = "[]";
			property.cloudUnlockJsonArray = "[]";
			property.item = "[]";
			property.triggerFlag = -99999;
			property.pillarGroup = -99999;
			property.mapBlock = -99999;
			property.buildingId = -99999;
		}


		[PropertyOrder(3), Button("导出这条配置", ButtonSizes.Medium)]
        public void OutputScenarioTable()
        {
			string filePath = "Assets/Editor/LevelBluePrint/Excel/" + nodeScenarioBrief + "Scenario_trigger" + DateTime.Now.ToString("HH-mm-ss--dd-MM-yyyy") + ".xlsx";

			//因为文件不存在，所以取不到Excel信息
			FileInfo fileInfo = new FileInfo(filePath);
			//通过Excel表格的文件信息打开Excel表格
			using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))//打开Excel表格
			{
				Debug.Log("excel打开了");
				//取得Excel文件中的第一张表
				ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

				int rowNum = 1;

				worksheet.Cells[rowNum, 1].Value = "comment";
				worksheet.Cells[rowNum, 2].Value = "标签";
				worksheet.Cells[rowNum, 3].Value = "A_INT_id";
				worksheet.Cells[rowNum, 4].Value = "A_INT_map_id";
				worksheet.Cells[rowNum, 5].Value = "C_STR_lua_file";
				worksheet.Cells[rowNum, 6].Value = "A_INT_type";
				worksheet.Cells[rowNum, 7].Value = "A_INT_cloud_map_id";
				worksheet.Cells[rowNum, 8].Value = "A_INT_cloud_id";
				worksheet.Cells[rowNum, 9].Value = "A_INT_quest_id";
				worksheet.Cells[rowNum, 10].Value = "A_INT_quest_stage";
				worksheet.Cells[rowNum, 11].Value = "A_INT_map_first_time_id";
				worksheet.Cells[rowNum, 12].Value = "A_INT_level";
				worksheet.Cells[rowNum, 13].Value = "A_ARR_block";
				worksheet.Cells[rowNum, 14].Value = "A_ARR_cloud";
				worksheet.Cells[rowNum, 15].Value = "A_ARR_item";
				worksheet.Cells[rowNum, 16].Value = "A_INT_trigger_flag";
				worksheet.Cells[rowNum, 17].Value = "A_INT_pillar_group";
				worksheet.Cells[rowNum, 18].Value = "A_ARR_map_block";
				worksheet.Cells[rowNum, 19].Value = "A_INT_building_upgrade";

						rowNum++;
						worksheet.Cells[rowNum, 1].Value = property.comment;
						worksheet.Cells[rowNum, 2].Value = property.mergeTag;
						worksheet.Cells[rowNum, 3].Value = property.scenarioId;
						worksheet.Cells[rowNum, 4].Value = property.mapId;
						worksheet.Cells[rowNum, 5].Value = property.luaFile;
						worksheet.Cells[rowNum, 6].Value = (int)property.triggerType;
						worksheet.Cells[rowNum, 7].Value = property.cloudMapId;
						worksheet.Cells[rowNum, 8].Value = property.cloudId;
						worksheet.Cells[rowNum, 9].Value = property.taskId;
						worksheet.Cells[rowNum, 10].Value = property.taskStage;
						worksheet.Cells[rowNum, 11].Value = property.mapFirstEntryId;
						worksheet.Cells[rowNum, 12].Value = property.levelReach;
						worksheet.Cells[rowNum, 13].Value = property.blockInvisible;
						worksheet.Cells[rowNum, 14].Value = property.cloudUnlockJsonArray;
						worksheet.Cells[rowNum, 15].Value = property.item;
						worksheet.Cells[rowNum, 16].Value = property.triggerFlag;
						worksheet.Cells[rowNum, 17].Value = property.pillarGroup;
						worksheet.Cells[rowNum, 18].Value = property.mapBlock;
						worksheet.Cells[rowNum, 19].Value = property.buildingId;

				excelPackage.Save();
				//取得表中第一行第一列中的数据

			}//关闭Excel表格
			Debug.Log("配置表导出成功！文件名：" + filePath);
		}
        // Use this for initialization
        protected override void Init()
		{
			base.Init();
		}

		public void GetPreNodeTriggerTaskId(TaskNode taskNode) 
		{
			scenarioTrigger = ScenarioTrigger.TASK_COMPLETE;
			configContent = Convert.ToString(taskNode.property.taskId);
			ResetScenarioNodeTable();
			property.taskId = taskNode.property.taskId;

		}
		
		//自动获取上一个任务节点的内容,并填入剧情节点
		public void testEntryTaskId()
        {
			this.pre = GetPreNode();

			if (pre is TaskNode)
			{
				TaskNode preTaskNode = pre as TaskNode;
				GetPreNodeTriggerTaskId(preTaskNode);

			}

		}

	// Return the correct value of an output port when requested
	public override object GetValue(NodePort port)
        {
            if (port.fieldName == "next")
            {
				Debug.Log("next");
				testEntryTaskId();
				return this;

			}

			return null; // Replace this
		}



	}
}
