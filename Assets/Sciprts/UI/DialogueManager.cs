using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueListText;
    public Animator animator;
    public float DisplayStart;
    public float DisplaySpeed;

    private Queue<string> sentences;
    //private bool skipBool = false;
    private bool Displaying = false;

    private static DialogueManager instance;
    public static DialogueManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
            return instance;
        }
    }

    private void Start()
    {
        sentences = new Queue<string>();
    }

    private void FixedUpdate()
    {
        this.gameObject.SetActive(true);
    }

    public void StartDialogue(List<Dialogue> dialogueList)
    {
        //GameObject.Find("Player").GetComponent<PauseJudge>().gamePause.Invoke();
        animator.SetBool("IsOpen", true);
        foreach (Dialogue dialogue in dialogueList)
        {
            Debug.Log(dialogue.name);
            nameText.text = dialogue.name;
            sentences.Clear();
            StartCoroutine(StartADialogue());
            foreach (string sentence in dialogue.sentneces)
            {
                sentences.Enqueue(sentence);
            }
            DisplayNextCentence();
        }
    }

    /*public void StartDialogue(Dialogue dialogue)
    {
        //GameObject.Find("Player").GetComponent<PauseJudge>().gamePause.Invoke();
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        sentences.Clear();
        StartCoroutine(StartADialogue());
        foreach (string sentence in dialogue.sentneces)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextCentence();
    }*/

    public void DisplayNextCentence()
    {
        if (sentences.Count == 0)
        {
            if (Displaying)
            {
                DisplaySpeed = 0;
                Displaying = false;
                return;
            }
            EndDialogue();
            return;
        }
        if (Displaying)
        {
            DisplaySpeed = 0;
            Displaying = false;
            return;
        }
        DisplaySpeed = 0.3f;
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator StartADialogue()
    {
        yield return new WaitForSeconds(DisplayStart);
    }

    IEnumerator TypeSentence(string sentence)
    {
        Displaying = true;
        dialogueListText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueListText.text += letter;
            yield return new WaitForSeconds(DisplaySpeed);
        }
        Displaying = false;
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        //GameObject.Find("Player").GetComponent<PauseJudge>().gameResume.Invoke();
    }
}
