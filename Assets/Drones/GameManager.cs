using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public DroneController _DroneController;

    public Button _FlyButton;
    public Button _LandButton;
    public GameObject _Controls;
    struct DroneAnimationControls
    {
        public bool _moving;
        public bool _interpolatingAsc;
        public bool _interpolatingDesc;
        public float _axis;
        public float _direction;
    }

    DroneAnimationControls _MovingLeft;
    DroneAnimationControls _MovingBack;

    // Start is called before the first frame update
    void Start()
    {
        _FlyButton.onClick.AddListener(EventOnClickFlyButton);
        _LandButton.onClick.AddListener(EventOnClickLandButton);

    }
    // Update is called once per frame
    void Update()
    {
        //float speedX = Input.GetAxis("Horizontal");
        //float speedZ = Input.GetAxis("Vertical");

        UpdateControls(ref _MovingLeft);
        UpdateControls(ref _MovingBack);

        _DroneController.Move(_MovingLeft._axis * _MovingLeft._direction, _MovingBack._axis * _MovingBack._direction);
    }
    void UpdateControls(ref DroneAnimationControls _controls)
    {
        if(_controls._moving || _controls._interpolatingAsc || _controls._interpolatingDesc)
        {
            if (_controls._interpolatingAsc)
            {
                _controls._axis += 0.05f;

                if(_controls._axis >= 1.0f)
                {
                    _controls._axis = 1.0f;
                    _controls._interpolatingAsc = false;
                    _controls._interpolatingDesc = false;
                }
            }
            else if (!_controls._moving) 
            {
                _controls._axis -= 0.5f;

                if(_controls._axis <- 0.0f)
                {
                    _controls._axis = 0.0f;
                    _controls._interpolatingDesc = false;
                }
            }
        }
    }
    void EventOnClickFlyButton()
    {
        if(_DroneController.IsIdle())
        {
            _DroneController.TakeOff();
            _FlyButton.gameObject.SetActive(false);
            _Controls.SetActive(true);
        }
    }

    void EventOnClickLandButton()
    {
        if(_DroneController.IsFlying())
        {
            _DroneController.Land();
            _FlyButton.gameObject.SetActive(true);
            _Controls.SetActive(false);
        }
    }

    //Left Button
    public void EventOnLeftButtonPress()
    {
        _MovingLeft._moving = true;
        _MovingLeft._interpolatingAsc = true;
        _MovingLeft._direction = -1.0f;
    }

    public void EventOnLeftButtonReleased()
    {
        _MovingLeft._moving = false;
    }

    //Right Button
    public void EventOnRightButtonPressed()
    {
        _MovingLeft._moving = true;
        _MovingLeft._interpolatingAsc = true;
        _MovingLeft._direction = 1.0f;
    }

    public void EventOnRightButtonReleased()
    {
        _MovingLeft._moving= false;
    }

    //Back Button
    public void EventOnBackButtonPressed()
    {
        _MovingBack._moving = true;
        _MovingBack._interpolatingAsc = true;
        _MovingBack._direction = -1.0f;
    }

    public void EventOnBackButtonReleased()
    {
        _MovingBack._moving= false;
    }


    //Forward Button
    public void EventOnForwardButtonPressed()
    {
        _MovingBack._moving = true;
        _MovingBack._interpolatingAsc = true;
        _MovingBack._direction = 1.0f;
    }

    public void EventOnForwardButtonReleased()
    {
        _MovingBack._moving = false;
    }
}