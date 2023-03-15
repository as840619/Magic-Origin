using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("�򥻼ƾ�")]
    float _dieTime;
    [Tooltip("Player's existing health point")]
    static int _health = 3;
    [Tooltip("Player's existing shield point")]
    static int _shield = 0;
    [Tooltip("How long can Flash last")]
    static float _flashTime = 3f;
    [Tooltip("How long can invincible last")]
    static float _invincibleTime = 0f;

    [Header("���L�P�_")]
    [Tooltip("Determine the boolean of is the player invincible")]
    bool _invincible = false;

    private SpriteRenderer _spriteRenderer;
    private Color _originalColor;
    private Animator _animator;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _originalColor = _spriteRenderer.color;
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (_health <= 0)
        {
            _health = 0;
            _animator.SetTrigger("Die");
            Invoke("KillPlayer", _dieTime);
        }
    }

    void TakeingDamage()
    {
        if (_shield > 0)
        {
            _shield--;
        }
        else
        {
            _health--;
            FlashColor(_flashTime);
        }
    }

    void FlashColor(float time)
    {
        _spriteRenderer.color = Color.black;
        Invincible(time);
        Invoke("ResetColor", time);
    }

    void Invincible(float time)
    {
        _invincibleTime = Time.deltaTime * time;
        if (_invincibleTime == 0)
        {
            _invincible = false;
        }
        else
        {
            _invincible = true;
        }
    }

    void ResetColor()
    {
        _spriteRenderer.color = _originalColor;
    }

    void KillPlayer()
    {
        this.transform.position = new Vector3(0, -5.3f, 0);
        //Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (_invincible == false)
        {
            string collTag = collision.gameObject.tag.ToString();
            switch (collTag)
            {
                case "Enemy":
                    TakeingDamage();
                    _invincible = true;
                    break;
                case "UnTouchEnemy":
                    TakeingDamage();
                    _invincible = true;
                    break;
                case "Bullet":
                    TakeingDamage();
                    _invincible = true;
                    break;
            }

        }
    }

}
