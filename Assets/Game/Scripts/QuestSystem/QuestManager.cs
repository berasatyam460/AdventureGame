using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private readonly Dictionary<int, QuestDataSO> activeQuests = new();

    void OnEnable()
    {

    }


    private void ActivateQuest(QuestDataSO questToActive)
    {
        if (!activeQuests.ContainsKey(questToActive.questID))
        {
            activeQuests.Add(questToActive.questID, questToActive);
            Debug.Log("QuestsStarted");
        }
    }


    private void UpdateQuestStatus(QuestDataSO questToActive, int amount)
    {
        foreach (var quest in activeQuests)
        {

        }
    }
}
