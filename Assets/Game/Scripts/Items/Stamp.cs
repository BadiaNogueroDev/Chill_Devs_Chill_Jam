using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamp : Item
{
    public enum ItemFunction
    {
        SQUARE,
        CIRCLE,
        TRIANGLE
    }

    public ItemFunction itemFunction;
    public ItemType itemType => ItemType.STAMP;
    
    public override Item GrabItem(Transform grabberTransform)
    {
        if (!grabbable)
            return null;
        
        itemRigidbody.isKinematic = true;
        transform.SetParent(grabberTransform);
        
        gameObject.layer = 11;
        return this;
    }
    
    public override void InteractedWithTaskObjective()
    {
        TaskManager.Instance.TaksObjectiveDone(itemType);
    }
}
