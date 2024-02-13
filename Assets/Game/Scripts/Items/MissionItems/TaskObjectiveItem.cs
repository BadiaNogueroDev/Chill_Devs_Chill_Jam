using FMODUnity;
using UnityEngine;

public class TaskObjectiveItem : MonoBehaviour
{
    [SerializeField] private Item.ItemType itemToInteractWith;
    [SerializeField] private StudioEventEmitter itemInteractionSoundRef;

    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(Item.ITEM_TAG))
            return;
                
        if (other.TryGetComponent(out Item itemTouched) && itemTouched.itemType == itemToInteractWith)
        {
            InteractWithItem(itemTouched);
            itemInteractionSoundRef.Play();
        }
    }

    public virtual void InteractWithItem(Item itemTouched)
    {
        itemTouched.InteractedWithTaskObjective();
    }
}