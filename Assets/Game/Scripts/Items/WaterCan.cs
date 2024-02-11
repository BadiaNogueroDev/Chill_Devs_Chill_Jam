using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCan : Item
{
    public ItemType itemType => ItemType.WATER_CAN;
    
    public enum ItemFunction
    {
        //Interaccion solo con la planta
    }

    public ItemFunction itemFunction;
}
