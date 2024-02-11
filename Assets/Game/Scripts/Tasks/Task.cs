public class Task
{
    private TaskData taskData;
    private TaskInfoUI taskInfoUI;
    public bool TaskCompleted { get; private set; }
    public int currentObjectiveCount = 0;
    
    public Task(TaskData taskData, TaskInfoUI taskInfoUI)
    {
        this.taskData = taskData;
        this.taskInfoUI = taskInfoUI;
        TaskCompleted = false;
    }

    public void ObjectiveDone()
    {
        currentObjectiveCount++;
        TaskCompleted = currentObjectiveCount >= taskData.AmountToComplete;
    }
    
    public void RemoveTaskFromList()
    {
        taskInfoUI.Destroy();
    }
}
