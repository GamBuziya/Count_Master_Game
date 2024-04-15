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

            [Header("ParticleEffects")] [SerializeField]
            private ParticleSystem _blood;
            
            public GameAnimator CharacterGameAnimator { get; protected set; }
            protected int _numberOfStickmans;
            protected Transform _enemy;
            protected bool _isAttacking;
            protected float _coefficient = 0.05f;

            
            public void FormatStickMan()
            {
                float distance = 0f;
                if (_numberOfStickmans < 5)
                {
                    distance = 0.3f;
                }
                else if (_numberOfStickmans < 20)
                {
                    distance = 0.5f;
                }
                else if (_numberOfStickmans > 120)
                {
                    distance = 1.6f;
                }
                else
                {
                    distance  = _numberOfStickmans * _distanceFactor * _coefficient;
                }
                
                for (int i = 0; i < transform.childCount; i++)
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
            
            
            public int GetNumberOfStickmans()
            {
                return _numberOfStickmans;
            }

            public void DestroyOneStickman()
            {
                if (transform.childCount <= 1)
                {
                    Debug.LogWarning("There are no stickman to destroy or only one stickman exists.");
                    return;
                }

                StickmansDestroyer(transform.GetChild(1).gameObject);
            }

            public void DestroyCurrentOneStickman(GameObject stickman)
            {
                StickmansDestroyer(stickman);
            }

            private void StickmansDestroyer(GameObject stickman)
            {
                Instantiate(_blood, stickman.transform.position, Quaternion.identity);
                
                Destroy(stickman);
                _numberOfStickmans--;
                _counter.text = _numberOfStickmans.ToString();
            }
        }
    }