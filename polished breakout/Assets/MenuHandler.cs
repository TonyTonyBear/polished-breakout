using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public void TransitionToGameplay()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void TransitionToSettings()
    {
        Debug.Log("Show settings");
    }

    public void TransitionToStats()
    {
        Debug.Log("Show Stats");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
