using Sirenix.OdinInspector;

namespace LevelBluePrintUtil
{ 
    public enum ScenarioTrigger 
    {
        
        NONE,
        [LabelText("1.解锁云层 (云区ID)")]
        CLOUD_UNLOCK,

        [LabelText("2.完成任务 (任务ID)")]
        TASK_COMPLETE,

        [LabelText("3.首次进入地图 (地图ID)")]
        MAP_FIRST_ENTRY,

        [LabelText("4.解锁水晶球")]
        CRISTAL_UNLOCK,

        [LabelText("5.达到等级 (数值）")]
        LEVEL_REACH,

        [LabelText("6.领取任务奖励 (任务ID)")]
        TASK_REWARD_RECEIVE,

        [LabelText("7.通过flag (flagID)")]
        FLAG_UNLOCK,

        [LabelText("8.转柱子 (柱子ID)")]
        PILLAR_TURN,
        [LabelText("9.升级完毕建筑 (建筑ID)")]
        BUIDLING_UPGRAGE,
        [LabelText("10.消除block (blockID)")]
        BLOCK_REMOVE

    }

}