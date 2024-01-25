using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEvent : MonoBehaviour
{
    public GameObject GamePanel;
    public GameObject EventButton;
    public GameObject PauseButton;
    public Text EventText;
    enum EventsList { GameOver, LevelComplieted}
    [SerializeField] EventsList CurrentEvent;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            CheckTypeEvenet();
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            CheckTypeEvenet();
        }
    }
    private void CheckTypeEvenet()
    {
        Time.timeScale = 0;
        GamePanel.SetActive(true);
        EventButton.SetActive(true);        
        PauseButton.SetActive(false);
        if (CurrentEvent == EventsList.GameOver)
        {
            EventText.text = "Game over";
        }
        else if (CurrentEvent == EventsList.LevelComplieted)
        {
            EventText.text = "Level complieted!";
        }
    }
}