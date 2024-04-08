using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerStickmanManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "EnemyCharacter":
            {
                transform.parent.gameObject.GetComponent<PlayerManager>().MinusStickman();
                other.transform.parent.gameObject.GetComponent<EnemyManager>().MinusStickman();
                Destroy(gameObject);
                Destroy(other.gameObject);
                break;
            }
            case "Ramp":
            {
                transform.DOJump(transform.position, 1.5f, 1, 1f)
                    .SetEase(Ease.Flash);
                break;
            }
        }
    }
}
