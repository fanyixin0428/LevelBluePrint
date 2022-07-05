using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace LevelBluePrintUtil
{
    [Serializable]
    public class TaskProperty 
    {
        [LabelText("�������")]
        public string taskComment;

        [LabelText("�ϲ���ǩ")]
        [ValueDropdown("MergeTag")]
        public string mergeTag;
        public static List<string> MergeTag = new List<string>() {"�޸�","����","�޸�-���ϲ�","����-���ϲ�","MASTER"};

        [LabelText("csgen")]
        public string csgen;

        [LabelText("ΨһID")]
        public int id;

        [LabelText("����ID")]
        public int taskId;

        [LabelText("������ͼ")]
        public int relateMapId;

        [LabelText("������ʾ˳��")]
        public int taskOrder;

        [LabelText("��������")]
        [ValueDropdown("TaskType")]
        public string taskType;
        public static List<string> TaskType = new List<string>() { "home_story", "side_story", "event_story", "main_story" };
        
        [PropertySpace]
        [LabelText("���ػ�������")]
        public string lcName;
        
        [LabelText("���ػ���������")]
        public string lcDetail;
        [LabelText("�������")]
        public TaskEntry entry;

        [LabelText("���񷢲���ɫ")]//TODO:��ոĳ�enum
        public int issuer;
        
        [PropertySpace]
        [LabelText("������������")]
        public string triggerConditionDescription;
        
        [LabelText("������������")]
        public string startCondition;

        [PropertySpace]
        [LabelText("������������")]
        public string taskTargetDescription;
        [LabelText("������������")]
        public string taskTarget;
        [PropertySpace]
        [LabelText("GOTO����")]
        public string gotoDescription;
        [LabelText("GOTO����")]
        public string gotoCompass;
        [LabelText("�Ƿ�GOTOǰ������")]
        public bool isCompletePerTask;
        [PropertySpace]
        [LabelText("�����������")]
        public int targetNumber;
        [LabelText("���ػ���������")]
        public string targetLcDetail;
        [LabelText("ͼ������")]
        public string targetIconDescription;
        [LabelText("ͼ���ַ")]
        public string targetIconAddress;
        [LabelText("ͼ����������")]
        public string targetIconType;
        [PropertySpace]
        [LabelText("������ע")]
        public string rewardDescription;
        [LabelText("��������")]
        public string reward;
        [PropertySpace]
        [LabelText("���񲻿ɼ�")]
        public bool isInvisible;
        [LabelText("������")]
        public string mapGroupInfo;
        [PropertySpace]
        [LabelText("��������")]
        public string giftBuilding;
        [LabelText("��������ͼ��")]
        public string giftBuildingIcon;

    }

}
