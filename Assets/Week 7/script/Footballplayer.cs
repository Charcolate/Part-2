using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footballplayer : MonoBehaviour
{
    public SpriteRenderer playerselect;

    void Start()
    {
        if (playerselect != null)
        {
            playerselect.color = Color.red;
        }
    }

    private void OnMouseDown ()
    {
        if (playerselect != null)
        {
            playerselect.color = Color.green; 
        }
    }

    public void Select(bool isSelected)
    {
        if (playerselect != null)
        {
            playerselect.color = isSelected ? Color.green : Color.red;
        }
    }

}


