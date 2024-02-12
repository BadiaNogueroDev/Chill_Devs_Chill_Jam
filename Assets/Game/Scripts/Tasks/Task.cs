public class Task
{
    private TaskData taskData;
    private TaskInfoUI taskInfoUI;
    public bool TaskCompleted { get; private set; }
    public int currentObjectiveCount = 0;
    public Item.ItemType taskItemType;
    
    public Task(TaskData taskData, TaskInfoUI taskInfoUI)
    {
        this.taskData = taskData;
        this.taskInfoUI = taskInfoUI;
        TaskCompleted = false;
        taskItemType = taskData.ObjectiveItemType;
    }

    public void ObjectiveDone()
    {
        currentObjectiveCount++;
        taskInfoUI.UpdateProgress(currentObjectiveCount);
        if (TaskCompleted = currentObjectiveCount >= taskData.AmountToComplete) taskInfoUI.SetCheckmark(true);
        UnityEngine.Debug.Log("Task: " + taskData.name + ". Progress: " + currentObjectiveCount + "/" + taskData.AmountToComplete);
    }
    
    public void RemoveTaskFromList()
    {
        taskInfoUI.Destroy();
    }
}