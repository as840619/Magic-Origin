using UnityEngine;
using UnityEngine.UI;
namespace Object.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [Header("基本數據")]
        [SerializeField] int _nowHealth = 10;
        [SerializeField] int _maxHealth = 10;
        public float flashTime;
        public float dieTime;
        private SpriteRenderer _spriteRenderer;
        private Color _originalColor;
        private Animator _animator;

        [SerializeField] int _collisionDamage = 10;
        [SerializeField] float _collisionDamageInterval = 10f;
        [SerializeField] float _collisionTime;

        [Header("UI")]
        public GameObject _healthUI;
        public Slider _healthBar;

        void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
            _originalColor = _spriteRenderer.color;
            _nowHealth = _maxHealth;
        }

        void Update()
        {
            if (_collisionTime > 0)
                _collisionTime -= Time.deltaTime;
            if (_nowHealth >= 0)
            {
                _healthBar.value = Health;
            }
            if (_nowHealth <= 0)
            {
                _animator.SetTrigger("Die");
                Invoke("KillPlayer", dieTime);
            }
        }

        float Health => (float)_nowHealth / _maxHealth;

        public void TakeDamage(int damage)
        {
            if (_collisionTime > 0)
                return;
            _collisionTime = _collisionDamageInterval;
            _nowHealth -= damage;
            FlashColor(flashTime);
        }
        void FlashColor(float time)
        {
            _spriteRenderer.color = Color.black;
            Invoke("ResetColor", time);
        }

        void ResetColor()
        {
            _spriteRenderer.color = _originalColor;
        }
        void KillPlayer()
        {
            Destroy(gameObject);
        }
    }
}