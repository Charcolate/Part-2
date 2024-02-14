using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Lerp : MonoBehaviour
{
    public AnimationCurve animationcurve;
    public Transform startposition;
    public Transform endposition;
    public float lerptime;
    public float interpolation;
    public Color cola;
    public Color colb;
    public SpriteRenderer sr; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {interpolation = animationcurve.Evaluate(lerptime);
        transform.position = Vector3.Lerp(startposition.position, endposition.position, interpolation);
        lerptime = lerptime + Time.deltaTime;
        sr.color = Color.Lerp(cola, colb, interpolation);
    }
}
