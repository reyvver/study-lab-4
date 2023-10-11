using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class StartGame : MonoBehaviour
    {
        public void LoadGame()
        {
            SceneManager.LoadScene(sceneBuildIndex: 1);
        }
    }
}