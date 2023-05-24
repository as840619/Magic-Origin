using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiLoading : MonoBehaviour
{
    public GameObject _loadingScreen;
    public Image _loadingBarFill;

    public void LoadScreen(int sceneId)
    {
        StartCoroutine(LoadScreenAsync(sceneId));
    }

    IEnumerator LoadScreenAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            _loadingBarFill.fillAmount = progressValue;
            yield return null;
        }
    }
}
