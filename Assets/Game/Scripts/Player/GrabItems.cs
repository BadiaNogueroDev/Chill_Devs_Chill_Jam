using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrabItems : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Transform grabPoint;
    [SerializeField] private float grabDistance;
    [SerializeField] private bool holdingItem;
    
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Grab(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            animator.SetBool("Grab", true);
            GrabItem();
        }
            
        else if (callbackContext.canceled)
        {
            animator.SetBool("Grab", false);
            ReleaseItem();
        }
    }

    public void GrabItem()
    {
        Debug.DrawRay(grabPoint.position, -transform.up * grabDistance, Color.yellow);
        if (Physics.Raycast(grabPoint.position, -transform.up, out RaycastHit hit, grabDistance, playerLayer))
        {
            if (hit.transform.tag == "Item" && hit.transform.GetComponent<Item>().grabbable && !holdingItem)
            {
                hit.transform.GetComponent<Rigidbody>().isKinematic = true;
                hit.transform.SetParent(grabPoint);
                holdingItem = true;
            }
        }
    }

    public void ReleaseItem()
    {
        if (holdingItem)
        {
            grabPoint.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
            grabPoint.GetChild(0).SetParent(null);
            holdingItem = false;
        }
    }
}
