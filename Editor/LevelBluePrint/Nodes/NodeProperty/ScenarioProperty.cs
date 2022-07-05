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
        [PropertyTooltip("��������������ɶ����")]
        [LabelText("�������")]
        public string comment;

        [PropertyTooltip("������")]
        [LabelText("�ϲ���ǩ")]
        [ValueDropdown("MergeTag")]
        public string mergeTag;
        public static List<string> MergeTag = new List<string>() {"�޸�","����","�޸�-���ϲ�","����-���ϲ�","MASTER"};

        [PropertyTooltip("����Ψһid")]
        [LabelText("����id")]
        public int scenarioId;

        [PropertyTooltip("�������ڹؿ���id\n-99999 ��ʾ��������")]
        [LabelText("�������ڵ�ͼid")]
        public int mapId;

        [PropertyTooltip("����ű�����Ӧ��Ψһid��0102��ʾ��һ�صĵڶ������顣 \n" +
            "��������xxyy\n" +
            "����xx�����xx���ؿ�������λ���ǲ�һ���ġ�\n" +
            "(��Ϊ���ǵĹؿ��������ܳ���һ��)\n" +
            "yy���ǹ̶���λ����ʾ���ڹؿ��ĵڼ������顣\n" +
            "һ��һ���ؿ����ᳬ��99�����飬���Կ��Թ̶�����")]
        [LabelText("lua�ű��ļ���")]
        public string luaFile;
        
        [PropertyTooltip("��ʾ����ű��Ĵ�����ʽ��\n" +
            "1�������Ʋ㴥��\n" +
            "2��������񴥷�\n" +
            "3���״ν���ĳ����ͼ\n" +
            "4������ˮ����\n" +
            "5���ﵽĳ���ȼ�����\n" +
            "6����ȡ����������\n" +
            "7��ͨ��flag��������\n" +
            "8��ͨ��ת�����ӵ���Ϸ�����ľ��飬\n" +
            "9������block�����ľ��飬\n" +
            "10������������ɴ�������\n" +
            "���ӷ�����pillar_group��д��")]
        [LabelText("�ű�������ʽ")]
        public ScenarioTrigger triggerType;


        [PropertyTooltip("��ʾ�Ʋ����ڵĹؿ�id��\n" +
            "���ǽ����Ʋ㴥������-99999")]
        [LabelText("���������ͼid")]
        public int cloudMapId;

        [PropertySpace]

        [PropertyTooltip("��ʾ�������󶨵��Ʋ��id��������\n" +
            "���Ʋ㽫�ᴥ�����飬\n" +
            "û������ - 99999")]
        [LabelText("���������Ʋ�id")]
        public int cloudId;

        [PropertyTooltip("��ʾ�������󶨵�����id��\n" +
            "û������-99999��")]
        [LabelText("�������������id")]
        public int taskId;

        [PropertyTooltip("��ʾ�������󶨵�������Ľ׶������id")]
        [LabelText("�������������׶�id")]
        public int taskStage;

        [PropertyTooltip("�����״ν���ĳ���ؿ��������飬\n" +
            "��д�ؿ�id��û����-999999")]
        [LabelText("���������״ν���ؿ�id")]
        public int mapFirstEntryId;

        [PropertyTooltip("��ʾ���ĳһ�ȼ��󣬾��鴥����\nû������-999999")]
        [LabelText("��������ȼ�")]
        public int levelReach;
        
        [PropertySpace]

        [PropertyTooltip("[{\"blockId\" : \"banana\", \"state\" : 1}] \n\n" +
            "blockId��stateΪ�̶�ֵ\n" +
            "banana��Scenario Block Id\n" +
            "0������������block����\n" +
            "1������������block��ʾ\n\n" +
            "eg.[{\"block_scenario_id\":\"bananabridge\" , \"state\":1}]")]
        [LabelText("����block��json����")]
        public string blockInvisible;

        [PropertyTooltip("cloud_id Ҫ�������Ƶ�id\n" +
            "eg.[{\"cloud_id\":1}]")]
        [LabelText("��������json����")]
        public string cloudUnlockJsonArray;

        [PropertyTooltip("id ���ߵ�id��amout Ϊ����ʾ�ӣ�amoutΪ������ʾ��" +
            "eg.[{\"id\":1111, \"amout\":1}]")]
        [LabelText("����json����")]
        public string item;

        [PropertySpace]

        [PropertyTooltip("���������flagID")]
        [LabelText("��������flag")]
        public int triggerFlag;

        [PropertyTooltip("��ת���ӽ����ľ��飬��ص�����ID")]
        [LabelText("������������Id")]
        public int pillarGroup;

        [PropertyTooltip("ͨ������ĳ��block�������飨��blockʵ��id��\n" +
            "* ע�� * �ý�����ʽ�������A_INT_cloud_map_id ʹ�ã�\n" +
            "����block��Ӧ�ĵ�ͼid")]
        [LabelText("��������BlockId")]
        public int mapBlock;

        [PropertyTooltip("ͨ���������ĳ�������������飨���ʵ��id��\n" +
            "* ע�� * �ý�����ʽ�������A_INT_cloud_map_id ʹ�ã�\n" +
            "����building��Ӧ�ĵ�ͼid")]
        [LabelText("��������BuildingId")]
        public int buildingId;
    }

}
