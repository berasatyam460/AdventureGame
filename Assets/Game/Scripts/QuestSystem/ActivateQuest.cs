using UnityEngine;

public class ActivateQuest : MonoBehaviour
{
    [SerializeField] QuestSO questSO;
    [SerializeField] int IDToActivateQuest;
    string shortdes;
    private QuestStatus questStatus = QuestStatus.Initiated;
    private void OnTriggerEnter(Collider other)
    {
        if (questStatus == QuestStatus.Initiated)
        {
            questStatus = QuestStatus.Running;
            shortdes = questSO.quests[IDToActivateQuest].ShortQuestDescription;
            Debug.Log(shortdes);
        }
    }
}

public enum QuestStatus
{
    Initiated,
    Running,
    Completed
}
