using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampCollider : MonoBehaviour
{
    [SerializeField] private GameObject stampPrefab;
    private Stamp stamp;
    [SerializeField] private LayerMask stampableLayer;
    
    private void Awake()
    {
        stamp = GetComponentInParent<Stamp>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Physics.Raycast(transform.parent.position, -transform.up, out RaycastHit hitInfo, 2f, stampableLayer))
        {
            if (!hitInfo.transform.TryGetComponent(out StampablePaper stampablePaper) || stampablePaper.StampType != stamp.itemFunction)
                return;
            
            stampablePaper.InteractWithItem(stamp);

            Debug.Log(hitInfo.transform.gameObject.name);
            GameObject stampGameObject = Instantiate(stampPrefab, hitInfo.point,Quaternion.Euler(hitInfo.normal));
            stampGameObject.transform.SetParent(stampablePaper.transform);
        }
    }
}
