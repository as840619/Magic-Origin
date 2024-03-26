using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    [Header("基本數據")]
    [SerializeField] int _nowHealth = 100;
    [SerializeField] int _maxHealth = 100;
    [SerializeField] float _flashTime = 0.5f;
    [SerializeField] float _invincibleTime = 2f;

    [SerializeField] int _collisionDamage = 10;
    [SerializeField] float _collisionDamageInterval = 10f;
    [SerializeField] float _collisionTime;
    public GameObject _healthUI;
    private GameObject tmpObject;
    //public TextMesh _healthValue;
    public Slider _healthBar;
    SpriteRenderer _spriteRenderer;
    Color _originalColor;

    public void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _originalColor = _spriteRenderer.color;
        _nowHealth = _maxHealth;
        _healthBar.value = Health;
        _collisionTime = 0;
        //_healthUI.SetActive(false);
    }

    public void Update()
    {
        _healthBar.value = Health;

        if (_nowHealth <= 0)
        {
            Destroy(transform.parent.gameObject);
            if (Random.Range(0, 100) <= 100)
            {
                CardManager.Instance.DropCard(transform.position);
            }

        }

        if (_collisionTime > 0)
            _collisionTime -= Time.deltaTime;
    }

    float Health => (float)_nowHealth / _maxHealth;

    public void TakeDamage(int damage)
    {
        _nowHealth -= damage;
        FlashColor(_flashTime);
    }


    void FlashColor(float time)
    {
        _spriteRenderer.color = Color.black;
        Invoke(nameof(ResetColor), time);
    }

    void ResetColor()
    {
        _spriteRenderer.color = _originalColor;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (_collisionTime > 0)
                return;

            _collisionTime = _collisionDamageInterval;

            TakeDamage(_collisionDamage);
        }
    }
}
