using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("基本數據")]
    [SerializeField] int _health;
    [SerializeField] int _damage;
    [SerializeField] float _flashTime;

    private SpriteRenderer _spriteRenderer;
    private Color _originalColor;

    public void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _originalColor = _spriteRenderer.color;
    }

    public void Update()
    {
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeingDamage(int _damage)
    {
        _health -= _damage;
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //other.GetComponent<PlayerHealth>().TakeingDamage();
        }
    }

}
