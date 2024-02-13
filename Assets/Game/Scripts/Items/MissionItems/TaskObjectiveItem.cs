using FMODUnity;
using UnityEngine;

public class TaskObjectiveItem : MonoBehaviour
{
    [SerializeField] protected Item.ItemType itemToInteractWith;
    [SerializeField] protected StudioEventEmitter itemInteractionSoundRef;

    public virtual void OnTriggerEnter(Collider other)
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