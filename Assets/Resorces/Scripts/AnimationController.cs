using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Material GreenMaterial;
    public GameObject TextMessage;
    private bool _isOpen = false;
    private bool _inTrigger = false;
    public Animator _anim;
    enum EventsList { DoorOpen, StopMill }
    [SerializeField] EventsList CurrentEvent;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _inTrigger)
        {
            if (!_isOpen)
            {
                if (CurrentEvent == EventsList.DoorOpen)
                {
                    _anim.SetTrigger("isOpen");
                }
                else if (CurrentEvent == EventsList.StopMill)
                {
                    _anim.speed = 0;
                }                    
                GetComponent<Renderer>().material = GreenMaterial;
                _isOpen = true;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball" && _isOpen == false)
        {
            TextMessage.SetActive(true);
            _inTrigger = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            TextMessage.SetActive(false);
            _inTrigger = false;
        }
    }
}
