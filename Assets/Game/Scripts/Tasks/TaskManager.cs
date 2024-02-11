using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;

public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance;
    
    [SerializeField] private TaskInfoUI taskInfoUIPrefab;
    
    private List<Task> currentTasksList = new List<Task>();
    [SerializeField] private List<TasksList> taskLists = new List<TasksList>();

    public int CurrentTasksIndex = 0;
    [SerializeField] private Transform displayTransform;

    public bool AllTasksDone => currentTasksList.All(x => x.TaskCompleted);
    
    private void Awake()
    {
        Instance = this;
    }

    public void NextTasks()
    {
        if (!AllTasksDone)
            return;
        
        foreach (var task in currentTasksList)
        {
            task.RemoveTaskFromList();
        }
        
        currentTasksList.Clear();

        foreach (var taskData in taskLists[CurrentTasksIndex].taskList)
        {
            TaskInfoUI taskInfoUI = Instantiate(taskInfoUIPrefab, displayTransform);
            taskInfoUI.SetDescription(taskData.TaskDescription);
            taskInfoUI.SetCheckmark(false);
            currentTasksList.Add(new Task(taskData, taskInfoUI));
        }
    }
}

[Serializable]
public class TasksList
{
    public List<TaskData> taskList = new List<TaskData>();
}