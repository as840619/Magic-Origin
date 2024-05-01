using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class V_SlowMode : MonoBehaviour
{
    public float slowmodeScale = 0.5f;
    private bool isslowmode = false;

    void Start()
    {
        Button slowMotionButton = GetComponent<Button>();
        slowMotionButton.onClick.AddListener(ToggleSlowMode);
    }
    // Update is called once per frame
    void ToggleSlowMode()
    {
        isslowmode = !isslowmode;
        Time.timeScale = isslowmode ? slowmodeScale : 1f;
    }

    
}
