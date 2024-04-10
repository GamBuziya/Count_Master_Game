    using DG.Tweening;
    using TMPro;
    using UnityEngine;

    namespace AbstractClasses
    {
        public abstract class CharactersManager : MonoBehaviour
        {
            [SerializeField] protected TextMeshProUGUI _counter;
            [SerializeField] protected GameObject _stickman;
            [Range(0f, 1f)] [SerializeField] protected float _distanceFactor;

            
            public Animator CharacterAnimator { get; protected set; }
            protected int _numberOfStickmans;
            protected Transform _enemy;
            protected bool _isAttacking;
            protected float _coefficient = 0.03f;

            
            public void FormatStickMan()
            {
                float distance = 0f;
                if (_numberOfStickmans < 20)
                {
                    distance = 0.3f;
                }
                else if (_numberOfStickmans > 120)
                {
                    distance = 1.2f;
                }
                else
                {
                    distance  = _numberOfStickmans * _distanceFactor * _coefficient;
                }
                
                for (int i = 0; i < transform.childCount - 1; i++)
                {
                    if(transform.GetChild(i).CompareTag("OtherObj")) continue;

                    var randomAngle = Random.Range(0f, Mathf.PI * 2f); // Випадковий кут в радіанах
                    var randomRadius = Random.Range(0f, distance); // Випадковий радіус

                    var x = randomRadius * Mathf.Cos(randomAngle);
                    var z = randomRadius * Mathf.Sin(randomAngle);

                    var newPosition = new Vector3(x, 0, z);

                    transform.GetChild(i).DOLocalMove(newPosition, 1f).SetEase(Ease.OutBack);
                }
            }


            
            protected void UpdateUI()
            {
                _numberOfStickmans = transform.childCount - 1;
                _counter.text = _numberOfStickmans.ToString();
            }
            
            protected void UpdateUI(string a)
            {
                _numberOfStickmans = transform.childCount - 1;
                _counter.text = _numberOfStickmans.ToString();
                Debug.Log("a" + _numberOfStickmans);
            }
            
            
            public int GetNumberOfStickmans()
            {
                return _numberOfStickmans;
            }

            public void DestroyOneStickman()
            {
                //Debug.Log("Enter in DestroyOneStickman");
                if (transform.childCount <= 1)
                {
                    Debug.LogWarning("There are no stickman to destroy or only one stickman exists.");
                    return;
                }

                Destroy(transform.GetChild(1).gameObject);

                _numberOfStickmans--;
                _counter.text = _numberOfStickmans.ToString();
            }
        }
    }