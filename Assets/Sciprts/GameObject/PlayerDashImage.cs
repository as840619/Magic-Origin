using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashImage : MonoBehaviour
{
    [SerializeField]private float activeTime = 0.1f;
    private float timeActivated;
    private float alpha;
    [SerializeField]private float alphaSet = 0.8f;
    private float alphaMultipiler = 0.85f;
    private SpriteRenderer SR;
    private Color color;

    private void OnEnable()
    {
        SR = GetComponent<SpriteRenderer>();
        alpha = alphaSet;
        SR.sprite = playerSR.sprite;
        transform.position = playerPos.position;
        transform.rotation = playerPos.rotation;
        timeActivated = Time.time;
    }

    private void Update()
    {
        alpha *= alphaMultipiler;
        color = new(1f, 1f, 1f, alpha);
        SR.color = color;

        if (Time.time >= (timeActivated + activeTime))
        {
            PlayerDashImagePool.Instance.AddToPool(gameObject);
        }
    }

    SpriteRenderer playerSR => PlayerController.Instance.GetComponent<SpriteRenderer>();
    Transform playerPos => PlayerController.Instance.transform;
}
