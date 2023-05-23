using UnityEngine;

public class GroundPenetrate : MonoBehaviour
{
    [SerializeField] bool fallthough = false;
    PlayerController playerControls;
    PlatformEffector2D _platformEffector;
    private void Start()
    {
        _platformEffector = GetComponent<PlatformEffector2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
            playerControls = collision.gameObject.GetComponent<PlayerController>();
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (playerControls == null)
            return;
        if (playerControls._fallThough)
        {
            _platformEffector.rotationalOffset = 180f;
            playerControls = null;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        playerControls = null;
        _platformEffector.rotationalOffset = 0f;
    }
}
