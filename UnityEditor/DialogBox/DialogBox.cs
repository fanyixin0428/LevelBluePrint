using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using UnityEngine;

namespace PhotonfoxUtil
{
    /// <summary>
    /// 公用弹窗
    /// </summary>
    public class DialogBox : OdinEditorWindow
    {
        protected string content;
        private Action done;
        private Action cancel;

        public static void Show(string msg, Action done = null, Action cancel = null)
        {
            var window = GetWindow<DialogBox>();
            window.position = GUIHelper.GetEditorWindowRect().AlignCenter(300, 200);
            window.content = msg;
            window.done = done;
            window.cancel = cancel;
            
            window.Focus();
        }

        //protected override void OnGUI()
        //{
        //    var style = new GUIStyle();
        //    style.fixedHeight = 150;
        //    style.fixedWidth = 300;
        //    style.alignment = TextAnchor.MiddleCenter;
        //    style.normal.textColor = Color.white;
        //    GUILayout.Box(this.content, style);
        //    base.OnGUI();
        //}

        [HorizontalGroup("Choice")]
        [Button("Done"), GUIColor(0.3f, 0.8f, 0.8f, 1f)]
        public void doneExecute()
        {
            this?.done();
            this.Close();
        }
    
        [HorizontalGroup("Choice")]
        [Button("Cancel"), GUIColor(1f, 0.9f, 0.45f)]
        public void cancelExecute()
        {
            this?.cancel();
            this.Close();
        }
    }
}
