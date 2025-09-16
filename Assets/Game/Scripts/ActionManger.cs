
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
}

public enum InteractionTypes
{
    GrabTorch,
    Ignite
}
