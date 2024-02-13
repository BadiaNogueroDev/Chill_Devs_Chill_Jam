using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FMODUnity;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;

public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance;

    [SerializeField] private float cartridgeSpawnWait = 5f;

    [SerializeField] private TaskInfoUI taskInfoUIPrefab;

    private List<Task> currentTasksList = new List<Task>();
    [SerializeField] private List<TasksList> taskLists = new List<TasksList>();

    public int CurrentTasksIndex = 0;
    public Transform itemSpawner;
    [SerializeField] private Transform displayTransform;
    [SerializeField] private GameObject firstCartridge;
    [SerializeField] private GameObject secondCartridge;
    [SerializeField] private List<GameObject> requiredTaskItems = new List<GameObject>();
    [SerializeField] private IngameMenu gameOverCanvas;
    [SerializeField] private StudioEventEmitter tubeSoundRef;
    [SerializeField] private StudioEventEmitter mailSoundRef;

    public bool AllTasksDone => currentTasksList.All(x => x.TaskCompleted);

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(SpawnCartridge(firstCartridge));
    }

    public IEnumerator SpawnCartridge(GameObject item)
    {
        yield return new WaitForSeconds(cartridgeSpawnWait);
        Instantiate(item, itemSpawner.position, itemSpawner.rotation);
    }

    public void CheckAllTasksDone()
    {
        if (AllTasksDone)
        {
            StartCoroutine(SpawnCartridge(secondCartridge));
            CurrentTasksIndex++;

            foreach (var task in currentTasksList)
            {
                task.RemoveTaskFromList();
            }

            currentTasksList.Clear();
            
            if (CurrentTasksIndex >= taskLists.Count)
            {
                gameOverCanvas.ShowMenu();
                return;
            }
        }
    }

    public void NextTasks()
    {
        if (!AllTasksDone)
            return;
        
        requiredTaskItems.Clear();

        foreach (var taskData in taskLists[CurrentTasksIndex].taskList)
        {
            TaskInfoUI taskInfoUI = Instantiate(taskInfoUIPrefab, displayTransform);
            taskInfoUI.SetDescription(taskData.TaskDescription);
            taskInfoUI.SetCheckmark(false);
            taskInfoUI.SetMaxProgress(taskData.AmountToComplete);
            GenerateTaskItemList(taskData);
            currentTasksList.Add(new Task(taskData, taskInfoUI));
        }

        for (int i = 0; i < currentTasksList.Count; i++)
        {
            Debug.Log(currentTasksList[i].taskItemType);
        }
        SpawnRandomizedTaskItem();
        mailSoundRef.Play();
    }

    public void TaksObjectiveDone(Item.ItemType taskType)
    {
        for (int i = 0; i < currentTasksList.Count; i++)
        {
            if (currentTasksList[i].taskItemType == taskType)
            {
                currentTasksList[i].ObjectiveDone();
            }
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
            tubeSoundRef.Play();
        }
    }
}

[Serializable]
public class TasksList
{
    public List<TaskData> taskList = new List<TaskData>();
}