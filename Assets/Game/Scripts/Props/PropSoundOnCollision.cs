using FMODUnity;
using UnityEngine;

public class PropSoundOnCollision : MonoBehaviour
{
    private Rigidbody propRigidbody;
    [SerializeField] private float minSpeedToSound = 2f;

    [SerializeField] private StudioEventEmitter impactSound;

    private void Awake()
    {
        propRigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(propRigidbody.velocity.magnitude);
        if (propRigidbody.velocity.magnitude >= minSpeedToSound)
        {
            impactSound.Play();
            return;
        }
        else if (collision.gameObject.TryGetComponent(out Rigidbody colliderRigidbody) && colliderRigidbody.velocity.magnitude >= minSpeedToSound)
        {
            impactSound.Play();
        }
    }
}