using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gong : Item
{
    public enum ItemFunction
    {
        //Interaccion solo con el palo
    }

    public ItemFunction itemFunction;
    public ItemType itemType => ItemType.GONG;
}
