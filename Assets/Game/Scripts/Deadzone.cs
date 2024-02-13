using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class Deadzone : MonoBehaviour
{
    [SerializeField] private Transform spawner;
    [SerializeField] private StudioEventEmitter tubeSoundRef;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent(out Item fallenItem))
        {
            fallenItem.RespawnItem(spawner);
            tubeSoundRef.Play();
        }
    }
}
