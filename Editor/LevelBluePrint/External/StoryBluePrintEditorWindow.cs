    using Sirenix.OdinInspector.Editor;
    using Sirenix.Utilities;
    using Sirenix.Utilities.Editor;
    using UnityEditor;
    using UnityEngine;
    using System.Linq;
    using System;

namespace LevelBluePrintUtil
{
    public class StoryBluePrintEditorWindow : OdinMenuEditorWindow
    {

        private static StoryBluePrintEditorWindow window;

        private Action<OdinMenuEditorWindow> addBtnCallback;
        private Action<OdinMenuItem> removeBtnCallback;
        private string addName;
        private string removeName;

        [MenuItem("Story/StoryBluePrintEditorWindow Shift+A #A")]
        private static void OpenWindow()
        {
            var window = GetWindow<StoryBluePrintEditorWindow>();
            window.position = GUIHelper.GetEditorWindowRect().AlignCenter(1000, 700);
        }

        protected override OdinMenuTree BuildMenuTree()
        {
            var tree = new OdinMenuTree(true);
            tree.DefaultMenuStyle.IconSize = 28.00f;
            tree.Config.DrawSearchToolbar = true;
            tree.MenuItems.Add(new OdinMenuItem(tree, "关卡", LevelsSetting.Instance));
            tree.MenuItems.Add(new OdinMenuItem(tree, "录入新道具", CreateNewProperty.Instance));
            tree.AddAllAssetsAtPath("关卡/", "Editor/LevelBluePrint/Data", typeof(LevelGraph), true);

            tree.Selection.SelectionChanged += switchSetting;
            //set click right
            //tree.MenuItems.ForEach(i=> 
            //{
            //    AddRightClickPopup(i);
            //});

            // Adds the character overview table.
            //CharacterOverview.Instance.UpdateCharacterOverview();
            //tree.Add("Characters", new CharacterTable(CharacterOverview.Instance.AllCharacters));

            // Adds all characters.
            //  tree.AddAllAssetsAtPath("Characters", "Assets/Plugins/Sirenix", typeof(Character), true, true);

            // Add all scriptable object items.
            //  tree.AddAllAssetsAtPath("", "Assets/Plugins/Sirenix/Demos/SAMPLE - RPG Editor/Items", typeof(Item), true)
            //      .ForEach(this.AddDragHandles);

            // Add drag handles to items, so they can be easily dragged into the inventory if characters etc...
            //  tree.EnumerateTree().Where(x => x.Value as Item).ForEach(AddDragHandles);

            // Add icons to characters and items.
            //   tree.EnumerateTree().AddIcons<Character>(x => x.Icon);
            //  tree.EnumerateTree().AddIcons<Item>(x => x.Icon);

            return tree;
        }

        private void switchSetting(SelectionChangedType type)
        {
            var selected = this.MenuTree.Selection.FirstOrDefault();

            if (selected == null)
                return;

            var setting = (selected.Value as ICustomSetting);
            if (setting != null)
            {
                addName = setting.AddName;
                removeName = setting.RemoveName;
                addBtnCallback = setting.Add;
                removeBtnCallback = setting.Remove;
            }
            else
            {
                addBtnCallback = null;
                removeBtnCallback = null;
            }
        }



        private void AddDragHandles(OdinMenuItem menuItem)
        {
            menuItem.OnDrawItem += x => DragAndDropUtilities.DragZone(menuItem.Rect, menuItem.Value, false, false);
        }

        protected override void OnBeginDrawEditors()
        {
            var selected = this.MenuTree.Selection.FirstOrDefault();
            var toolbarHeight = this.MenuTree.Config.SearchToolbarHeight;
            SirenixEditorGUI.BeginHorizontalToolbar(toolbarHeight);
            {
                if (selected != null)
                    GUILayout.Label(selected.Name);

                if (addBtnCallback != null)
                    createButton(selected);

                if (removeBtnCallback != null)
                    deleteButton(selected);
            }

            SirenixEditorGUI.EndIndentedHorizontal();
        }

        /// <summary>
        /// 注册右键事件
        /// </summary>
        //private void AddRightClickPopup(OdinMenuItem item)
        //{
        //    if ((item.Value as LevelGraph) != null)
        //    {
        //        item.OnRightClick = showRightPopup;
        //    }

        //    if (item.ChildMenuItems.Count > 0)
        //    {
        //        item.ChildMenuItems.ForEach(i => {
        //            AddRightClickPopup(i);
        //        });
        //    }
        //}

        /// <summary>
        /// 唤出右键菜单项
        /// </summary>
        /// <param name="selected"></param>
        //private void showRightPopup(OdinMenuItem selected)
        //{
        //    RightClickPopup.ShowRightPopup(selected);
        //}

        private void createButton(OdinMenuItem selected)
        {
            GUI.color = Color.green;
            if (SirenixEditorGUI.ToolbarButton(new GUIContent(addName)))
            {
                addBtnCallback?.Invoke(this);
            }

            GUI.color = Color.white;
        }

        private void deleteButton(OdinMenuItem selected)
        {
            GUI.color = Color.red;
            if (SirenixEditorGUI.ToolbarButton(new GUIContent(removeName)))
            {
                removeBtnCallback?.Invoke(selected);
            }

            GUI.color = Color.white;
        }


        // Draws a toolbar with the name of the currently selected menu item.
        //SirenixEditorGUI.BeginHorizontalToolbar(toolbarHeight);
        //{
        //    if (selected != null)
        //    {
        //        GUILayout.Label(selected.Name);
        //    }

        //    if (SirenixEditorGUI.ToolbarButton(new GUIContent("Create Scenario")))
        //    {
        //        ScriptableObjectCreator.ShowDialog<Scenario>("Assets/Plugins/Sirenix/Demos/Sample - RPG Editor/Scenario", obj =>
        //        {

        //            base.TrySelectMenuItemWithObject(obj); // Selects the newly created item in the editor
        //        });
        //    }


        //}
        //SirenixEditorGUI.EndHorizontalToolbar();

    }
}




