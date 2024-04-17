using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private bool _moveByTouch;
    [SerializeField] private float _playerSpeed, _roadSpeed;
    

    [Header("Boarders")] 
    [SerializeField] private float _leftBoarder = 0.12f;

    [SerializeField] private float _rightBoarder = 3.42f;
    
    private Camera _camera;
    private Vector3 _mouseStartPos, playerStartPos;
    private bool _gameState = false;
    private bool _movementIsStopped;
    
    private void Start()
    {
        _camera = Camera.main;
        EventManager.Instance.OnGameStart += EventManager_OnGameStart;
    }


    private void Update()
    {
        if (_gameState && !PlayerManager.Instance.IsAttacking() && !_movementIsStopped)
        {
            MoveThePlayer(); 
        }
        
    }
    
    public bool IsMovementStopped()
    {
        return _movementIsStopped;
    }

    public void PauseMovementForDuration()
    {
        ChangeMovementState();
        Invoke("ChangeMovementState", 1f);
    }

    private void ChangeMovementState()
    {
        _movementIsStopped = !_movementIsStopped;
    }


    

    void MoveThePlayer()
    {

        if (Input.GetMouseButtonDown(0))
        {
            _moveByTouch = true;

            var plane = new Plane(Vector3.up, 0f);
            var ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (plane.Raycast(ray, out var distance))
            {
                _mouseStartPos = ray.GetPoint(distance + 1f);
                playerStartPos = transform.position;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _moveByTouch = false;
        }
        
        if (_moveByTouch)
        {
            var plane = new Plane(Vector3.up, 0f);
            var ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (plane.Raycast(ray, out var distance)) //Перевіряєм якщо промінь проходить через наш екран
            {
                var mousePos = ray.GetPoint(distance + 1f); //Отримуєм точку де наш гравець тицьнув на екран

                var move = mousePos - _mouseStartPos; //Для отримання напрямку та зміни вектора 

                var control = playerStartPos + move; // Для отримання позиції гравця

                if (PlayerManager.Instance.GetNumberOfStickmans() >= 20)
                {
                    control.x = Mathf.Clamp(control.x, _leftBoarder + 0.5f, _rightBoarder - 0.5f);
                }
                else
                {
                    control.x = Mathf.Clamp(control.x, _leftBoarder, _rightBoarder);
                }
                

                transform.position =
                    new Vector3(Mathf.Lerp(transform.position.x, control.x, Time.deltaTime * _playerSpeed),
                        transform.position.y, transform.position.z);
            }
        }
        
        
    }
    
    private void EventManager_OnGameStart()
    {
        _gameState = true;
    }
    
}
