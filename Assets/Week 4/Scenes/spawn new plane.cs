using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class spawnnewplane : MonoBehaviour
{
    public GameObject planesPrefab;

    private float timer;
    private float lastSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.deltaTime;

        if (timer >= lastSpawn + Random.Range(1, 5))
        { 
            Instantiate(planesPrefab, transform.position, transform.rotation);
            lastSpawn = timer;
        }
    }
}
