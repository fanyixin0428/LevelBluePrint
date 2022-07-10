using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LevelBluePrintUtil.Hidden;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;
using XNode;
using XNodeEditor;
using OfficeOpenXml;

namespace LevelBluePrintUtil
{
    /// <summary>
    /// 关卡图
    /// </summary>


    [NodeGraphEditor.CustomNodeGraphEditorAttribute(typeof(LevelGraph))]
    [Serializable, CreateAssetMenu(fileName = "New Level", menuName = "LevelBluePrint/Create LevelBluePrint"),
     RequireNode(typeof(StartNode), typeof(EndNode))]
    public class LevelGraph : XNode.NodeGraph, ICustomSetting, ICustomGraph
    {

        [BoxGroup("基本属性"), HideLabel] public BasicProperty basic;

        //剧情/任务节点，用于自动生成剧情/任务节点ID
        [LabelText("剧情起始ID")]
        public int scenarioStartId;

        [LabelText("任务起始ID")]
        public int taskStartId;
        
        [PropertySpace]
        
        [HideInInspector]
        public int scenarioIndex = 0;
        [HideInInspector]
        public int taskUniqueIDIndex = 0;
        [HideInInspector]
        public int taskIDIndex = 0;


        #region Setting
        public string AddName
        {
            get { return "没啥用"; }
            set { }
        }

        public string RemoveName
        {
            get { return "也没啥用"; }
            set { }
        }
        [HideInInspector, SerializeField]
        public int genCount = 0;

        // 编辑器上一次停留位置
        [HideInInspector]
        public Vector2 LastFocusPosition;

        /// <summary>
        /// 导出 Excel 数据
        /// </summary>
        /// <param name="window"></param>
        public void Add(OdinMenuEditorWindow window)
        {
            // 全部 dialog 遍历
        }

        /// <summary>
        /// 删除 Excel 数据
        /// </summary>
        /// <param name="selected"></param>
        public void Remove(OdinMenuItem selected)
        {
            // 移除全部 excel
        }

        #endregion

        public LevelGraph()
        {
            if (basic == null)
                basic = new BasicProperty();
        }

        public void UpdateData()
        {
            // reset node index
            for (int i = 0; i < nodes.Count(); i++)
            {
                var pfNode = (nodes[i] as PhotonfoxNode);
                if (pfNode == null)
                {
                    continue;
                }

                pfNode.index = i + 1;
            }
        }

        /// <summary>
        /// 添加节点时自动生成序号
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public override Node AddNode(Type type)
        {
            Node node = null;
            genCount++;
            // 设置 index
            switch (type.Name)
            {
                case "ScenarioNode":
                    node = base.AddNode(type);
                    if (node!=null)
                        GenerateScenarioNode(node);
                    //添加剧情节点时，自动添加剧情节点的ID和地图ID;
                    break;
                case "TaskNode":
                    node = base.AddNode(type);
                    if (node != null)
                        GenerateTaskNode(node);
                    //添加任务节点时，自动添加任务节点ID
                    break;
                default:
                    node = base.AddNode(type);
                    break;
            }


            UpdateData();

            return node;
        }

        //添加剧情节点时，自动添加剧情节点的ID和地图ID;
        public void GenerateScenarioNode(Node node) 
        {
            scenarioIndex++;
            ScenarioNode scenarioNode = (node as ScenarioNode);
            scenarioNode.property.scenarioId = scenarioStartId + scenarioIndex;
            scenarioNode.property.mapId = basic.mapId;
        }
        public void GenerateTaskNode(Node node)
        {
            taskUniqueIDIndex++;
            taskIDIndex++;
            TaskNode taskNode = (node as TaskNode);
            taskNode.property.id = taskStartId + taskUniqueIDIndex;
            taskNode.property.taskId = taskStartId + taskIDIndex;
            taskNode.property.relateMapId = basic.mapId;
            taskNode.property.taskType = basic.levelType;
            taskNode.property.lcName = string.Concat("LC_TASK", taskNode.property.taskType, "_", taskNode.property.taskId, "_name");
            taskNode.property.lcDetail = string.Concat("LC_TASK", taskNode.property.taskType, "_", taskNode.property.taskId, "_desc");
            
        }


        //复制节点

        public override Node CopyNode(Node original)
        {
            genCount++;
            Node node = null;
            var type = original.GetType();

            // 设置 index
            switch (type.Name)
            {
                case "ScenarioNode":
                    node = base.CopyNode(original);
                    if (node != null)
                        GenerateScenarioNode(node);
                    // UpdateScenarioNode();
                    break;
                case "TaskNode":
                    node = base.CopyNode(original);
                    if (node != null)
                        GenerateTaskNode(node);
                    break;
                default:
                    node = base.CopyNode(original);
                    break;
            }



            UpdateData();

            return node;
        }

        public override void RemoveNode(Node node)
        {
            base.RemoveNode(node);
            UpdateData();
            //UpdateScenarioNode();
        }

