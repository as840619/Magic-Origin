using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UICtrl.Loading
{
    public class UiLoading : MonoBehaviour
    {
        public Image loadingScreen;
        public Image loadingBarFill;

        public void LoadScene(int sceneId)
        {
            StartCoroutine(LoadScreenAsync(sceneId));
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
}