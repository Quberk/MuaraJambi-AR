using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MuaraJambi
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField] private GameObject loadingScreen;
        [SerializeField] private string beforeScene;

        private bool isLoading = false;

        private void Update()
        {
            if (Input.GetKey(KeyCode.Escape) && isLoading == false)
                BackScene();
        }

        public void Activating(GameObject objectToActivate)
        {
            objectToActivate.SetActive(true);
        }

        public void Deactivating(GameObject objectToDeactivate)
        {
            objectToDeactivate.SetActive(false);
        }

        public void ResetObject(GameObject objectToReset)
        {
            Deactivating(objectToReset);
            StartCoroutine(ExecuteAfterTime(1f, objectToReset));
        }

        IEnumerator ExecuteAfterTime(float time, GameObject objectToReset)
        {
            yield return new WaitForSeconds(time);

            Activating(objectToReset);
        }

        public void MoveToScene(string sceneName)
        {
            StartCoroutine(LoadSceneAsync(sceneName));
        }

        public void ResetScene()
        {
            StartCoroutine(LoadSceneAsync(SceneManager.GetActiveScene().name.ToString()));
        }

        IEnumerator LoadSceneAsync(string sceneName)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

            loadingScreen.SetActive(true);

            while (!operation.isDone)
            {
                yield return null;

            }
        }

        void BackScene()
        {
            isLoading = true;

            if (beforeScene == "")
                return;

            MoveToScene(beforeScene);
        }
    }
}

