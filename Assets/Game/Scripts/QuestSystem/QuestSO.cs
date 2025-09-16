using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Adventure_Game/QuestSO")]
public class QuestSO : ScriptableObject
{
    public List<Quest> quests = new List<Quest>();
}

[System.Serializable]
public class Quest
{
    public int QuestID;

    public string ShortQuestDescription;
    [TextArea(3, 10)]
    public string LongQuestDescription;

}

