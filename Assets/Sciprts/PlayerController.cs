using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        float moveDirect = Input.GetAxis("Horizontal");
        float jumpDirect = Input.GetAxis("Vertical");
        float attackTime = 0.2f;
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
        if (Input.GetButtonDown("Jump") && _jumpTimes > 0)                          //boolean jump
        {
            _jumpTimes--;
            _idleAnimation.SetTrigger("Jump");
            Jump(Vector2.up);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))                                       //boolean attack
        {
            _idleAnimation.SetTrigger("Attack");
            _idleRigidbody.velocity = new Vector2(0, 0) * Time.deltaTime * attackTime;
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
        _idleRigidbody.velocity = new Vector2(moveDirection.x * _moveSpeed, _idleRigidbody.velocity.y);
    }

    void Jump(Vector2 jumpDirection)
    {
        _idleRigidbody.velocity += jumpDirection * _jumpSpeed;
    }

    void OnCollisionEnter(Collision collision)
    {
        string collTag = (collision.gameObject.tag.ToString());
        if (collision.gameObject.tag != "Enemy")
        {
            if (collision.gameObject.tag == "Flag11")
            {
                this.transform.position = new Vector3(0, -36.7f, 0);
            }
            if (collision.gameObject.tag == "Flag12")
            {
                this.transform.position = new Vector3(0, -72.2f, 0);
            }
            if (collision.gameObject.tag == "Flag13")
            {
                this.transform.position = new Vector3(0, -97.2f, 0);
            }
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

}
