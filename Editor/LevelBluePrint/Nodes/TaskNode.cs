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
	[CreateNodeMenu(menuName:"关卡蓝图/任务节点")]
	[NodeTitle("任务")]
	[NodeWidthAttribute(600)]
	public class TaskNode : PhotonfoxNode
	{


		[LabelText("任务简述")]
		public string Comment;

		public enum TriggerConditionEnum
		{
			[LabelText("1.完成前置任务")]
			relate_task,
			[LabelText("2.到达特定等级")]
			reach_level,
			[LabelText("3.解锁云区")]
			unlock_cloud,
			[LabelText("4.第一次进入某个地图")]
			first_enter_map,
			[LabelText("5.结束某段剧情")]
			finish_scenario
		}

		public enum CompleteConditionEnum
		{
			[LabelText("1.消除一个block实例")]
			ruin_block,
			[LabelText("2.消除一类block")]
			ruin_block_class,
			[LabelText("3.消除某种产出的block")]
			ruin_block_output,
			[LabelText("4.解锁云区")]
			unlock_cloud,
			[LabelText("5.获得建筑")]
			get_building,
			[LabelText("6.升级完毕建筑")]
			upgrade_building,
			[LabelText("7.升级完毕蛋糕塔建筑")]
			treasure_building_upgrade_finish,
			[LabelText("8.解锁某类建筑（消除田上的石头让田可用）")]
			unlock_building,
			[LabelText("9.拥有某建筑多少数量")]
			stock_building,
			[LabelText("10.放置某建筑")]
			put_building,
			[LabelText("11.完成一次精炼产出")]
			refine_building_product,
			[LabelText("12.修复产出型建筑")]
			repair_building,
			[LabelText("13.收起地图上treasure_building类的礼物")]
			finish_claim_gift_building,
			[LabelText("14.把蛋糕塔建筑转换成礼物塔")]
			change_gift_building,
			[LabelText("15.收藏系统 - 兑换成功n次")]
			exchange_times,
			[LabelText("16.获得物品")]
			get_item,
			[LabelText("17.结束某段剧情")]
			finish_scenario,
			[LabelText("18.种植")]
			plant,
			[LabelText("19.完成订单")]
			complete_order,
			[LabelText("20.第一次进入某个地图")]
			first_enter_map,
			[LabelText("21.第一次进入某个关卡")]
			first_enter_dungeon,
			[LabelText("22.进入某个关卡")]
			enter_dungeon,
			[LabelText("23.开始合成某个物品")]
			start_work_bench_product,
			[LabelText("24.社交系统 - 拜访其他巫师n次")]
			visit_players,
			[LabelText("25.给任意n个玩家点赞")]
			like_players,
			[LabelText("26.打开n个地图宝箱")]
			open_box,
			[LabelText("27.解锁任意n片云区")]
			unlock_any_cloud,
			[LabelText("28.小游戏累积合成n个橘猫")]
			compose_orange_cat,
			[LabelText("29.装满龙商人的货箱n次")]
			full_trader_box,
			[LabelText("30.升级一次蛋糕塔建筑（count为修复几次）")]
			treasure_building_upgrade,
			[LabelText("31.升级同一类building(building_type)")]
			building_type_upgrade,
			[LabelText("32.清理某类marathon_quest的block")]
			ruin_block_class2,
			[LabelText("33.使用某个gacha机")]
			play_gacha,
			[LabelText("34.获取隶属于某个组的treasure_building")]
			get_treasure_building_group,
			[LabelText("35.完成x次工具单")]
			complete_tool_list,
			[LabelText("36.使用x次某道具")]
			use_item,
			[LabelText("37.完成一次猫球游戏")]
			play_cat,
		}

		public enum GotoCompassEnum
        {
			[LabelText("1.消除一个block实例")] block_id,
			[LabelText("2.消除一类block")] block_class,
			[LabelText("3.消除某种产出的block")] block_output,
			[LabelText("4.建筑")] building,
			[LabelText("5.修建某个建筑")] building_upgrade,
			[LabelText("6.修建茶壶建筑")] building_repair,
			[LabelText("7.解锁建筑（消除田上的石头让田可用）")] building_unlock,
			[LabelText("8.市场建筑")] market_building,
			[LabelText("9.小精灵的饲料 - 用于摆放饲料")] feed,
			[LabelText("10.生产小精灵饲料")] produce_feed,
			[LabelText("11.坐标位置")] coordinate,
			[LabelText("12.获得物品")] item,
			[LabelText("13.指向某个关卡")] dungeon,
			[LabelText("14.文本提示")] text,
			[LabelText("15.建筑实例")] building_id,
			[LabelText("16.云区")] cloud,
			[LabelText("17.查找隶属于某一组的building")] building_group,
			[LabelText("18.查找隶属于某一种类型的building")] building_type,
			[LabelText("19.查找隶属于某一组的，需要升级的building")] building_upgrade_group,
			[LabelText("20.查找隶属于某一组的，需要修复的building")] building_repair_group,
			[LabelText("21.小精灵加速-指向小精灵打开小精灵气泡")] animal_speed_up,
			[LabelText("22.工具单goto")] order_tool
		}

        [PropertySpace]
		[LabelText("1.任务触发条件")]
		[TableList]
		public List<TaskTrigger> taskTriggerCondition = new List<TaskTrigger>();
		[Serializable]
		public class TaskTrigger
		{
			[TableColumnWidth(40, Resizable = false)]
			public int id;
			[TableColumnWidth(200, Resizable = false)]
			public TriggerConditionEnum key;
			
			public string obj_id;
		}



		[PropertySpace]
		[LabelText("2.完成条件")]
		[TableList]
		public List<CompleteComdition> taskCompleteComdition = new List<CompleteComdition>();
		[Serializable]
		public class CompleteComdition
		{
			[TableColumnWidth(40, Resizable = false)]
			public int index;
			[TableColumnWidth(40, Resizable = false)]
			public int id;
			[TableColumnWidth(200, Resizable = false)]
			public CompleteConditionEnum type;
			
			public int obj_id;
			
			public int count;
			
			public int mapid;
		}

		
		[FoldoutGroup("GOTO")]
		[LabelText("3.1 GOTO")]
		[TableList]
		public List<GotoCompass> gotoCompass = new List<GotoCompass>();
		[Serializable]
		public class GotoCompass
        {
			public GotoCompassEnum type;
			public int obj_id;
			public int map_id;
		}

		[FoldoutGroup("GOTO")]
		[LabelText("3.2 坐标位置GOTO")]
		[TableList]
		public List<CoordinateGoto> coordinateGoto = new List<CoordinateGoto>();
		[Serializable]
		public class CoordinateGoto
		{
			public int Xcoordinate;
			public int Ycoordinate;
			public int map_id;
		}

		[FoldoutGroup("GOTO")]
		[LabelText("3.3 关卡GOTO")]
		[TableList]
		public List<LevelGoto> levelGoto = new List<LevelGoto>();
		[Serializable]
		public class LevelGoto
		{
			public int map_id;
		}
		[FoldoutGroup("GOTO")]
		[LabelText("3.4 本地化GOTO")]
		[TableList]
		public List<LocalizationGoto> localizationGoto = new List<LocalizationGoto>();
		[Serializable]
		public class LocalizationGoto
		{
			public string text;
		}
		[FoldoutGroup("GOTO")]
		[LabelText("3.5 工具单GOTO")]
		[TableList]
		public List<OrderToolGoto> orderToolGoto = new List<OrderToolGoto>();
		[Serializable]
		public class OrderToolGoto
		{
			public int map_id;
		}





		/// <summary>
		/// 可能不是必须的一些属性
		/// </summary>
		[LabelText("基本属性")] public BasicProperty basic;
		[FoldoutGroup("任务表属性"), HideLabel, LabelWidth(140)] public TaskProperty property;
		
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
            if (port.fieldName == "next")
            {
				//next = GetInputValue<Node>("pre", pre);
				return this;
            }
			return null; // Replace this
		}
	}

}
