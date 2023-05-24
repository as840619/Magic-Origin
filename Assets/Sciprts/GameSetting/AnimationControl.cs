using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnimationControl : MonoBehaviour
{
    public Canvas animaCanvas;
    public Image animationShow;
    public Sprite[] spriteArray;
    public float animaSpeed = 2f;
    private int _indexSprite;
    Coroutine _animCoroutine;

    /*public void Update()
    {
        if (MenuControl.startGame)
        {
            animaCanvas.sortingOrder = 9;
            StartCoroutine(PlayAnimation());
        }
    }*/

    public void aniStart(int sceneId)
    {
        StartCoroutine(PlayAnimation(sceneId));
    }

    IEnumerator PlayAnimation(int sceneId)
    {
        yield return new WaitForSeconds(animaSpeed);
        if (_indexSprite >= spriteArray.Length)
        {
            SceneManager.LoadSceneAsync(sceneId);
        }
        animationShow.sprite = spriteArray[_indexSprite];
        _indexSprite += 1;
        _animCoroutine = StartCoroutine(PlayAnimation(sceneId));
    }
}
