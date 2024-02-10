using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFollowItem : MonoBehaviour
{
    [SerializeField] private Transform itemToFollow;

    void Update()
    {
        transform.position = itemToFollow.position;
        transform.rotation = itemToFollow.rotation;
    }
}
