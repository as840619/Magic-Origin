using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaRangeTrigger : MonoBehaviour
{
    public List<Dialogue> dialogue;

    bool isTrigger = false;
    float timeFloat = 0f;

    Vector2 playerPosition => PlayerController.Instance.GetComponent<Transform>().position;

    private void Update()
    {
        float distanceFromPlayer = Vector2.Distance(playerPosition, transform.position);
        if (distanceFromPlayer <= 5f)
        {
            timeFloat += Time.deltaTime;
        }
        if (timeFloat == 1f)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
        if (isTrigger)
        {
            RunAway(distanceFromPlayer);
        }
    }

    private void RunAway(float distanceFromPlayer)
    {
        this.transform.TransformDirection(+2, 0, 0);
        if (distanceFromPlayer >= 12f)
            Destroy(gameObject);
    }
}