        #region ExportTable
        [Button("导出Scenario_trigger表", ButtonSizes.Large)]
        public void OutputSScenario_triggerTable()
        {

            string filePath = "Assets/Editor/LevelBluePrint/Excel/" + basic.name + "Scenario_trigger" + DateTime.Now.ToString("HH-mm-ss--dd-MM-yyyy") + ".xlsx";

            //因为文件不存在，所以取不到Excel信息
            FileInfo fileInfo = new FileInfo(filePath);
            //通过Excel表格的文件信息打开Excel表格
            using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))//打开Excel表格
            {
                //取得Excel文件中的第一张表
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

                int rowNum = 1;

                worksheet.Cells[rowNum, 1].Value = "comment";
                worksheet.Cells[rowNum, 2].Value = "标签";
                worksheet.Cells[rowNum, 3].Value = "A_INT_id";
                worksheet.Cells[rowNum, 4].Value = "A_INT_map_id";
                worksheet.Cells[rowNum, 5].Value = "C_STR_lua_file";
                worksheet.Cells[rowNum, 6].Value = "A_INT_type";
                worksheet.Cells[rowNum, 7].Value = "A_INT_cloud_map_id";
                worksheet.Cells[rowNum, 8].Value = "A_INT_cloud_id";
                worksheet.Cells[rowNum, 9].Value = "A_INT_quest_id";
                worksheet.Cells[rowNum, 10].Value = "A_INT_quest_stage";
                worksheet.Cells[rowNum, 11].Value = "A_INT_map_first_time_id";
                worksheet.Cells[rowNum, 12].Value = "A_INT_level";
                worksheet.Cells[rowNum, 13].Value = "A_ARR_block";
                worksheet.Cells[rowNum, 14].Value = "A_ARR_cloud";
                worksheet.Cells[rowNum, 15].Value = "A_ARR_item";
                worksheet.Cells[rowNum, 16].Value = "A_INT_trigger_flag";
                worksheet.Cells[rowNum, 17].Value = "A_INT_pillar_group";
                worksheet.Cells[rowNum, 18].Value = "A_ARR_map_block";
                worksheet.Cells[rowNum, 19].Value = "A_INT_building_upgrade";

                for (int i = 0; i < nodes.Count(); i++)
                {

                    var pfNode = (nodes[i] as PhotonfoxNode);
                    if (pfNode == null)
                    {
                        continue;
                    }
                    if (pfNode is ScenarioNode)
                    {
                        ScenarioNode scenarioNode = pfNode as ScenarioNode;
                        rowNum++;
                        worksheet.Cells[rowNum, 1].Value = scenarioNode.property.comment;
                        worksheet.Cells[rowNum, 2].Value = scenarioNode.property.mergeTag;
                        worksheet.Cells[rowNum, 3].Value = scenarioNode.property.scenarioId;
                        worksheet.Cells[rowNum, 4].Value = scenarioNode.property.mapId;
                        worksheet.Cells[rowNum, 5].Value = scenarioNode.property.luaFile;
                        worksheet.Cells[rowNum, 6].Value = (int)scenarioNode.property.triggerType;
                        worksheet.Cells[rowNum, 7].Value = scenarioNode.property.cloudMapId;
                        worksheet.Cells[rowNum, 8].Value = scenarioNode.property.cloudId;
                        worksheet.Cells[rowNum, 9].Value = scenarioNode.property.taskId;
                        worksheet.Cells[rowNum, 10].Value = scenarioNode.property.taskStage;
                        worksheet.Cells[rowNum, 11].Value = scenarioNode.property.mapFirstEntryId;
                        worksheet.Cells[rowNum, 12].Value = scenarioNode.property.levelReach;
                        worksheet.Cells[rowNum, 13].Value = scenarioNode.property.blockInvisible;
                        worksheet.Cells[rowNum, 14].Value = scenarioNode.property.cloudUnlockJsonArray;
                        worksheet.Cells[rowNum, 15].Value = scenarioNode.property.item;
                        worksheet.Cells[rowNum, 16].Value = scenarioNode.property.triggerFlag;
                        worksheet.Cells[rowNum, 17].Value = scenarioNode.property.pillarGroup;
                        worksheet.Cells[rowNum, 18].Value = scenarioNode.property.mapBlock;
                        worksheet.Cells[rowNum, 19].Value = scenarioNode.property.buildingId;

                    }

                }

                excelPackage.Save();
                //取得表中第一行第一列中的数据

            }//关闭Excel表格

            Debug.Log("配置表导出成功！文件名：" + filePath);
        }
        #endregion

        //[Button("ExcelReaderTest", ButtonSizes.Large)]
        //public void ExcelReaderTestButton()
        //{
        //    ExcelReadWrite excelReadWrite = new ExcelReadWrite();
        //    excelReadWrite.testExcelReadWrite();
        //}
        [Button("TestLoadScriptableObjectAssets", ButtonSizes.Large)]
        public void LoadExampleAsset()
        {
            var exampleAsset =
            AssetDatabase.LoadAssetAtPath<Sheet2>
                                       ("Assets/sheet2.asset");
            Debug.Log(exampleAsset.dataList[1].Id);

        }
    }
}