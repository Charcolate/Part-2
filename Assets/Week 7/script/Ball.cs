using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Transform kickoffSpot;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider collide)
    {
        if (collide.CompareTag("Goal"))
        {
            transform.position = kickoffSpot.position;
            rb.velocity = Vector2.zero;
        }
    }
}
