using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu]
public class TaskData : ScriptableObject
{
    public string TaskDescription;
    [FormerlySerializedAs("ObjectivesAmount")] public int AmountToComplete;
    public Item.ItemType ObjectiveItemType;
}