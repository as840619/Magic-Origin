using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    [Header("基本數據")]
    [SerializeField] int _nowHealth = 100;
    [SerializeField] int _maxHealth = 100;
    [SerializeField] int _damage = 10;
    [SerializeField] float _flashTime = 0.5f;
    [SerializeField] float _invincibleTime = 2f;
    [SerializeField] bool _invincible = false;


    public GameObject _healthUI;
    //public TextMesh _healthValue;
    public Slider _healthBar;
    SpriteRenderer _spriteRenderer;
    Color _originalColor;

    public void TakeingDamage(int damage)
    {
        _nowHealth -= damage;
        _invincible = true;
        FlashColor(_flashTime);
    }

    public void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _originalColor = _spriteRenderer.color;
        _nowHealth = _maxHealth;
        _healthBar.value = HealthUpdate();
        //_healthUI.SetActive(false);
    }

    public void Update()
    {
        _healthBar.value = HealthUpdate();
        //Debug.Log(_nowHealth);
        /*if (_nowHealth < _maxHealth)
        {
            _healthUI.SetActive(true);
        }*/
    }

    int HealthUpdate()
    {
        return _nowHealth / _maxHealth;
    }

    void Invincible()
    {
        float tempTime = Time.deltaTime * _invincibleTime;
        if (tempTime == 0)
        {
            _invincible = false;
        }
        else
        {
            _invincible = true;
        }
    }

    void FlashColor(float time)
    {
        _spriteRenderer.color = Color.black;
        Invincible();
        Invoke("ResetColor", time);
    }

    void ResetColor()
    {
        _spriteRenderer.color = _originalColor;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //string collTag = (collision.gameObject.tag.ToString());
        if (_invincible == false)
        {
            if (collision.gameObject.tag == "Player")
            {
                TakeingDamage(_damage);
                if (_nowHealth == 0)
                {
                    DestroyImmediate(this.gameObject);
                }
            }
        }
    }

}
