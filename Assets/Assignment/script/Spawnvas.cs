using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnvas : MonoBehaviour
{
    public GameObject vasePrefab;
    public float spawnRangeX = 5f;
    public float spawnRangeY = 5f;
    public float spawnInterval = 2f;

    private float timer;

    void Start()
    {
        timer = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnVase();
            timer = 0f;
        }
    }

    void SpawnVase()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPosition = new Vector3(randomX, spawnRangeY, 0f) + transform.position;

        GameObject vase = Instantiate(vasePrefab, spawnPosition, Quaternion.identity);
    }
}
