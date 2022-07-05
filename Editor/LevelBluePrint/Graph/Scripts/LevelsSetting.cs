using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using UnityEditor;
using UnityEngine;

namespace LevelBluePrintUtil
{

    /// <summary>
    /// 全局关卡设置，向下继承
    /// </summary>
    [GlobalConfigAttribute("Editor/LevelBluePrint")]
    public class LevelsSetting : GlobalConfig<LevelsSetting>, ICustomSetting
    {
        [BoxGroup("关卡属性"), HideLabel]
        public BasicProperty basic;
                
        public string AddName 
        {
            get {  return "新增"; }
            set { }
        }

        public string RemoveName
        {
            get {  return "删除"; }
            set { }
        }

        public LevelsSetting()
        {
            if (basic == null)
                basic = new BasicProperty();
        }

        /// <summary>
        /// Add new StoryGraph
        /// </summary>
        public void Add(OdinMenuEditorWindow window)
        {
           // Create new Story in path 
            RightClickMenuItemsCreator.ShowDialog<LevelGraph>("Assets/Editor/LevelBluePrint/Data/", (obj) =>
            {
                // obj.titleName = obj.name;
                window.TrySelectMenuItemWithObject(obj);
            });
            AssetDatabase.Refresh();
        }

        /// <summary>
        ///  Remove Story Data
        /// </summary>
        public void Remove(OdinMenuItem selected)
        {
            // delete data 
            if (selected == null)
            {
                Debug.LogWarning("未找到删除对象");
                return;
            }

            (selected.Value as LevelGraph).DeleteSelf();
        }

        //[Button("生成Scenario表", ButtonSizes.Large)]
        //public void OutputScenarioExcel()
        //{
            
        //}
        //[Button("生成Task表", ButtonSizes.Large)]
        //public void OutputTaskExcel()
        //{

        //}

    }

}
