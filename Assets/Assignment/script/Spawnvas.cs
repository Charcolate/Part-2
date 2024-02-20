using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnvas : MonoBehaviour
{
    //get a class and components
    public GameObject vasePrefab;
    public float spawnInterval = 2f;

    private float timer;

    void Start()
    {
        timer = 0f;
    }

    void Update()
    {
        //set the timer for spawning
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnVase();
            timer = 0f;
        }
    }

    void SpawnVase()
    {
        //Get screen boundaries in world coordinates
        Vector2 bottomLeft = Camera.main.ScreenToWorldPoint(Vector3.zero);
        Vector2 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        //generate the spawn position
        Vector2 spawnPosition1 = new Vector2(Random.Range(bottomLeft.x, topRight.x), Random.Range(bottomLeft.y, topRight.y)); // Changed
        Vector2 spawnPosition2 = new Vector2(Random.Range(bottomLeft.x, topRight.x), Random.Range(bottomLeft.y, topRight.y)); // Changed

        //Spawn vases at the random positions
        Instantiate(vasePrefab, spawnPosition1, Quaternion.identity); // Changed
        Instantiate(vasePrefab, spawnPosition2, Quaternion.identity); // Changed

    }
}
