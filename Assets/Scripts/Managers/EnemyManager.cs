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
    private void Start()
    {
        for (int i = 0; i < Random.Range(5, 100); i++)
        {
            Instantiate(_stickman, transform.position, new Quaternion(0f, 180f, 0f, 1f), transform);
        }
        
        FormatStickMan();
        _counter.text = (transform.childCount - 1).ToString();
    }

    private void Update()
    {
        if (_isAttacking && transform.childCount > 1)
        {
            var enemyDirection = _enemy.position - transform.position;
            
            
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).rotation = Quaternion.Slerp(
                    transform.GetChild(i).rotation,
                    quaternion.LookRotation(enemyDirection, Vector3.up),
                    Time.deltaTime * 1f);

                var distance = _enemy.GetChild(1).position - transform.GetChild(i).position;

                if (distance.magnitude < 2f)
                {
                    transform.GetChild(i).position = Vector3.Slerp(
                        transform.GetChild(i).position, 
                        _enemy.GetChild(1).position, 
                        Time.deltaTime * 2f);
                }
            }
        }
    }

    public void Attack(Transform enemyForce)
    {
        _enemy = enemyForce;
        _isAttacking = true;
    }

    public void StartAnimation()
    {
        GetComponent<EnemyAnimating>().RunAnimation();
    }
}
