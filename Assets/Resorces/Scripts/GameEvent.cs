using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEvent : MonoBehaviour
{
    public GameObject GamePanel;
    public GameObject EventButton;
    public GameObject PauseButton;
    public GameObject ExplosionEffect;
    public Text EventText;
    enum EventsList { GameOver, LevelComplieted, GameComplieted}
    [SerializeField] EventsList CurrentEvent;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            if (CurrentEvent == EventsList.GameOver)
            {
                DestroyPlayer(other.gameObject);
            }
            else if (CurrentEvent == EventsList.GameComplieted)
            {
                CheckTypeEvenet(false);
                ExplosionEffect.GetComponent<ParticleSystem>().Play();
                Destroy(other.gameObject);
            }
            else
            {
                CheckTypeEvenet(true);
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            if (CurrentEvent == EventsList.GameOver)
            {
                DestroyPlayer(collision.gameObject);
            }
            else
            {
                CheckTypeEvenet(true);
            }            
        }
    }
    private void CheckTypeEvenet(bool _stopTime)
    {
        if (_stopTime) {Time.timeScale = 0;}      
        GamePanel.SetActive(true);               
        PauseButton.SetActive(false);
        if (CurrentEvent == EventsList.GameOver)
        {
            EventButton.SetActive(true);
            EventText.text = "Game over";
        }
        else if (CurrentEvent == EventsList.LevelComplieted)
        {
            EventButton.SetActive(true);
            EventText.text = "Level complieted!";
        }
        else if (CurrentEvent == EventsList.GameComplieted)
        {            
            EventText.text = "Congratulations! You won the game!";
        }
    }
    private void DestroyPlayer(GameObject _playerObject)
    {
        Instantiate(ExplosionEffect,
        _playerObject.transform.position,
        _playerObject.transform.rotation);       
        Destroy(_playerObject);
        StartCoroutine(WaitDestroyEffect());
    }
    private IEnumerator WaitDestroyEffect()
    {
        yield return new WaitForSeconds(3);

        Destroy(ExplosionEffect);
        CheckTypeEvenet(true);
    }
}