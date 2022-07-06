using Sirenix.OdinInspector;

namespace LevelBluePrintUtil
{ 
    public enum ScenarioTrigger 
    {
        
        NONE,
        [LabelText("1.�����Ʋ� (����ID)")]
        CLOUD_UNLOCK,

        [LabelText("2.������� (����ID)")]
        TASK_COMPLETE,

        [LabelText("3.�״ν����ͼ (��ͼID)")]
        MAP_FIRST_ENTRY,

        [LabelText("4.����ˮ����")]
        CRISTAL_UNLOCK,

        [LabelText("5.�ﵽ�ȼ� (��ֵ��")]
        LEVEL_REACH,

        [LabelText("6.��ȡ������ (����ID)")]
        TASK_REWARD_RECEIVE,

        [LabelText("7.ͨ��flag (flagID)")]
        FLAG_UNLOCK,

        [LabelText("8.ת���� (����ID)")]
        PILLAR_TURN,
        [LabelText("9.������Ͻ��� (����ID)")]
        BUIDLING_UPGRAGE,
        [LabelText("10.����block (blockID)")]
        BLOCK_REMOVE

    }

}