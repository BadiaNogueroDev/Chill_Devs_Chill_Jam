using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Separator : TaskObjectiveItem
{
    [SerializeField] private Item.ItemType itemType = Item.ItemType.SEPARATOR;
    [SerializeField] private Stamp.ItemFunction typeOfStampRequired;
    [SerializeField] private Transform paperPosition;
    private int filesAmount = 0;
    
    public override void InteractWithItem(Item itemTouched)
    {
        if (itemTouched.TryGetComponent(out StampablePaper document) && document.StampType == typeOfStampRequired && document.stamped)
        {
            base.InteractWithItem(itemTouched);

            itemTouched.GetComponent<Collider>().enabled = false;
            itemTouched.itemRigidbody.isKinematic = true;
            itemTouched.transform.position = paperPosition.position + new Vector3(0,0.142f * filesAmount,0);
            itemTouched.transform.rotation = paperPosition.rotation;
            filesAmount++;
        }
    }
}
