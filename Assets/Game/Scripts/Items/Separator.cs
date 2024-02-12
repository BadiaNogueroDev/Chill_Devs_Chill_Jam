using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Separator : TaskObjectiveItem
{
    [SerializeField] private Item.ItemType itemType = Item.ItemType.SEPARATOR;
    [SerializeField] private Stamp.ItemFunction typeOfStampRequired;
    [SerializeField] private Transform paperPosition;

    public override void InteractWithItem(Item itemTouched)
    {
        if (itemTouched.TryGetComponent(out StampablePaper document) && document.StampType == typeOfStampRequired && document.stamped)
        {
            itemTouched.transform.position = paperPosition.position;
            itemTouched.transform.rotation = paperPosition.rotation;
            itemTouched.itemRigidbody.constraints = RigidbodyConstraints.FreezeAll;
            TaskManager.Instance.TaksObjectiveDone(itemType);
        }
    }
}
