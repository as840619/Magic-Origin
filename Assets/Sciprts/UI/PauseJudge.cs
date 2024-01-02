
using UnityEngine;

public class PauseJudge : MonoBehaviour
{
    float _previousTimeScale = 1;
    public static bool isPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
    void TogglePause()
    {
        if (Time.timeScale > 0)
        {
            _previousTimeScale = Time.timeScale;
            Time.timeScale = 0;
            isPaused = true;
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = _previousTimeScale;
            isPaused = false;
        }
    }
}
