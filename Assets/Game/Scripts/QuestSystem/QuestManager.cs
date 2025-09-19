using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    public readonly Dictionary<int, QuestDataSO> activeQuests = new();
    private bool isQuestActivate;

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

    void Awake()
    {
        instance = this;
    }


    private void ActivateQuest(QuestDataSO questToActive)
    {
        if (!activeQuests.ContainsKey(questToActive.questID) && !isQuestActivate)
        {
            activeQuests.Add(questToActive.questID, questToActive);
            Debug.Log("QuestsStarted" + questToActive.Title);
            UIManager.instance.ShowActiveQuestUI(questToActive);
            isQuestActivate = true;
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
                    isQuestActivate = false;
                    activeQuests.Remove(quest.questID);

                    // TODO: give reward
                }
            }
        }
    }

    public QuestDataSO GetActiveQuest()
    {
        // return first quest if any
        foreach (var quest in activeQuests.Values)
        {
            return quest; // returns the first one it finds
        }
        return null; // no active quest
    }

}
