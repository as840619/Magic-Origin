using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Animator _idleAnimation;
    Rigidbody2D _idleRigidbody;
    BoxCollider2D _idlecollider;
    
    //SpriteRenderer _spriteRenderer;

    [Header("基本數據")]
    [SerializeField] float _moveSpeed = 5;
    [SerializeField] float _jumpSpeed = 5;
    [SerializeField] int _jumpTimes = 1;

    [Header("布林判斷")]
    [SerializeField] bool _isGround;

    public void Respawn()
    {
        this.transform.position = new Vector3(0, -5.3f, 0);
    }

    public void ConfirmMovement(float x, float y, float yVelocity)
    {
        _idleAnimation.SetFloat("HorizontalAxis", x);
        _idleAnimation.SetFloat("VerticalAxis", y);
        _idleAnimation.SetFloat("VerticalVelocity", yVelocity);
    }

    /*public void Forward(InputAction.CallbackContext ctx)
    {
        Direction = ctx.ReadValue<Double>();
    }
    public void Backward(InputAction.CallbackContext ctx)
    {
        Direction = ctx.ReadValue<Double>();
    }*/

public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && _jumpTimes > 0)
        {
            _jumpTimes--;
            _idleAnimation.SetTrigger("Jump");
            _idleRigidbody.velocity += Vector2.up * _jumpSpeed;
        }
    }

    void Start()
    {
        _idleAnimation = GetComponent<Animator>();
        _idleRigidbody = GetComponent<Rigidbody2D>();
        _idlecollider = GetComponent<BoxCollider2D>();
        //_spriteRenderer = GetComponent<SpriteRenderer>();
        Respawn();
    }

    void Update()
    {
        CheckParameter();
    }

    void CheckParameter()
    {
        float moveDirect = Direction.x;
        float jumpDirect = Direction.y;
        //float attackTime = 0.2f;
        Vector2 Direction = new(moveDirect, jumpDirect);        //vector2 package

        Run(Direction);
        ConfirmMovement(moveDirect, jumpDirect, _idleRigidbody.velocity.y);         //parameter
        bool _isGround = _idlecollider.IsTouchingLayers(LayerMask.GetMask("MidGround"));    //BUG

        if (_isGround == true)                                                      //boolean touching ground
        {
            _jumpTimes = 1;
            _idleAnimation.SetBool("OnGround", true);
            _idleAnimation.SetBool("Falling", false);
        }
        if (_isGround == false)                                                     //boolean touching ground
        {
            _idleAnimation.SetBool("OnGround", false);
        }
        if (_idleRigidbody.angularVelocity < 0)                                     //boolean falling 
        {
            _idleAnimation.SetBool("Falling", true);
        }
        if (moveDirect != 0)                                                        //object scale
        {
            if (moveDirect > 0)
            {
                transform.localScale = new Vector2(3, 3);
            }
            if (moveDirect < 0)
            {
                transform.localScale = new Vector2(-3, 3);
            }
        }
    }

    void Run(Vector2 moveDirection)
    {
        this.transform.position += new Vector3(Direction.x, Direction.y, 0);
        //_idleRigidbody.velocity = new Vector2(moveDirection.x * _moveSpeed, _idleRigidbody.velocity.y);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        string collTag = (collision.gameObject.tag.ToString());
        switch (collTag)
        {
            case "Flag11":
                this.transform.position = new Vector3(0, -36.7f, 0);
                break;
            case "Flag12":
                this.transform.position = new Vector3(0, -72.2f, 0);
                break;
            case "Flag13":
                this.transform.position = new Vector3(0, -97.2f, 0);
                break;
            default:
                break;
        }
    }
}
