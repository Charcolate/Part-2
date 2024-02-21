using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footballplayer : MonoBehaviour
{
    public SpriteRenderer playerselect;
    Rigidbody2D rb;
    public float speed = 100;
    public Color selectColour;
    public Color unselectedColour;

    void Start()
    {
        playerselect = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        Selected(false);
    }

    private void OnMouseDown ()
    {
        BallplayerControler.SetCurrentSelection(this);
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

    public void Move(Vector2 directiion)
    {
        rb.AddForce(directiion * speed, ForceMode2D.Impulse);
    }

}


