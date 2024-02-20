using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenLerp : MonoBehaviour
{
    //get a class and components
    public AnimationCurve animationcurve;
    public Transform start;
    public Transform end;
    public float lerp;
    public float interpolation;
    public SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //make the character zoom from left to right of the screen
        interpolation = animationcurve.Evaluate(lerp);
        transform.position = Vector3.Lerp(start.position, end.position, interpolation);
        lerp = lerp + Time.deltaTime;
    }   
}
