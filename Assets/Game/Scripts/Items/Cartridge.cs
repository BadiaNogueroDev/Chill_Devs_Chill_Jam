using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartridge : Item
{
    public enum ItemFunction
    {
        PART_1,
        PART_2
    }
    public ItemFunction itemFunction;

    private void Awake()
    {
        itemType = ItemType.CARTRIDGE;
    }

    public override void InteractedWithTaskObjective()
    {        
        switch (itemFunction)
        {
            case ItemFunction.PART_1:
                if (TaskManager.Instance.CurrentTasksIndex == 0) TaskManager.Instance.NextTasks();
                break;
            
            case ItemFunction.PART_2:
                if (TaskManager.Instance.CurrentTasksIndex == 1) TaskManager.Instance.NextTasks();
                break;
        }
    }
}