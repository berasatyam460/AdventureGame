using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public readonly Dictionary<int, QuestDataSO> activeQuests = new();

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
            UIManager.instance.ShowActiveQuestUI(questToActive);
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
                    var currentQuest = quest.quests[questNo];
                    if (currentQuest.CurrentAmount < currentQuest.RequiredAmount)
                    {
                        quest.quests[questNo].CurrentAmount += amount;
                        Debug.Log($"Updated {quest.Title}: Goal {questNo} → {quest.quests[questNo].CurrentAmount}/{quest.quests[questNo].RequiredAmount}");
                    }
                }

                if (quest.IsCompleted())
                {
                    Debug.Log($"Quest Completed: {quest.Title}");

                    UIManager.instance.OnCompleteQuest(questToActive);
                    // TODO: give reward
                }
            }
        }
    }

}
