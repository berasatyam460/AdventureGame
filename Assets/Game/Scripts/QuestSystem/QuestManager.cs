using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private readonly Dictionary<int, QuestDataSO> activeQuests = new();

    void OnEnable()
    {
        ActionManger.ActivateQuest += ActivateQuest;
        ActionManger.UpdateQuestData += UpdateQuestStatus;
    }

    void OnDisable()
    {
        ActionManger.ActivateQuest -= ActivateQuest;
        ActionManger.UpdateQuestData -= UpdateQuestStatus;
    }


    private void ActivateQuest(QuestDataSO questToActive)
    {
        if (!activeQuests.ContainsKey(questToActive.questID))
        {
            activeQuests.Add(questToActive.questID, questToActive);
            Debug.Log("QuestsStarted" + questToActive.Title);
        }
    }


    private void UpdateQuestStatus(QuestDataSO questToActive, int amount, int questNo)
    {
        if (activeQuests.TryGetValue(questToActive.questID, out var quest))
        {
            if (questNo < quest.quests.Count)
            {

                if (!quest.IsCompleted())
                {

                    quest.quests[questNo].CurrentAmount += amount;
                    Debug.Log($"Updated {quest.Title}: Goal {questNo} → {quest.quests[questNo].CurrentAmount}/{quest.quests[questNo].RequiredAmount}");
                }

                if (quest.IsCompleted())
                {
                    Debug.Log($"Quest Completed: {quest.Title}");
                    // TODO: give reward
                }
            }
        }
    }

}
