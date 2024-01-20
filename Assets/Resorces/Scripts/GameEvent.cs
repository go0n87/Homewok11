using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEvent : MonoBehaviour
{
    public GameObject GamePanel;
    public Text EventText;
    public string NameEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Time.timeScale = 0;
            EventText.text = NameEvent;
            GamePanel.SetActive(true);
        }
    }
}
