using UnityEngine;
using UnityEngine.Events;

public class PauseJudge : MonoBehaviour
{
    public GameObject dialogueBox;
    public static bool isPaused;
    //GameObject dialogueBox => GameObject.Find("DialogueManager");
    public void PauseIt()
    {
        isPaused = true;
        dialogueBox.SetActive(true);
        Time.timeScale = 0;
    }
    public void Continue()
    {
        isPaused = false;
        Time.timeScale = 1;
    }
}
