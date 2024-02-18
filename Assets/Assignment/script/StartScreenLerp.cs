using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenLerp : MonoBehaviour
{
    public AnimationCurve animationcurve;
    public Transform startposition;
    public Transform endposition;
    public float lerptime;
    public float interpolation;
    public SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        interpolation = animationcurve.Evaluate(lerptime);
        transform.position = Vector3.Lerp(startposition.position, endposition.position, interpolation);
        lerptime = lerptime + Time.deltaTime;
    }
}
