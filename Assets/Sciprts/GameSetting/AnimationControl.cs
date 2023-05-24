using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UICtrl.Loading;


public class AnimationControl : MonoBehaviour
{
    [Header("使用LoadScreenAsync所需的物件")]
    public Image loadingBarFill;
    public Canvas loadingCanvas;
    [Header("開頭動畫")]
    public Image animationShow;
    public Sprite[] spriteArray;
    public float animaSpeed = 0.5f;
    private int _indexSprite = 0;
    Coroutine _animCoroutine;
    UiLoading _loadingScene;

    private void Awake()
    {
        animationShow.enabled = false;
        loadingCanvas.enabled = false;
    }

    public void aniStart(int sceneId)
    {
        animationShow.enabled = true;
        StartCoroutine(PlayAnimation(sceneId));
    }

    IEnumerator PlayAnimation(int sceneId)
    {
        yield return new WaitForSeconds(animaSpeed);
        if (_indexSprite + 1 >= spriteArray.Length)
        {
            loadingCanvas.enabled = true;
            animationShow.enabled = false;
            StartCoroutine(LoadScreenAsync(sceneId));
            //_loadingScene.LoadScene(sceneId);
            yield return null;
        }
        animationShow.sprite = spriteArray[_indexSprite];
        _indexSprite++;
        _animCoroutine = StartCoroutine(PlayAnimation(sceneId));
    }

    IEnumerator LoadScreenAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            loadingBarFill.fillAmount = progressValue;
            yield return null;
        }
    }
}

