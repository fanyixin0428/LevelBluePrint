using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sirenix.OdinInspector;

namespace LevelBluePrintUtil {
    [Serializable]
    public class DemandData
{
    public enum CompleteCondition { }


    [LabelText("ѡ������")]
    [Title("@option")]
    [BoxGroup]
    public string option = "";
    [LabelText("�����ж�")]
    [BoxGroup]
    public bool haveCondition;
    [LabelText("���ʽ")]
    [BoxGroup]
    public string condition = "";
}
}