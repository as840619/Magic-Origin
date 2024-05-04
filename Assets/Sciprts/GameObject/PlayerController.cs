using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using Cainos.PixelArtPlatformer_VillageProps;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    private static PlayerController instance;
    public static PlayerController Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.Find("Player").GetComponent<PlayerController>();
            return instance;
        }
    }
    public Vector3 Position
    {
        get
        {
            return instance.transform.position;
        }
    }
    [Header("基本數據")]
    [SerializeField] int jumpTimes = 2;
    [SerializeField] float moveSpeed = 5;
    [SerializeField] float jumpSpeed = 6;
    [SerializeField] private float dashTime = 0.5f;
    [SerializeField] float dashForse = 20f;
    [SerializeField] float dashCoefficient = 1f;
    [SerializeField] float distanceBetweenImages = 0.2f;

    [Header("移動判斷")]
    public bool isGround;
    public bool isWall;
    //public bool isPause;
    public bool isDashing;
    public bool canJump;
    public bool canMove;
    public bool canFilp;
    public bool _fallThough;
    public bool createrMode;
    public Vector2 moveDirection;

    [Header("基本數據")]
    [SerializeField] float timer;
    [SerializeField] float slowModeTimer;
    [SerializeField] float onTime = 1f;
    [SerializeField] Image image;
    public bool bossBattle = false;
    public bool invincible;
    public PlayerInputControl playerControl;


    private int jumpLeft;
    private float dashTimeLeft;
    private float lastImageXpos;
    private InputAction move;
    private InputAction jump;
    private InputAction draw;
    private InputAction skip;
    private InputAction escape;
    private InputAction interact;
    private InputAction slowModeAct;
    private Animator idleAnimation;
    private Rigidbody2D idleRigidbody;
    private BoxCollider2D idlecollider;
    private PlayerHealth playerHealth;
    private Chest chest;

    private void Awake()
    {
        playerControl = new PlayerInputControl();
        this.transform.position = new Vector3(0, -5.3f, 0);
        idleAnimation = GetComponent<Animator>();
        idleRigidbody = GetComponent<Rigidbody2D>();
        idlecollider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        dashTimeLeft = 0f;
        lastImageXpos = 0f;
        canMove = true;
        canFilp = true;
        isDashing = false;
        jumpLeft = jumpTimes;
        dashForse *= dashCoefficient;
    }

    private void OnEnable()
    {
        //skip = playerControl.UI.SkipDialogue;
        move = playerControl.Normal.Move;
        jump = playerControl.Normal.Jump;
        draw = playerControl.Normal.Draw;
        escape = playerControl.Normal.Exit;
        interact = playerControl.Normal.Interact;
        slowModeAct = playerControl.Normal.SlowModeActivate;
        //skip.Enable();
        move.Enable();
        jump.Enable();
        draw.Enable();
        escape.Enable();
        interact.Enable();
        slowModeAct.Enable();
    }

    private void OnDisable()
    {
        //skip.Disable();
        move.Disable();
        jump.Disable();
        draw.Disable();
        escape.Disable();
        interact.Disable();
        slowModeAct.Disable();
    }

    private void Update()
    {
        image.enabled = invincible;
        moveDirection = move.ReadValue<Vector2>();
        if (jump.IsPressed() && jumpLeft > 0)
            Jump();
        ConfirmMovement(moveDirection.x, moveDirection.y, idleRigidbody.velocity.y); //parameter
        CheckAction();
        CheckFilp();
        //CheckDash();
        timer += Time.deltaTime;
        slowModeTimer += Time.deltaTime;
        if (slowModeTimer > 0.01f)
        {
            if (slowModeAct.IsPressed())
            {
                GameManager.Instance.GetComponent<V_SlowMode>().ToggleSlowMode();
                slowModeTimer = 0;
            }
        }
        if (timer < onTime)
            return;
        if (draw.IsPressed())
        {
            GameObject.Find("Draw").GetComponent<DrawCard>().Onclick();
            timer = 0;
        }
    }

    private void FixedUpdate()
    {
        idleRigidbody.velocity = new(moveDirection.x * moveSpeed, idleRigidbody.velocity.y);
    }

    /*
    public void Dash()
    {
        isDashing = true;
        dashTimeLeft = dashTime;
        Debug.Log("該變了吧");
        //lastDash += Time.time;
        PlayerDashImagePool.Instance.GetFromPool();
        lastImageXpos = transform.position.x;
    }
    */
    private void Jump()
    {
        Debug.Log(jumpLeft);
        idleRigidbody.velocity = Vector2.up * jumpSpeed;
        idleAnimation.SetTrigger("Jump");
        jumpLeft--;
    }

    /// <summary>
    ///     Player's parameter judgement.
    /// </summary>

    private void ConfirmMovement(float x, float y, float yVelocity)
    {
        idleAnimation.SetFloat("HorizontalAxis", x);
        idleAnimation.SetFloat("VerticalAxis", y);
        idleAnimation.SetFloat("VerticalVelocity", yVelocity); //
    }

    private void CheckFilp()
    {
        if (moveDirection == Vector2.zero || canFilp == false)
            return;
        if (moveDirection.x > 0)
        {
            transform.localScale = new Vector2(3, 3);
        }
        if (moveDirection.x < 0)
        {
            transform.localScale = new Vector2(-3, 3);
        }
    }

    private void CheckAction()
    {
        isGround = idlecollider.IsTouchingLayers(LayerMask.GetMask("MidFloor"));  //BUG

        if (isGround == true)                                                      //boolean touching ground
        {
            jumpLeft = jumpTimes;
            idleAnimation.SetBool("OnGround", true);
            idleAnimation.SetBool("Falling", false);
        }

        if (isGround == false)                                                     //boolean touching ground
        {
            idleAnimation.SetBool("OnGround", false);
        }

        if (idleRigidbody.angularVelocity < 0)                                     //boolean falling 
        {
            idleAnimation.SetBool("Falling", true);
        }
        _fallThough = Keyboard.current.sKey.isPressed;
    }
    /*
    private void CheckDash()
    {
        if (isDashing != true)
        {
            return;
        }
        Debug.Log(dashTimeLeft);
        if (dashTimeLeft > 0)
        {
            canMove = false;
            canFilp = false;
            //_idleRigidbody.AddForce(_direction * dashForse, ForceMode2D.Impulse);
            idleRigidbody.velocity = new Vector2(moveDirection.x * dashForse, idleRigidbody.velocity.y);
            //Debug.Log("DDDD");
            dashTimeLeft -= Time.deltaTime;
            if (Mathf.Abs(transform.position.x - lastImageXpos) > distanceBetweenImages)
            {
                PlayerDashImagePool.Instance.GetFromPool();
                lastImageXpos = transform.position.x;
            }
        }
        if (dashTimeLeft <= 0 || isWall)
        {
            isDashing = false;
            canMove = true;
            canFilp = true;
        }
    }

    private IEnumerator DashOne()
    {
        idleRigidbody.velocity = new Vector2(moveDirection.x * dashForse, idleRigidbody.velocity.y);
        yield return new WaitForSeconds(0.25F);
        //yield return new WaitForSeconds(0.25F);
    }
    */
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Flag11"))
            this.transform.position = GameManager.Instance.NextLevel();
        if (other.CompareTag("Flag12"))
            this.transform.position = GameManager.Instance.NextLevel();
        if (other.CompareTag("Flag13"))
            this.transform.position = GameManager.Instance.NextLevel();
        if (other.CompareTag("Flag14"))
            this.transform.position = GameManager.Instance.NextLevel();
        if (other.CompareTag("Flag21"))
            GameObject.FindWithTag("End").SetActive(true);
        if (other.CompareTag("Hp"))
            this.transform.position = new Vector3(52, -140, 0);
        if (other.CompareTag("Water"))
        {
            this.transform.position = GameManager.Instance.ReturnLevel();
        }
        if (other.CompareTag("CardDrop"))
        {
            Destroy(other.gameObject);
            CardManager.Instance.CardInstantiate();
        }
        if (other.CompareTag("BossZombieBattle"))
            bossBattle = true;
        if (other.CompareTag("HiddenTilemap"))
        {
            other.GetComponent<HiddenSpot>().SortingLayer();
        }
        if (other.CompareTag("Chest"))
        {
            if (other.GetComponent<Chest>().IsOpened == true)
                return;
            CardManager.Instance.CardInstantiate();
            other.GetComponent<Chest>().IsOpened = true;
        }
        if (other.CompareTag("EX"))
        {
            this.transform.position = new Vector3(27, -29, 0);
        }
        if (interact.IsPressed())
        {
            if (other.GetComponent<Scientist>() != null)
                return;
            if (other.GetComponent<Engineer>() != null)
                return;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("HiddenTilemap"))
        {
            other.GetComponent<HiddenSpot>().LeaveSpot();
        }
    }
}