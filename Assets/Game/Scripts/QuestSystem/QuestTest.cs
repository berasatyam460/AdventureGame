using UnityEngine;

public class QuestTest : MonoBehaviour
{
    [SerializeField] QuestDataSO questToActive;
    bool isquestActivated = false;
    [SerializeField] int questNo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!isquestActivated)
            {
                ActionManger.ActivateQuest?.Invoke(questToActive);
                isquestActivated = true;
            }
            else
            {
                ActionManger.UpdateQuestData?.Invoke(questToActive, 1, questNo);

            }
        }
    }
}
