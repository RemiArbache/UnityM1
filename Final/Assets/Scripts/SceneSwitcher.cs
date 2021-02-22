using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
    {
        [UsedImplicitly]
        public void HandleClick()
        {
            //SceneManager.LoadScene("MainScene");
            StartCoroutine(LoadSceneAsynchronously());
        }

        private IEnumerator LoadSceneAsynchronously()
        {
            AsyncOperation ao = SceneManager.LoadSceneAsync("MainScene");
            while (!ao.isDone)
            {
                yield return null;
            }
        }
    }