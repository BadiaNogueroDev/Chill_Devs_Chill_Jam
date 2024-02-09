using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadzone : MonoBehaviour
{
    [SerializeField] private Transform spawner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item") && other.gameObject.GetComponent<Item>().recoverable)
        {
            other.gameObject.transform.position = spawner.transform.position;
            other.gameObject.transform.rotation = spawner.transform.rotation;
        }
    }
}
