using System;
using System.Collections;
using System.Collections.Generic;
using AbstractClasses;
using DefaultNamespace;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : CharactersManager
{
    [SerializeField] private int NumberOfStickmans;
    private void Start()
    {
        EventManager.Instance.OnGameOver += GameOver;


        _enemy = GameObject.Find("Player").GetComponent<Transform>();
        
        CharacterAnimator = GetComponent<EnemyAnimating>();

        if (NumberOfStickmans == 0)
        {
            _numberOfStickmans = 10;
        }
        else
        {
            _numberOfStickmans = NumberOfStickmans;
        }
        
        
        for (int i = 0; i < _numberOfStickmans; i++)
        {
            Instantiate(_stickman, transform.position, new Quaternion(0f, 180f, 0f, 1f), transform);
        }
        
        
        FormatStickMan();
        _counter.text = (transform.childCount - 1).ToString();
    }

    private void Update()
    {
        if (_isAttacking)
        {
            var enemyDirection = _enemy.position - transform.position;
            
            
            for (int i = 0; i < transform.childCount; i++)
            {
                if(transform.GetChild(i).CompareTag("OtherObj")) continue;
                
                transform.GetChild(i).rotation = Quaternion.Slerp(
                    transform.GetChild(i).rotation,
                    quaternion.LookRotation(enemyDirection, Vector3.up),
                    Time.deltaTime * 1f);

                if(_enemy.childCount <= 1) continue; 
                
                var distance = _enemy.GetChild(1).position - transform.GetChild(i).position;

                if (distance.magnitude < 2f)
                {
                    transform.GetChild(i).position = Vector3.Slerp(
                        transform.GetChild(i).position, 
                        _enemy.GetChild(1).position, 
                        Time.deltaTime * 2f);
                }
            }
            
            if (_enemy.GetComponent<PlayerManager>().GetNumberOfStickmans() <= 1)
            {
                EventManager.Instance.GameOver();
            }
        }
        
        
        
    }

    public void Attack(Transform enemyForce)
    {
        _isAttacking = true;
    }

    public void StartAnimation()
    {
        GetComponent<EnemyAnimating>().ActivateAnimation();
    }

    public void GameOver()
    {
        CharacterAnimator.StopAnimating();
        for (int i = 0; i < _enemy.childCount; i++)
        {
            _enemy.gameObject.SetActive(false);
        }
    }
    
    
}
