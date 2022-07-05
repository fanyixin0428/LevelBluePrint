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
        [LabelText("任务简述")]
        public string taskComment;

        [LabelText("合并标签")]
        [ValueDropdown("MergeTag")]
        public string mergeTag;
        public static List<string> MergeTag = new List<string>() {"修改","新增","修改-待合并","新增-待合并","MASTER"};

        [LabelText("csgen")]
        public string csgen;

        [LabelText("唯一ID")]
        public int id;

        [LabelText("任务ID")]
        public int taskId;

        [LabelText("所属地图")]
        public int relateMapId;

        [LabelText("任务显示顺序")]
        public int taskOrder;

        [LabelText("任务类型")]
        [ValueDropdown("TaskType")]
        public string taskType;
        public static List<string> TaskType = new List<string>() { "home_story", "side_story", "event_story", "main_story" };
        
        [PropertySpace]
        [LabelText("本地化任务名")]
        public string lcName;
        
        [LabelText("本地化任务详情")]
        public string lcDetail;
        [LabelText("任务入口")]
        public TaskEntry entry;

        [LabelText("任务发布角色")]//TODO:抽空改成enum
        public int issuer;
        
        [PropertySpace]
        [LabelText("开启条件描述")]
        public string triggerConditionDescription;
        
        [LabelText("开启条件配置")]
        public string startCondition;

        [PropertySpace]
        [LabelText("任务需求描述")]
        public string taskTargetDescription;
        [LabelText("任务需求配置")]
        public string taskTarget;
        [PropertySpace]
        [LabelText("GOTO描述")]
        public string gotoDescription;
        [LabelText("GOTO配置")]
        public string gotoCompass;
        [LabelText("是否GOTO前置需求")]
        public bool isCompletePerTask;
        [PropertySpace]
        [LabelText("任务需求个数")]
        public int targetNumber;
        [LabelText("本地化任务需求")]
        public string targetLcDetail;
        [LabelText("图标名称")]
        public string targetIconDescription;
        [LabelText("图标地址")]
        public string targetIconAddress;
        [LabelText("图标索引类型")]
        public string targetIconType;
        [PropertySpace]
        [LabelText("奖励备注")]
        public string rewardDescription;
        [LabelText("奖励配置")]
        public string reward;
        [PropertySpace]
        [LabelText("任务不可见")]
        public bool isInvisible;
        [LabelText("任务链")]
        public string mapGroupInfo;
        [PropertySpace]
        [LabelText("建筑奖励")]
        public string giftBuilding;
        [LabelText("建筑奖励图标")]
        public string giftBuildingIcon;

    }

}
