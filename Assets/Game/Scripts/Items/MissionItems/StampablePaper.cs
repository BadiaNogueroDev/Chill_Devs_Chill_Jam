using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class StampablePaper : TaskObjectiveItem
{
    public Stamp.ItemFunction StampType;
    public bool stamped = false;
    public Vector3 collisionPoint;
    [SerializeField] public GameObject decal;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(Item.ITEM_TAG))
        {
            //collisionPoint = collision.GetContact(0).point;
            collisionPoint = transform.InverseTransformPoint(collision.GetContact(0).point);
        }
    }

    public override void InteractWithItem(Item itemTouched)
    {
        if (stamped)
            return;

        StartCoroutine("InstantiateDecal");
        stamped = true;
        base.InteractWithItem(itemTouched);
    }

    IEnumerator InstantiateDecal()
    {
        yield return new WaitForSeconds(0.1f);
        GameObject newDecal = Instantiate(decal, this.transform, false);
        newDecal.transform.localPosition = new Vector3(collisionPoint.x, 0.06f, collisionPoint.z);
    }
}