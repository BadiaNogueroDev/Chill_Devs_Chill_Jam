using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class StampablePaper : TaskObjectiveItem
{
    public Stamp.ItemFunction StampType;
    
    public virtual void InteractWithItem(Item itemTouched)
    {
        if (((Stamp)itemTouched).itemFunction != StampType)
            return;
    }
}
