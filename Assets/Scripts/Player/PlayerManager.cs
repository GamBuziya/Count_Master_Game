using System;
using System.Collections;
using System.Collections.Generic;
using AbstractClasses;
using DG.Tweening;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : CharactersManager
{
    
    
    public Action OnMakeStickman;
    public static PlayerManager Instance;
    
    
    private int _numberOfStickmans;

    [SerializeField] private Transform _enemy;
    
    private bool _isAttacking;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateUI();
    }

    private void Update()
    {
        if (_isAttacking)
        {
            var enemyDirection = new Vector3(_enemy.position.x, transform.position.y, _enemy.position.z) -
                                 transform.position;
            
            transform.rotation = Quaternion.Slerp(
                transform.rotation, Quaternion.LookRotation(enemyDirection, Vector3.up), Time.deltaTime * 3);

            Vector3 EnemyCordinate = _enemy.GetChild(1).GetChild(0).position; //Отримуєм координати першого ворога 

            if (_enemy.GetChild(1).childCount > 1)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    var distance = EnemyCordinate - transform.GetChild(i).position;

                    if (distance.magnitude < 1.5f)
                    {
                        
                        transform.GetChild(i).position = Vector3.Lerp(
                            transform.GetChild(i).position,
                            new Vector3(EnemyCordinate.x, transform.GetChild(i).position.y, EnemyCordinate.z),
                            Time.deltaTime * 3f);
                    }
                }
            }
        }
    }


    private void UpdateUI()
    {
        _numberOfStickmans = transform.childCount - 1;

        _counter.text = _numberOfStickmans.ToString();
    }

    
    private void UpdateNumber(bool multiply, int number)
    {
        if (multiply)
        {
            MakeStickman(_numberOfStickmans *= number);
        }
        else
        {
            MakeStickman(_numberOfStickmans += number);
        }

        UpdateUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gate"))
        {
            UpdateNumber(other.GetComponent<GateManager>().Multiply, other.GetComponent<GateManager>().Number);
        }
        else if (other.CompareTag("Enemy"))
        {
            EventManager.Instance.Attack();
            _enemy = other.transform;
            _isAttacking = true;
        }
    }
    
    private void MakeStickman(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Instantiate(_stickman, transform.position, quaternion.identity, transform);
        }
        
        OnMakeStickman?.Invoke();
        FormatStickMan();
        UpdateUI();
    }

    public int GetNumberOfStickmans()
    {
        return _numberOfStickmans;
    }

    public bool IsAttacking()
    {
        return _isAttacking;
    }
}
