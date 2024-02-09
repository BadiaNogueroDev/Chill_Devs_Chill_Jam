using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Item : MonoBehaviour
{
    public enum ItemType
    {
        DISK, //Misiones 1 y 2
        DOCUMENT, //Destruir y estampar
        STAMP, //Cuadrado, redonda, triangulo
        SEPARATOR, //Tres secciones para cada stamp
        SHREDDER, //Interaccion solo con hojas
        PLANT, //Interaccion solo con la regadera
        WATER_CAN, //Interaccion solo con la planta
        GONG, //Interaccion solo con el palo
        GONG_STICK, //Interaccion solo con el gong
    }

    public ItemType itemType;

    public bool grabbable;
    public bool recoverable;

    private void Start()
    {
        gameObject.tag = "Item";
    }
}