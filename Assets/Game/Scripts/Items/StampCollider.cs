using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampCollider : MonoBehaviour
{
    [SerializeField] private GameObject stampPrefab;
    private Stamp stamp;
    
    private void Awake()
    {
        stamp = GetComponentInParent<Stamp>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (!other.TryGetComponent(out StampablePaper stampablePaper) || stampablePaper.StampType != stamp.itemFunction)
            return;

        if (Physics.Raycast(transform.position, Vector3.down, 2f, 1))
        {
            
        }
        
        Instantiate(stampPrefab,transform.position, other.transform.rotation);
    }
}
