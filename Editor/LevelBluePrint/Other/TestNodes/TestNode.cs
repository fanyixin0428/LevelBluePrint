using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class TestNode : Node {

    [LabelText("选项组")]
    [ShowInInspector]
    [InlineProperty]
    [ListDrawerSettings(ShowPaging = false, Expanded = true)]
    [Output(backingValue = ShowBackingValue.Never,
        connectionType = ConnectionType.Override,
        dynamicPortList = true)]
    [OnCollectionChanged(After = "OnDynamicPortListChange")]
    public List<OptionData> options = new List<OptionData>();

}