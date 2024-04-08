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

    public bool IsPlaying;

    private void Awake()
    {
        CharacterAnimator = GetComponent<PlayerAnimating>();
        Instance = this;
    }

    private void Start()
    {
        EventManager.Instance.OnGameStart += () =>
        {
            Debug.Log("IsPlaying = true;");
            IsPlaying = true;
        };

        EventManager.Instance.OnGameOver += () =>
        {
            Debug.Log("IsPlaying = false;");
            IsPlaying = false;
        };
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

            
            if (_enemy.GetChild(1).childCount > 1)
            {
                var enemyCoordinate = _enemy.GetChild(1).GetChild(0).position;
                
                for (int i = 0; i < transform.childCount; i++)
                {
                    if(transform.GetChild(i).CompareTag("OtherObj")) continue;
                    
                    var distance = enemyCoordinate - transform.GetChild(i).position;

                    if (distance.magnitude < 2f)
                    {
                        
                        transform.GetChild(i).position = Vector3.Lerp(
                            transform.GetChild(i).position,
                            new Vector3(enemyCoordinate.x, transform.GetChild(i).position.y, enemyCoordinate.z), 
                            Time.deltaTime * 1f);
                    }
                }
            }
            else
            {
                _isAttacking = false;
                _enemy.gameObject.SetActive(false);
            }
        }
        else
        {
            if (transform.childCount > 1f)
            {
                if (transform.GetChild(1).rotation != Quaternion.identity)
                {
                    for (int i = 0; i < transform.childCount; i++)
                    {
                        transform.GetChild(i).rotation = Quaternion.identity;
                    }
                    FormatStickMan();
                }
            }
        }
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
            var enemyManager = other.GetComponentInChildren<EnemyManager>();
            enemyManager.StartAnimation();
            enemyManager.Attack(transform);
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
