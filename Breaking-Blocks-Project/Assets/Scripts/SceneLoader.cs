using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex;

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().resetGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
