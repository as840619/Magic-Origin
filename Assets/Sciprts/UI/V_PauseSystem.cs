using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class V_PauseSystem : MonoBehaviour
{
    

    public GameObject Pausemenu;
    public bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        Pausemenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (InputSystem.GetDevice<Keyboard>().tabKey.wasPressedThisFrame)
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()//暫停用
    {
        Pausemenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void ResumeGame()//繼續用
    {
        Pausemenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void Gomainmenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
