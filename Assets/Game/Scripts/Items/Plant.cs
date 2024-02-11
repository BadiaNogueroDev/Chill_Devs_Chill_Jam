using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : Item
{
    public enum ItemFunction
    {
        //Interaccion solo con la regadera
    }

    public ItemFunction itemFunction;
    public ItemType itemType => ItemType.PLANT;
}
