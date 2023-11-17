using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SceneTransition"))
        {
            var currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name == "Scene2" ? "Scene1" : "Scene2");
        }
    }
}