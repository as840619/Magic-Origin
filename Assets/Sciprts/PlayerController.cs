using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator _idleAnimation;
    Rigidbody2D _idleRigidbody;
    BoxCollider2D _idlecollider;

    [Header("基本數據")]
    [SerializeField] float _moveSpeed = 10;
    [SerializeField] float _jumpSpeed = 10;

    [Header("布林判斷")]
    [SerializeField] bool _isGround;

    void Start()
    {
        _idleRigidbody = GetComponent<Rigidbody2D>();
        _idleAnimation = GetComponent<Animator>();
        _idlecollider = GetComponent<BoxCollider2D>();
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
        if (_idleRigidbody.velocity.x != 0 && _isGround)
        {
            _idleAnimation.SetBool("Running", true);
            if (_idleRigidbody.velocity.x > 0)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            if (_idleRigidbody.velocity.x < 0)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
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
