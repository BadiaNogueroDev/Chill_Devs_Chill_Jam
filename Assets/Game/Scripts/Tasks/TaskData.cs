using UnityEngine;
using UnityEngine.Serialization;
using System.Collections.Generic;

[CreateAssetMenu]
public class TaskData : ScriptableObject
{
    public string TaskDescription;
    public int AmountToComplete;
    public Item.ItemType ObjectiveItemType;
    public List<GameObject> requiredItem = new List<GameObject>();
}