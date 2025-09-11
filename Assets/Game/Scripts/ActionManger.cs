
using System;
using UnityEngine;
using UnityEngine.Android;


public static class ActionManger
{
    public static Action<bool> DoInteract;
    public static System.Action<Transform> headTrackingON;
    public static System.Action headTrackOff;

    public static System.Action<bool, int, GameObject> AnimationType;
}
