using UnityEngine;

public class GroundPenetrate : MonoBehaviour
{
    [SerializeField] bool fallthough = false;
    PlayerController playerControls;
    private PlatformEffector2D effector;
    private void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
        playerControls = GetComponent<PlayerController>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string collTag = (collision.gameObject.tag.ToString());
        if (collTag == "player")
        {
            playerControls = collision.gameObject.GetComponent<PlayerController>();
        }
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log(1);
        //GetType().GetProperty(name).GetValue();
        if (playerControls == null)
            return;
        if (playerControls._fallThough)
        {
            effector.rotationalOffset = 180f;
            playerControls = null;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        playerControls = null;
        effector.rotationalOffset = 0f;
    }
}
