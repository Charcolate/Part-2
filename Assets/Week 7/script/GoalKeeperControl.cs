using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalKeeperControl : MonoBehaviour
{
    public Transform centerOfGoal;
    public Transform selectedPlayer;
    public float distanceOffGoalLine = 2.0f; // default distance off the goal line

    private Rigidbody goalkeeperRigidbody;

    void Start()
    {
        goalkeeperRigidbody = GetComponent<Rigidbody>();
        if (centerOfGoal == null)
        {
            Debug.LogError("Center of goal is not assigned!");
        }
        if (selectedPlayer == null)
        {
            Debug.LogError("Selected player is not assigned!");
        }
    }

    void Update()
    {
        if (goalkeeperRigidbody == null || centerOfGoal == null || selectedPlayer == null)
        {
            return;
        }

        // Get a reference to the Goalkeeper’s rigidbody (Already done in Start)

        // Set the Goalkeeper’s position to be on the line between the centre of the goal and the currently selected Player
        Vector3 goalToPlayer = selectedPlayer.position - centerOfGoal.position;
        Vector3 desiredPosition = centerOfGoal.position + goalToPlayer.normalized * distanceOffGoalLine;

        // Set the Goalkeeper's position
        goalkeeperRigidbody.MovePosition(desiredPosition);
    }
}
