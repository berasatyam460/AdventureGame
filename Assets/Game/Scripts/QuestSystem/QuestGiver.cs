using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] QuestDataSO questToGive;

    void GiveQuest()
    {
        ActionManger.ActivateQuest?.Invoke(questToGive);
    }

}
