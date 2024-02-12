using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Document : Item
{
    public enum ItemFunction
    {
        STAMP,
        SHRED
    }

    public ItemFunction itemFunction;

    private void Awake()
    {
        itemType = ItemType.DOCUMENT;
    }
}
