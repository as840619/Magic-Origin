using UnityEngine;

public class V_TouchDialog : MonoBehaviour
{
    public V_Dialog DialScript;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
            return;
        DialScript.gameObject.SetActive(true);
        DialScript.StartDialogue();
    }
}