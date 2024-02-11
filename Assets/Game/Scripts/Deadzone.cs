using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadzone : MonoBehaviour
{
    [SerializeField] private Transform spawner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent(out Item fallenItem))
        {
            fallenItem.RespawnItem(spawner);
        }
    }
}
