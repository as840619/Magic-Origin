using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator _idleAnimation;
    Rigidbody2D _idleRigidbody;
    BoxCollider2D _idlecollider;
    SpriteRenderer _spriteRenderer;

    [Header("基本數據")]
    [SerializeField] float _moveSpeed = 10;
    [SerializeField] float _jumpSpeed = 10;
    [SerializeField] int _side = 1;

    [Header("布林判斷")]
    [SerializeField] bool _isGround;

    void Start()
    {
        _idleAnimation = GetComponent<Animator>();
        _idleRigidbody = GetComponent<Rigidbody2D>();
        _idlecollider = GetComponent<BoxCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        CheckParameter();
    }

    void CheckParameter()
    {

        float moveDirect = Input.GetAxis("Horizontal");
        float jumpDirect = Input.GetAxis("Vertical");
        float attackTime = 1f;
        Vector2 direction = new Vector2(moveDirect, jumpDirect);

        Run(direction);
        confirmMovement(moveDirect, jumpDirect, _idleRigidbody.velocity.y);
        _isGround = _idlecollider.IsTouchingLayers(LayerMask.GetMask("Ground"));//落下等圖塊地圖改好在調

        if (_isGround)
        {
            _idleAnimation.SetBool("OnGround", true);
            _idleAnimation.SetBool("Falling", false);
        }
        if (_isGround)
        {
            _idleAnimation.SetBool("OnGround", false);
        }
        if (_idleRigidbody.angularVelocity < 0)
        {
            _idleAnimation.SetBool("Falling", true);
        }
        if (Input.GetButtonDown("Jump"))
        {
            _idleAnimation.SetTrigger("Jump");
            Jump(Vector2.up);
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            _idleAnimation.SetTrigger("Attack");//被搶拍
            _idleRigidbody.velocity = new Vector2(0, 0) * Time.deltaTime * attackTime;//加秒數沒用
        }

        if (moveDirect != 0)
        {
            if (moveDirect > 0)
            {
                _side = 1;
                bool state = (_side == 1) ? false : true;
                _spriteRenderer.flipX = state;
            }
            if (moveDirect < 0)
            {
                _side = -1;
                bool state = (_side == -1) ? true : false;
                _spriteRenderer.flipX = state;
            }
        }
    }

    public void confirmMovement(float x, float y, float yVelocity)
    {
        _idleAnimation.SetFloat("HorizontalAxis", x);
        _idleAnimation.SetFloat("VerticalAxis", y);
        _idleAnimation.SetFloat("VerticalVelocity", yVelocity);
    }

    void Run(Vector2 moveDirect)
    {
        _idleRigidbody.velocity = new Vector2(moveDirect.x * _moveSpeed, _idleRigidbody.velocity.y); ;
    }

    void Jump(Vector2 direction)
    {

        _idleRigidbody.velocity = new Vector2(_idleRigidbody.velocity.x, 0);
        _idleRigidbody.velocity += direction * _jumpSpeed;
    }
}
