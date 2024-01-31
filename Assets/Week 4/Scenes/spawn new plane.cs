using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class spawnnewplane : MonoBehaviour
{
    public GameObject planesPrefab;
    public Transform Spawn;
    private float timer = 0f;
    private float lastSpawn;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= lastSpawn)
        { 
            lastSpawn = Random.Range(1f, 5f);
            timer = 0f;
            Instantiate(planesPrefab);
        }
    }
}

