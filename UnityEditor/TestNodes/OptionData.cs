using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sirenix.OdinInspector;
[Serializable]
public class OptionData
{
    [LabelText("选项内容")]
    [Title("@option")]
    [BoxGroup]
    public string option = "";
    [LabelText("条件判断")]
    [BoxGroup]
    public bool haveCondition;
    [LabelText("表达式")]
    [BoxGroup]
    public string condition = "";
}
