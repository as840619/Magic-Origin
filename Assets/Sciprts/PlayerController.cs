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

    [Header("�򥻼ƾ�")]
    [SerializeField] float _moveSpeed = 5;
    [SerializeField] float _jumpSpeed = 5;
    [SerializeField] int _jumpTimes = 1;

    [Header("���L�P�_")]
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
        Vector2 direction = new Vector2(moveDirect, jumpDirect);

        Run(direction);
        ConfirmMovement(moveDirect, jumpDirect, _idleRigidbody.velocity.y);
        bool _isGround = _idlecollider.IsTouchingLayers(LayerMask.GetMask("MidGround"));//���U���϶��a�ϧ�n�b��

        if (_isGround == true)
        {
            _jumpTimes = 1;
            _idleAnimation.SetBool("OnGround", true);
            _idleAnimation.SetBool("Falling", false);
        }
        if (_isGround == false)
        {
            _idleAnimation.SetBool("OnGround", false);
        }
        if (_idleRigidbody.angularVelocity < 0)
        {
            _idleAnimation.SetBool("Falling", true);
        }
        if (Input.GetButtonDown("Jump") && _jumpTimes > 0)
        {
            _jumpTimes--;
            _idleAnimation.SetTrigger("Jump");
            Jump(Vector2.up);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))       //boolean attack
        {
            _idleAnimation.SetTrigger("Attack");
            _idleRigidbody.velocity = new Vector2(0, 0) * Time.deltaTime * attackTime;
        }
        if (moveDirect != 0)        //object scale
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

    void Run(Vector2 moveDirect)
    {
        _idleRigidbody.velocity = new Vector2(moveDirect.x * _moveSpeed, _idleRigidbody.velocity.y); ;
    }

    void Jump(Vector2 direction)
    {
        _idleRigidbody.velocity = new Vector2(_idleRigidbody.velocity.x, 0);
        _idleRigidbody.velocity += direction * _jumpSpeed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Enemy")
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

}
