using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityProject2.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] float delayLevelTime = 1.0f;

        public static GameManager Instance  { get; private set; }

        private void Awake()
        {
            SingletonThisGameObject();
        }

        private void SingletonThisGameObject()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        public void LoadScene(int levelIndex = 0)
        {
            StartCoroutine(LoadSceneAsync(levelIndex));
        }

        private IEnumerator LoadSceneAsync(int levelIndex)
        {
            yield return new WaitForSeconds(delayLevelTime);
            yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + levelIndex);
        }
    }
}

