using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace LevelBluePrintUtil
{
    [Serializable]
    public class ScenarioProperty 
    {
        [PropertyTooltip("简述这条配置是啥剧情")]
        [LabelText("剧情简述")]
        public string comment;

        [PropertyTooltip("不解释")]
        [LabelText("合并标签")]
        [ValueDropdown("MergeTag")]
        public string mergeTag;
        public static List<string> MergeTag = new List<string>() {"修改","新增","修改-待合并","新增-待合并","MASTER"};

        [PropertyTooltip("剧情唯一id")]
        [LabelText("剧情id")]
        public int scenarioId;

        [PropertyTooltip("剧情所在关卡的id\n-99999 表示不用它。")]
        [LabelText("剧情所在地图id")]
        public int mapId;

        [PropertyTooltip("剧情脚本所对应的唯一id，0102表示第一关的第二个剧情。 \n" +
            "命名规则：xxyy\n" +
            "其中xx代表第xx个关卡，它的位数是不一定的。\n" +
            "(因为我们的关卡数量可能超过一百)\n" +
            "yy则是固定两位，表示所在关卡的第几个剧情。\n" +
            "一般一个关卡不会超过99个剧情，所以可以固定下来")]
        [LabelText("lua脚本文件名")]
        public string luaFile;
        
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
        [LabelText("脚本触发方式")]
        public ScenarioTrigger triggerType;


        [PropertyTooltip("表示云层所在的关卡id，\n" +
            "不是解锁云层触发则填-99999")]
        [LabelText("触发剧情地图id")]
        public int cloudMapId;

        [PropertySpace]

        [PropertyTooltip("表示剧情所绑定的云层的id，消除这\n" +
            "个云层将会触发剧情，\n" +
            "没有则填 - 99999")]
        [LabelText("触发剧情云层id")]
        public int cloudId;

        [PropertyTooltip("表示剧情所绑定的任务id，\n" +
            "没有则填-99999。")]
        [LabelText("触发剧情的任务id")]
        public int taskId;

        [PropertyTooltip("表示剧情所绑定的任务里的阶段任务的id")]
        [LabelText("触发剧情的任务阶段id")]
        public int taskStage;

        [PropertyTooltip("用于首次进入某个关卡触发剧情，\n" +
            "填写关卡id，没有则-999999")]
        [LabelText("触发剧情首次进入关卡id")]
        public int mapFirstEntryId;

        [PropertyTooltip("表示达成某一等级后，剧情触发，\n没有则填-999999")]
        [LabelText("触发剧情等级")]
        public int levelReach;
        
        [PropertySpace]

        [PropertyTooltip("[{\"blockId\" : \"banana\", \"state\" : 1}] \n\n" +
            "blockId和state为固定值\n" +
            "banana填Scenario Block Id\n" +
            "0代表剧情结束后block隐藏\n" +
            "1代表剧情结束后block显示\n\n" +
            "eg.[{\"block_scenario_id\":\"bananabridge\" , \"state\":1}]")]
        [LabelText("隐藏block的json数组")]
        public string blockInvisible;

        [PropertyTooltip("cloud_id 要解锁的云的id\n" +
            "eg.[{\"cloud_id\":1}]")]
        [LabelText("解锁的云json数组")]
        public string cloudUnlockJsonArray;

        [PropertyTooltip("id 道具的id，amout 为正表示加，amout为负数表示减" +
            "eg.[{\"id\":1111, \"amout\":1}]")]
        [LabelText("道具json数组")]
        public string item;

        [PropertySpace]

        [PropertyTooltip("触发剧情的flagID")]
        [LabelText("触发剧情flag")]
        public int triggerFlag;

        [PropertyTooltip("被转柱子解锁的剧情，相关的柱子ID")]
        [LabelText("触发剧情柱子Id")]
        public int pillarGroup;

        [PropertyTooltip("通过消除某个block触发剧情（填block实例id）\n" +
            "* 注意 * 该解锁方式必须搭配A_INT_cloud_map_id 使用，\n" +
            "填上block对应的地图id")]
        [LabelText("触发剧情BlockId")]
        public int mapBlock;

        [PropertyTooltip("通过升级完毕某个建筑触发剧情（填建筑实例id）\n" +
            "* 注意 * 该解锁方式必须搭配A_INT_cloud_map_id 使用，\n" +
            "填上building对应的地图id")]
        [LabelText("触发剧情BuildingId")]
        public int buildingId;
    }

}
