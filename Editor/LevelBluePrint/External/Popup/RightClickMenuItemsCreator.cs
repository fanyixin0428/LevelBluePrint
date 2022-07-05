using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using UnityEditor;
using UnityEngine;

public static class RightClickMenuItemsCreator
{
    /// <summary>
    /// 结合 odin menutree window 功能
    /// </summary>
    /// <typeparam name="T"></typeparam>
    private class ScriptableObjectSelector<T> : OdinSelector<Type> where T : ScriptableObject
    {
        private Action<T> onScriptableObjectCreated;
        private string defaultDestinationPath;

        /// <summary>
        /// 构建 tree 中选中的数据（目测用不到）
        /// </summary>
        /// <param name="tree"></param>
        protected override void BuildSelectionTree(OdinMenuTree tree)
        {
            var scriptCustomTypes = AssemblyUtilities.GetTypes(AssemblyTypeFlags.CustomTypes);
            var scriptableTypes = scriptCustomTypes.Where(x => x.IsClass && !x.IsAbstract && x.InheritsFrom(typeof(T)));

            tree.Selection.SupportsMultiSelect = false;
            tree.Config.DrawSearchToolbar = true;
            tree.AddRange(scriptableTypes, x => x.GetNiceName()).AddThumbnailIcons();
        }

        private void ShowSaveFileDialog(IEnumerable<Type> selection)
        {
            // 创建对象
            var obj = ScriptableObject.CreateInstance(selection.FirstOrDefault()) as T;
            string dest = this.defaultDestinationPath.TrimEnd('/');

            if (!Directory.Exists(dest))
            {
                Directory.CreateDirectory(dest);
                AssetDatabase.Refresh();
            }

            dest = EditorUtility.SaveFilePanel("Save File", dest, 
                "Name " + typeof(T).GetNiceName(), "asset");
            
            if (!string.IsNullOrEmpty(dest) &&
                PathUtilities.TryMakeRelative(
                    Path.GetDirectoryName(Application.dataPath),
                    dest, out dest))
            {
                AssetDatabase.CreateAsset(obj, dest);
                AssetDatabase.Refresh();

                if (this.onScriptableObjectCreated != null)
                {
                    this.onScriptableObjectCreated(obj);
                }
            }
            else
            {
                UnityEngine.Object.DestroyImmediate(obj);
            }
        }

        public ScriptableObjectSelector(string defaultDestinationPath, Action<T> onScriptableObjectCreated)
        {
            this.onScriptableObjectCreated = onScriptableObjectCreated;
            this.defaultDestinationPath = defaultDestinationPath;
            this.SelectionConfirmed += this.ShowSaveFileDialog;
        }
    }

    public static void ShowDialog<T>(string defaultDestinationPath, Action<T> onScriptableObjectCreated = null) where T : ScriptableObject
    {
        var selector = new ScriptableObjectSelector<T>(defaultDestinationPath, onScriptableObjectCreated);

        if (selector.SelectionTree.EnumerateTree().Count() == 1)
        {
            selector.SelectionTree.EnumerateTree().First().Select();
            selector.SelectionTree.Selection.ConfirmSelection();
        }
        else
        {
            selector.ShowInPopup(200);
        }
    }
}
