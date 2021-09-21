using UnityEngine.SceneManagement;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public void LoadScene(int scene) {
        SceneManager.LoadScene(scene);
    }
}
