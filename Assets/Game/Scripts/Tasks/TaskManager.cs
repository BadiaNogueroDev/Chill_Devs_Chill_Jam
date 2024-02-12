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
    [SerializeField] private Transform itemSpawner;

    [SerializeField]private List<GameObject> requiredTaskItems = new List<GameObject>();

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
            GenerateTaskItemList(taskData);
            currentTasksList.Add(new Task(taskData, taskInfoUI));
        }

        SpawnRandomizedTaskItem();
    }

    public void TaksObjectiveDone(Item.ItemType taskType)
    {
        foreach (var task in currentTasksList)
        {
            if (task.taskType != taskType)
                return;

            task.ObjectiveDone();
        }
    }

    public void GenerateTaskItemList(TaskData data)
    {
        if (data.requiredItem == null) return;
        for (int i = 0; i < data.requiredItem.Count; i++)
        {
            requiredTaskItems.Add(data.requiredItem[i]);
        }
    }

    public void SpawnRandomizedTaskItem()
    {
        System.Random random = new System.Random();

        for (int i = requiredTaskItems.Count - 1; i > 0; i--)
        {
            int n = random.Next(i + 1);
            GameObject item = requiredTaskItems[n];
            requiredTaskItems[n] = requiredTaskItems[i];
            requiredTaskItems[i] = item;
        }

        for (int i = 0; i < requiredTaskItems.Count; i++)
        {
            Instantiate(requiredTaskItems[i], itemSpawner.position, itemSpawner.rotation);
        }
    }
}

[Serializable]
public class TasksList
{
    public List<TaskData> taskList = new List<TaskData>();
}