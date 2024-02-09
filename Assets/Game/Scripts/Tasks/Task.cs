using UnityEngine;

[CreateAssetMenu]
public class Task : ScriptableObject
{
    [SerializeField] private string taskDescription;
    [SerializeField] private bool taskStarted;
    [SerializeField] private bool taskCompleted;

    public string TaskDescription { get { return taskDescription; } }
    public bool TaskStarted { get { return taskStarted; } }
    public bool TaskCompleted { get { return taskCompleted; } }
}