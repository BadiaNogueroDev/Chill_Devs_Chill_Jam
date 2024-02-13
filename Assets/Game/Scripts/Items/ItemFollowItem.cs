using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFollowItem : MonoBehaviour
{
    [SerializeField] private Transform itemToFollow;
    [SerializeField] private bool followRotation = true;
    void Update()
    {
        if (itemToFollow == null)
            Destroy(gameObject);
        transform.position = itemToFollow.position;
        if(followRotation)
            transform.rotation = itemToFollow.rotation;
    }
}
