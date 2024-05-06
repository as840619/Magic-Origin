using UnityEngine;
using UnityEngine.UI;

public class V_SlowMode : MonoBehaviour
{
    public float slowmodeScale = 0.5f;
    private bool isslowmode = false;

    public void ToggleSlowMode()
    {
        isslowmode = !isslowmode;
        Time.timeScale = isslowmode ? slowmodeScale : 1f;
    }
}
