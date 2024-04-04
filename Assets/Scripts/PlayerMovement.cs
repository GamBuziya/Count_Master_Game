using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private bool _moveByTouch, _gameState;
    [SerializeField] private float _playerSpeed, _roadSpeed;
    [SerializeField] private Transform _road;

    private Vector3 _mouseStartPos, playerStartPos;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        MoveThePlayer();
    }


    void MoveThePlayer()
    {
        if (Input.GetMouseButtonDown(0) && _gameState)
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

                transform.position =
                    new Vector3(Mathf.Lerp(transform.position.x, control.x, Time.deltaTime * _playerSpeed),
                        transform.position.y, transform.position.z);
            }
        }

        if (_gameState)
        {
            _road.Translate(-_road.forward * Time.deltaTime * _roadSpeed);
        }
    }
}
