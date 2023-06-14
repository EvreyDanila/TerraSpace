using System;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static event Action RightSwipeCard;
    public static event Action LeftSwipeCard;
    public static event Action MidlePointerCard;
    public static event Action<string> UseCard;
    public static event Action SwitchingDone;
    public static event Action GameOverLose;
    public static event Action GameOverWin;

    public static void OnRightSwipeCard()
    {
        RightSwipeCard?.Invoke();
    }

    public static void OnLeftSwipeCard()
    {
        LeftSwipeCard?.Invoke();
    }

    public static void OnMidlePointerCard()
    {
        MidlePointerCard?.Invoke();
    }

    public static void OnUseCard(string choise)
    {
        UseCard?.Invoke(choise);
    }

    public static void OnSwitchingDone()
    {
        SwitchingDone?.Invoke();
    }

    public static void OnGameOverLose()
    {
        GameOverLose?.Invoke();
    }

    public static void OnGameOverWin()
    {
        GameOverWin?.Invoke();
    }
}