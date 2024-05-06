using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    [Header("基本數據")]
    public int nowHealth = 0;
    public int maxHealth = 3;
    public float flashTime;
    public float dieTime;
    public bool takeDamage;
    private SpriteRenderer sr;
    private Color originalColor;
    private Animator anim;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
        anim = GetComponent<Animator>();
        nowHealth = maxHealth;
    }

    private void Update()
    {
        if (!takeDamage)
            return;
        if (HeartRemain <= 0)
        {
            takeDamage = false;
            Invoke(nameof(KillPlayer), dieTime);
            FlashColor(flashTime);
        }
    }

    Rigidbody2D PlayerRb => GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
    private int HeartRemain => PlayerManager.Instance.nowHealth;

    private void FlashColor(float time)
    {
        sr.color = Color.black;
        Invoke(nameof(ResetColor), time);
    }

    private void ResetColor()
    {
        sr.color = originalColor;
    }

    private void KillPlayer()
    {
        SceneManager.LoadScene(1);
    }
}