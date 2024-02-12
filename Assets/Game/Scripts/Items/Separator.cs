using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Separator : TaskObjectiveItem
{
    [SerializeField] private Stamp.ItemFunction typeOfStampRequired;
    [SerializeField] private Transform paperPosition;

    public override void InteractWithItem(Item itemTouched)
    {
        Debug.Log("Interaction with document");
        if (itemTouched.TryGetComponent(out StampablePaper document) && document.StampType == typeOfStampRequired && document.stamped)
        {
            Debug.Log("Correct document");
            itemTouched.transform.position = paperPosition.position;
            itemTouched.transform.rotation = paperPosition.rotation;
        }
    }
}
