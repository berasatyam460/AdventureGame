using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [Header("Quest")]
    [SerializeField] GameObject questUI;
    [SerializeField] TMP_Text titleText;
    [SerializeField] TMP_Text descriptionText;
    [SerializeField] GameObject onCompleteQuest;
    [SerializeField] TMP_Text onCompleteQuestText;


    void Awake()
    {
        if (instance == null)
        {

            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void ShowUI()
    {
        if (QuestManager.instance.GetActiveQuest() != null)
        {

            var questDataSo = QuestManager.instance.GetActiveQuest();
            titleText.text = questDataSo.Title.ToString();
            descriptionText.text = questDataSo.LongQuestDescription.ToString();
            questUI.SetActive(true);
        }
    }
    public void HideUI()
    {
        questUI.SetActive(false);
    }


    public void ShowActiveQuestUI(QuestDataSO questDataSO)
    {
        titleText.text = questDataSO.Title.ToString();
        descriptionText.text = questDataSO.LongQuestDescription.ToString();
        questUI.SetActive(true);
    }

    public void OnCompleteQuest(QuestDataSO questDataSO)
    {
        questUI.SetActive(false);
        onCompleteQuestText.text = "Quest Completed" + questDataSO.Title.ToString();
        onCompleteQuest.SetActive(true);

    }
}
