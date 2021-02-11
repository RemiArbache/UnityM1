using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
    {
        [UsedImplicitly]
        public void HandleClick()
        {
            SceneManager.LoadScene("MainScene");
        }
    }