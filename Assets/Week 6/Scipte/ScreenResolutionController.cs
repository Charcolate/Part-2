using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenResolutionController : MonoBehaviour
{
    public void LoadNextscene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void ChangeResolution1()
    {
        Screen.SetResolution(1920, 1200, FullScreenMode.Windowed);
    }

    public void ChangeResolution2()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.Windowed);
    }
}
