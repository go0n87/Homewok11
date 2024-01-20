using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int IndexScene;
    public void OnClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(IndexScene);
    }
}
