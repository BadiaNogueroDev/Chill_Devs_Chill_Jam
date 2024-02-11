using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class StampablePaper : TaskObjectiveItem
{
    public Stamp.ItemFunction StampType;
    private bool stamped = false;

    public override void InteractWithItem(Item itemTouched)
    {
        if (stamped)
            return;
        
        stamped = true;
        base.InteractWithItem(itemTouched);
    }
}
