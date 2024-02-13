using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Cartridge : Item
{
    public enum ItemFunction
    {
        PART_1,
        PART_2
    }
    public ItemFunction itemFunction;
    public bool isInHolder = false;
    public bool HasBeenUsed = false;
    
    private void Awake()
    {
        itemType = ItemType.CARTRIDGE;
    }

    public bool CanBeGrabbed()
    {
        return !isInHolder && TaskManager.Instance.AllTasksDone;
    }
    
    public override Item GrabItem(Transform grabberTransform)
    {
        if (!grabbable || !CanBeGrabbed())
            return null;

        isInHolder = false;
        itemRigidbody.isKinematic = true;
        transform.SetParent(grabberTransform);
        
        gameObject.layer = 6;
        return this;
    }
    
    public override void InteractedWithTaskObjective()
    {
        itemRigidbody.isKinematic = true;
        transform.SetParent(null);
        PlayerGrabController.Instance.RemoveHeldItem(this);
        gameObject.layer = initialLayer;
        
        switch (itemFunction)
        {
            case ItemFunction.PART_1:
                if (TaskManager.Instance.CurrentTasksIndex == 0)
                {
                    TaskManager.Instance.NextTasks();
                    HasBeenUsed = true; 
                }
                break;
            
            case ItemFunction.PART_2:
                if (TaskManager.Instance.CurrentTasksIndex == 1)
                {
                    TaskManager.Instance.NextTasks();
                    HasBeenUsed = true;
                }
                break;
        }
    }
}