using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("基本數據")]
    [SerializeField] float _dieTime;

    static int _health;
    static float _flashTime;
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
        }
        if (_health <= 0)
        {
            _animator.SetTrigger("Die");
            Invoke("KillPlayer", _dieTime);
        }
    }

    void TakeingDamage()
    {
        _health--;
        FlashColor(_flashTime);
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
        this.transform.position = new Vector3(0, -5.3f, 0);
        //Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            string collTag = (collision.gameObject.tag.ToString());
            switch (collTag)
            {
                case "Enemy":
                    TakeingDamage();
                    break;
                case "Bullet":
                    TakeingDamage();
                    break;
            }
        }
    }

}
