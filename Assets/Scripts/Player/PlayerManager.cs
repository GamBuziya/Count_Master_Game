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
    
    
    private bool _minusStickmansInvoked = false;

    private void Awake()
    {
        CharacterAnimator = GetComponent<PlayerAnimating>();
        Instance = this;
    }

    private void Start()
    {
        EventManager.Instance.OnGameStart += () =>
        {
            IsPlaying = true;
        };

        EventManager.Instance.OnGameOver += () =>
        {
            IsPlaying = false;
        };
        UpdateUI();
    }

    private void Update()
    {
        //Це треба всунути в окремий клас 
        if (_isAttacking)
        {
            var enemyDirection = new Vector3(_enemy.position.x, transform.position.y, _enemy.position.z) -
                                 transform.position;

            if (_enemy.childCount > 1)
            {
                var enemyCoordinate = _enemy.GetChild(1).GetChild(0).position;
                
                for (int i = 0; i < transform.childCount; i++)
                {
                    if(transform.GetChild(i).CompareTag("OtherObj")) continue;
                    
                    transform.GetChild(i).rotation = Quaternion.Slerp(
                        transform.GetChild(i).rotation, 
                        Quaternion.LookRotation(enemyDirection, Vector3.up), 
                        Time.deltaTime * 3);
                    
                    
                    var distance = enemyCoordinate - transform.GetChild(i).position;

                    if (distance.magnitude < 1.5f)
                    {
                        
                        transform.GetChild(i).position = Vector3.Lerp(
                            transform.GetChild(i).position,
                            new Vector3(enemyCoordinate.x, transform.GetChild(i).position.y, enemyCoordinate.z), 
                            Time.deltaTime * 1f);
                    }
                }
                
                if (!_minusStickmansInvoked)
                {
                    MinusStickmans();
                    _minusStickmansInvoked = true;
                }
                
            }
            else
            {
                _minusStickmansInvoked = false;
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
                        if(transform.GetChild(i).CompareTag("OtherObj")) continue;
                        transform.GetChild(i).rotation = Quaternion.identity;
                    }
                    FormatStickMan();
                }
            }
        }
        //Це все
    }

    private void MinusStickmans()
    {
        if (_enemy == null)
        {
            Debug.LogWarning("Can not delete stickmans, don't have an enemy object");
            return;
        }

        var countToDelete = Mathf.Min(_numberOfStickmans, _enemy.gameObject.GetComponent<EnemyManager>().GetNumberOfStickmans());

        DeleteStickmansCoroutine(countToDelete);
    }

    private void DeleteStickmansCoroutine(int count)
    {
        Debug.Log(count);
        var i = 0;
        while(i < count)
        {
            Invoke("DeleteWithInvoke", 0.1f * i);
            i++;
        }
        
    }

    private void DeleteWithInvoke()
    {
        _enemy.gameObject.GetComponent<EnemyManager>().DestroyOneStickman();
        DestroyOneStickman();
    }


    private void UpdateNumber(bool multiply, int number)
    {
        var temp = 0;

        if (multiply)
        {
            temp = (_numberOfStickmans * number) - _numberOfStickmans;
        }
        else
        {
            temp = number;
        }
        
        for (int i = 0; i < temp; i++)
        {
            Instantiate(_stickman, transform.position, Quaternion.identity, transform);
        }
    
        OnMakeStickman?.Invoke();
        FormatStickMan();

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
            _enemy = enemyManager.transform;
            _isAttacking = true;
        }
    }
    

    public bool IsAttacking()
    {
        return _isAttacking;
    }
}
