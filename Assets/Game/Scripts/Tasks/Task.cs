using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Task : ScriptableObject
{
    [SerializeField] private string taskTitle;
    [SerializeField] private string taskDescription;
    [SerializeField] private bool taskStarted;
    [SerializeField] private bool taskFailed;
    [SerializeField] private bool taskCompleted;

    public string TaskTitle { get { return taskTitle; } }
    public string TaskDescription { get { return taskDescription; } }
    public bool TaskStarted { get { return taskStarted; } }
    public bool TaskFailed { get { return taskFailed; } }
    public bool TaskCompleted { get { return taskCompleted; } }
}
