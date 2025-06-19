using UnityEngine;
using UnityEngine.SceneManagement; // ¾À °ü·Ã API

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
