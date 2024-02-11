using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamp : Item
{
    public enum ItemFunction
    {
        SQUARE,
        CIRCLE,
        TRIANGLE
    }

    public ItemFunction itemFunction;
    public ItemType itemType => ItemType.STAMP;
}
