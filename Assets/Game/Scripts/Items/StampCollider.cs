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
        if (!other.TryGetComponent(out StampablePaper stampablePaper) || stampablePaper.StampType != stamp.itemFunction)
            return;
        
        stampablePaper.InteractWithItem(stamp);
    }
}
