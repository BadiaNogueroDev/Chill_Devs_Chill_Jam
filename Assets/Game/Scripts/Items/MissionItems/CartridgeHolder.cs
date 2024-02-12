using UnityEngine;

public class CartridgeHolder : TaskObjectiveItem
{
    [SerializeField] private Transform cartridgeHoldPosition;
    
    public override void InteractWithItem(Item itemTouched)
    {
        base.InteractWithItem(itemTouched);

        itemTouched.itemRigidbody.isKinematic = true;
        itemTouched.transform.position = cartridgeHoldPosition.position;
        itemTouched.transform.rotation = cartridgeHoldPosition.rotation;
    }
}