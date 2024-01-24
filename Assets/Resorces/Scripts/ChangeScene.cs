using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int IndexScene;
    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(IndexScene);
    }
    public void Retry()
    {        
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(IndexScene);
    }
}
