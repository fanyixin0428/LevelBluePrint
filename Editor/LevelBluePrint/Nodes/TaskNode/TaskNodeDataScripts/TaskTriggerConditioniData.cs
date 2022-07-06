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

    
    [BoxGroup]
    [LabelText("触发条件ID")]
    [BoxGroup]
    public int id;

    [LabelText("触发条件")]
    [BoxGroup]
    public CompleteCondition key;
    
    [LabelText("触发条件对象ID")]
    [BoxGroup]
    public string obj_id;

}

}