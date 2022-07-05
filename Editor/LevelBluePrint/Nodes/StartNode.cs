using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace LevelBluePrintUtil.Hidden {
    [NodeTintAttribute("#26821f")]
    [NodeTitle("开始")]
    public class StartNode : PhotonfoxNode
    {
        [LabelText("关卡名称")]
        public string levelName;

        [LabelText("关卡ID")]
        public int levelId;

        [PropertySpace]

        [LabelText("剧情开始ID")]
        public int scenarioId;
        
        [LabelText("任务开始ID")]
        public int taskId;

        [Button("填入关卡信息", ButtonSizes.Medium)]
        public void InitMapInfo()
        {

            LevelGraph levelGraph = this.graph as LevelGraph;
            scenarioId = levelGraph.scenarioId;
            taskId = levelGraph.taskId;

            levelId = levelGraph.basic.mapId;
            levelName = levelGraph.basic.name;
        }


        public override int type
        {
            get => (int)NodeType.START;
        }

        /// <summary>
        /// 是否有输出数据
        /// </summary>
        public override bool OutputData
        {
            get => false;
        }
    }
}