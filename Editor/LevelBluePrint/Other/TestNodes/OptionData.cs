using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sirenix.OdinInspector;
[Serializable]
public class OptionData
{
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
