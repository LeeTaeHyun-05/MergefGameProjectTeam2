using UnityEngine;
using UnityEngine.SceneManagement; // �� ���� API

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
