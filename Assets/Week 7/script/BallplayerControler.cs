using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallplayerControler : MonoBehaviour
{

    public static BallplayerControler CurrentSelection { get; private set; }

    public static void SetCurrentSelection (Footballplayer player)
    {
        if (CurrentSelection != null)
        {
            CurrentSelection.Selected(false);
        }
        CurrentSelection = player;
        CurrentSelection.Selected(true);
    }

}
