using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Item : MonoBehaviour
{
    public const string ITEM_TAG = "Item";
    
    public enum ItemType
    {
        CARTRIDGE, //Misiones 1 y 2
        DOCUMENT, //Destruir y estampar
        STAMP, //Cuadrado, redonda, triangulo
        SEPARATOR, //Tres secciones para cada stamp
        SHREDDER, //Interaccion solo con hojas
        PLANT, //Interaccion solo con la regadera
        WATER_CAN, //Interaccion solo con la planta
        PROP
    }

    public ItemType itemType;

    [SerializeField] protected bool grabbable;
    [SerializeField] protected bool recoverable;

    private int initialLayer;
    public Rigidbody itemRigidbody;

    private void Awake()
    {
        //itemRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        gameObject.tag = ITEM_TAG;
        initialLayer = gameObject.layer;
        //Mogut de Awake a Start perque en el Awake no es fa la asignacio del rb a la variable
        itemRigidbody = GetComponent<Rigidbody>();
    }

    public virtual Item GrabItem(Transform grabberTransform)
    {
        if (!grabbable)
            return null;
        
        itemRigidbody.isKinematic = true;
        transform.SetParent(grabberTransform);
        
        gameObject.layer = 6;
        return this;
    }

    public virtual void DropItem(Vector3 velocity)
    {
        itemRigidbody.isKinematic = false;
        transform.SetParent(null);
        itemRigidbody.velocity = velocity;

        gameObject.layer = initialLayer;
    }

    public virtual void RespawnItem(Transform respawnTransform)
    {
        if (!recoverable)
            return;

        itemRigidbody.isKinematic = false;
        transform.position = respawnTransform.position;
        transform.rotation = respawnTransform.rotation;
    }

    public virtual void InteractedWithTaskObjective()
    {
        itemRigidbody.isKinematic = false;
        transform.SetParent(null);
        gameObject.layer = initialLayer;
        
        TaskManager.Instance.TaksObjectiveDone(itemType);
        PlayerGrabController.Instance.RemoveHeldItem(this);
    }
}