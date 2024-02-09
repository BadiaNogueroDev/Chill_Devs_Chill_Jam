using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disk : Item
{
    public enum ItemFunction
    {
        PART_1,
        PART_2
    }

    public ItemFunction itemFunction;
}