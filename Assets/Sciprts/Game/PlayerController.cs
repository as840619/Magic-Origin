using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    [Header("基本數據")]
    [SerializeField] float _moveSpeed = 5;
    [SerializeField] float _jumpSpeed = 5;
    [SerializeField] int _jumpTimes = 1;

    [Header("布林判斷")]
    [SerializeField] bool _isGround;
    [SerializeField] public bool _fallThough = false;
    [SerializeField] private Vector2 _direction;

    Animator _idleAnimation;
    Rigidbody2D _idleRigidbody;
    BoxCollider2D _idlecollider;

    private void Awake()
    {
        this.transform.position = new Vector3(0, -5.3f, 0);
        _idleAnimation = GetComponent<Animator>();
        _idleRigidbody = GetComponent<Rigidbody2D>();
        _idlecollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        CheckMotion();
        if (_direction != Vector2.zero)
        {
            _idleRigidbody.velocity = new Vector2(_direction.x * _moveSpeed, _idleRigidbody.velocity.y);

            if (_direction.x > 0)
            {
                transform.localScale = new Vector2(3, 3);
            }
            if (_direction.x < 0)
            {
                transform.localScale = new Vector2(-3, 3);
            }
        }
        ConfirmMovement(_direction.x, _direction.y, _idleRigidbody.velocity.y); //parameter
    }

    /// <summary>
    ///     Player's parameter judgement.
    /// </summary>
    void ConfirmMovement(float x, float y, float yVelocity)
    {
        _idleAnimation.SetFloat("HorizontalAxis", x);
        _idleAnimation.SetFloat("VerticalAxis", y);
        _idleAnimation.SetFloat("VerticalVelocity", yVelocity); //
    }

    void CheckMotion()
    {
        _isGround = _idlecollider.IsTouchingLayers(LayerMask.GetMask("MidFloor"));  //BUG
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

        if (Keyboard.current.downArrowKey.isPressed)
        {

            _fallThough = true;
        }
        else
        {
            _fallThough = false;
        }

    }
    public void Move(InputAction.CallbackContext ctx)
    {
        _direction = ctx.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)                          //boolean jump
        {
            if (_jumpTimes <= 0)
            {
                return;
            }
            _jumpTimes--;
            _idleAnimation.SetTrigger("Jump");
            //_idleRigidbody.AddForce();
            _idleRigidbody.velocity += Vector2.up * _jumpSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string collTag = (collision.gameObject.tag.ToString());
        //print(collTag);
        /*switch (collTag)
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
        }*/
    }
}
