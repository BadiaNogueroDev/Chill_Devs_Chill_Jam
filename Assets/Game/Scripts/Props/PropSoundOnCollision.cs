using FMODUnity;
using UnityEngine;

public class PropSoundOnCollision : MonoBehaviour
{
    private Rigidbody propRigidbody;
    [SerializeField] private float minSpeedToSound = 2f;

    private StudioEventEmitter impactSound;

    private void Awake()
    {
        propRigidbody = GetComponent<Rigidbody>();
        impactSound = GetComponent<StudioEventEmitter>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(propRigidbody.velocity.magnitude);
        if (propRigidbody.velocity.magnitude >= minSpeedToSound)
        {
            impactSound.Play();
        }
    }
}