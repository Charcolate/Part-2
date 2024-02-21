using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footballplayer : MonoBehaviour
{
    public SpriteRenderer playerselect;
    public Color selectColour;
    public Color unselectedColour;

    void Start()
    {
        playerselect = GetComponent<SpriteRenderer>();
        Selected(false);
    }

    private void OnMouseDown ()
    {
        ControllerColliderHit.SetCurrentSelection(this);
    }

    public void Selected(bool isSelected)
    {
        if (isSelected)
        {
            playerselect.color = selectColour;
        }
        else
        {
            playerselect.color = unselectedColour;
        }
    }

}


