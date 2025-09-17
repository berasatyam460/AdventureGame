using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Adventure_Game/QuestSO")]
public class QuestDataSO : ScriptableObject
{
    public int questID;
    public string Title;
    [TextArea(3, 10)]
    public string LongQuestDescription;
    public List<Quest> quests = new List<Quest>();

    public bool IsCompleted()
    {
        foreach (var quest in quests)
        {
            if (!quest.IsCompleted())
                return false;
        }
        return true;
    }
}

[System.Serializable]
public class Quest
{
    public int UniqueQuestId;
    public int RequiredAmount;
    public int CurrentAmount;
    public ObjectiveTypes objectiveTypes;
    public bool IsCompleted() => CurrentAmount >= RequiredAmount;

}
public enum ObjectiveTypes
{
    Inspect,
    Kill,
    Collect,
    Talk
}

