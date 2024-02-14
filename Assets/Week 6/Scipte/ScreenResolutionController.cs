using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenResolutionController : MonoBehaviour
{
    public void ChangeResolution1()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.Windowed);
    }
}
