
using System;
using UnityEngine;
using UnityEngine.Android;


public static class ActionManger
{
    public static Action<bool> DoInteract;
    public static Action<Transform> headTrackingON;
    public static Action headTrackOff;

    public static Action<bool, int, GameObject> AnimationType;

    public static Action<InteractionTypes> InteractAnimFinish;


    #region  Quest
    public static Action GiveQuest;
    public static Action<QuestDataSO, int, int> UpdatingQuestStatus;
    #endregion

    [Header("QuestTest")]
    public static Action<QuestDataSO> ActivateQuest;
    public static Action<QuestDataSO, int, int> UpdateQuestData;


}

public enum InteractionTypes
{
    GrabTorch,
    Ignite
}
