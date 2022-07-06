using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sirenix.OdinInspector;


namespace LevelBluePrintUtil {
    [Serializable]
    public class TaskTriggerConditionData
{
        public enum CompleteCondition 
        { 
            [LabelText("1.���ǰ������")]
            relate_task,
            [LabelText("2.�����ض��ȼ�")]
            reach_level,
            [LabelText("3.��������")]
            unlock_cloud,
            [LabelText("4.��һ�ν���ĳ����ͼ")]
            first_enter_map,
            [LabelText("5.����ĳ�ξ���")]
            finish_scenario
        }

    
    [BoxGroup]
    [LabelText("��������ID")]
    [BoxGroup]
    public int id;

    [LabelText("��������")]
    [BoxGroup]
    public CompleteCondition key;
    
    [LabelText("������������ID")]
    [BoxGroup]
    public string obj_id;

}

}