using UnityEngine;

public class CartridgeHolder : TaskObjectiveItem
{
    [SerializeField] private Transform cartridgeHoldPosition;

    public override void InteractWithItem(Item itemTouched)
    {
        base.InteractWithItem(itemTouched);

        itemTouched.transform.position = cartridgeHoldPosition.position;
        itemTouched.transform.rotation = cartridgeHoldPosition.rotation;
    }
}