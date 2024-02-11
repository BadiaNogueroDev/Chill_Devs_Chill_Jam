using System;
using UnityEngine;

public class TaskObjectiveItem : MonoBehaviour
{
    [SerializeField] private Item.ItemType itemToInteractWith;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (!other.CompareTag(Item.ITEM_TAG))
            return;

        if (other.TryGetComponent(out Item itemTouched) && itemTouched.itemType == itemToInteractWith)
        {
            InteractWithItem(itemTouched);
        }
    }

    public virtual void InteractWithItem(Item itemTouched)
    {
        itemTouched.InteractedWithTaskObjective();
    }
}
