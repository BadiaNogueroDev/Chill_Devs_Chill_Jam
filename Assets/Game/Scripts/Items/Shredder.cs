using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : TaskObjectiveItem
{
    [SerializeField] private Transform paperInitialPosition;
    [SerializeField] private Transform paperFinalPosition;
    [SerializeField] private float shredTime = 0.5f;

    public override void InteractWithItem(Item itemTouched)
    {
        itemTouched.itemRigidbody.isKinematic = true;
        itemTouched.transform.position = paperInitialPosition.position;
        itemTouched.transform.rotation = paperInitialPosition.rotation;
        StartCoroutine(Shred(itemTouched.gameObject));
    }

    IEnumerator Shred(GameObject document)
    {
        float time = 0f;
        while (time <= shredTime)
        {
            float t = time / shredTime;
            document.transform.position = Vector3.Lerp(paperInitialPosition.position, paperFinalPosition.position, t);
            time += Time.deltaTime;
            yield return null;
        }

        if (document.TryGetComponent(out Document doc) && doc.itemFunction == Document.ItemFunction.STAMP)
        {
            doc.RespawnItem(TaskManager.Instance.itemSpawner);
        }
    }
}
