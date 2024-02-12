using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoTaskItem : Item
{
    private void Awake()
    {
        itemType = ItemType.PROP;
    }
}