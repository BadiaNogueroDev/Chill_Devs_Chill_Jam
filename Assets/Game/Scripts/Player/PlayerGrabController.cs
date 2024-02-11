using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerGrabController : MonoBehaviour
{
    public static PlayerGrabController Instance;
    
    [SerializeField] private LayerMask itemLayer;
    [SerializeField] private Transform grabPoint;
    [SerializeField] private float grabRadius = 1;

    private Item grabbedItem;
    private bool IsGrabbingAnItem => grabbedItem != null;
    
    private Animator animator;
    [SerializeField] private Rigidbody hoofRigidbody;

    private void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();
    }

    public void Grab(InputAction.CallbackContext callbackContext)
    {
        bool tryingToGrab = false;
        
        if (callbackContext.performed)
        {
            AttemptItemGrab();
            tryingToGrab = true;
        }
        else if (callbackContext.canceled)
        {
            AttemptItemDrop();
        }
        
        animator.SetBool("Grab", tryingToGrab);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(grabPoint.position, grabRadius);
    }
    
    private void AttemptItemGrab()
    {
        if (IsGrabbingAnItem)
            return;

        float closestItemDistance = float.MaxValue;

        var itemInGrabRange = Physics.OverlapSphere(grabPoint.position, grabRadius, itemLayer);
        Item itemToGrab = null;
        
        foreach (var itemCollider in itemInGrabRange)
        {
            if (Vector3.Distance(itemCollider.transform.position, transform.position) >= closestItemDistance || 
                !itemCollider.transform.TryGetComponent(out Item item))
                continue;

            itemToGrab = item;
        }

        if (itemToGrab == null)
            return;
        
        grabbedItem = itemToGrab.GrabItem(grabPoint);
    }

    private void AttemptItemDrop()
    {
        if (!IsGrabbingAnItem)
            return;

        grabbedItem.DropItem(hoofRigidbody.velocity);
        grabbedItem = null;
    }

    public void RemoveHeldItem(Item item)
    {
        if (grabbedItem != item)
            return;
        
        grabbedItem = null;
    }
}
