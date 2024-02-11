using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Separator : Item
{
    public enum ItemFunction
    {
        SQUARE,
        CIRCLE,
        TRIANGLE
    }

    public ItemFunction itemFunction;
    public ItemType itemType => ItemType.SEPARATOR;
}
