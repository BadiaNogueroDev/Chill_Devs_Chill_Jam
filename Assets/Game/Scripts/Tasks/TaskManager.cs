using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    [SerializeField] private List<Task> tasks = new List<Task>();

    IEnumerator NextTask()
    {
        yield return null;
    }
}
