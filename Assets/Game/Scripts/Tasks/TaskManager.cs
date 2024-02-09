using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskManager : MonoBehaviour
{
    private List<GameObject> taskInfoList = new List<GameObject>();
    [SerializeField] List<Task> firstDiskTasks = new List<Task>();
    [SerializeField] List<Task> secondDiskTasks = new List<Task>();
    [SerializeField] private GameObject taskInfo;

    public void NextTasks(List<Task> tasks)
    {
        for (int i = 0; i < taskInfoList.Count; i++)
        {
            Destroy(taskInfoList[i]);
        }

        taskInfoList.Clear();

        for (int i = 0; i < tasks.Count; i++)
        {
            GameObject newTask = Instantiate(taskInfo, transform);
            newTask.GetComponentInChildren<TMP_Text>().text = tasks[i].TaskDescription;
            newTask.GetComponentInChildren<Toggle>().isOn = tasks[i].TaskCompleted;
            taskInfoList.Add(newTask);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            if (other.gameObject.GetComponent<Item>().itemType == Item.ItemType.DISK)
            {
                if (other.gameObject.GetComponent<Disk>().itemFunction == Disk.ItemFunction.PART_1) NextTasks(firstDiskTasks);
                else NextTasks(secondDiskTasks);
            }
        }
    }
}