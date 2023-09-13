using UnityEngine;

public class GroundPenetrate : MonoBehaviour
{
    PlayerController _playerControls;
    PlatformEffector2D _platformEffector;
    private void Start()
    {
        _platformEffector = GetComponent<PlatformEffector2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
            _playerControls = collision.gameObject.GetComponent<PlayerController>();
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (_playerControls == null)
            return;

        if (_playerControls._fallThough)
        {
            _platformEffector.rotationalOffset = 180;
            _playerControls = null;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        _playerControls = null;
        //延遲生效
        Invoke("ResetPlatRotOffset", 0.2f);
    }

    void ResetPlatRotOffset()
    {
        _platformEffector.rotationalOffset = 0;
    }
}
