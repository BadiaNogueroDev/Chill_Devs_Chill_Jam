using System;
using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundAtARandomTime : MonoBehaviour
{
    [SerializeField] private StudioEventEmitter randomSoundRef;
    [SerializeField] private Vector2 randomDelayRange;

    private float currentRandomTime = 0;
    private float elapsedTime = 0;

    private void Start()
    {
        currentRandomTime = Random.Range(randomDelayRange.x, randomDelayRange.y);
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= currentRandomTime)
        {
            elapsedTime = 0;
            currentRandomTime = Random.Range(randomDelayRange.x, randomDelayRange.y);
            randomSoundRef?.Play();
        }
    }
}
