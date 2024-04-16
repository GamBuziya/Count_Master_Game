using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerStickmanManager : MonoBehaviour
{
    private bool _isStopMovement;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Ramp":
            {
                var playerMovement = PlayerManager.Instance.GetComponent<PlayerMovement>();
                if (!playerMovement.IsMovementStopped())
                {
                    SoundManager.Instance.PlayJumpSound();
                    playerMovement.PauseMovementForDuration();
                }

                transform.DOJump(transform.position, 2f, 1, 1f)
                    .SetEase(Ease.Flash);
                break;
            }
            case "KillZone":
            {
                SoundManager.Instance.PlayKillZoneSound();
                PlayerManager.Instance.DestroyCurrentOneStickman(gameObject);
                break;
            }
        }
    }
    
}
