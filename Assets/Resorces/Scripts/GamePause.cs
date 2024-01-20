using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePause : MonoBehaviour
{
    public Sprite PauseButton;
    public Sprite PlayButton;
    public GameObject MenuPanel;
    private Image _currentImage;
    private bool _isPause = false;

    private void Start()
    {
        _currentImage = GetComponent<Image>();
    }

    public void OnClickPause()
    {
        if (_isPause)
        {
            Time.timeScale = 1;
            _currentImage.sprite = PlayButton;
        }
        else
        {
            Time.timeScale = 0;
            _currentImage.sprite = PauseButton;
        }

        MenuPanel.SetActive(!_isPause);
        _isPause = !_isPause;
    }
}
