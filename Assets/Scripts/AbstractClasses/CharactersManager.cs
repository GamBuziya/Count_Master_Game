using DG.Tweening;
using TMPro;
using UnityEngine;

namespace AbstractClasses
{
    public abstract class CharactersManager : MonoBehaviour
    {
        [SerializeField] protected TextMeshProUGUI _counter;
        [SerializeField] protected GameObject _stickman;
        [Range(0f, 1f)] [SerializeField] protected float _distanceFactor, _radius;
        
        protected Transform _enemy;
        protected bool _isAttacking;
        
        protected void FormatStickMan()
        {
            for (int i = 0; i < transform.childCount - 1; i++)
            {
                if(transform.GetChild(i).CompareTag("OtherObj")) continue;
            
                var x = _distanceFactor * Mathf.Sqrt(i) * Mathf.Cos(i * _radius);
                var z = _distanceFactor * Mathf.Sqrt(i) * Mathf.Sin(i * _radius);

                var newPosition = new Vector3(x, 0, z);

                transform.GetChild(i).DOLocalMove(newPosition, 1f).SetEase(Ease.OutBack);
            }
        }
    }
}