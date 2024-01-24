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
    public string NameEvent;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Time.timeScale = 0;
            EventText.text = NameEvent;
            EventButton.SetActive(true);
            GamePanel.SetActive(true);
            PauseButton.SetActive(false);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Time.timeScale = 0;
            EventText.text = NameEvent;
            EventButton.SetActive(true);
            GamePanel.SetActive(true);
            PauseButton.SetActive(false);
        }
    }
}