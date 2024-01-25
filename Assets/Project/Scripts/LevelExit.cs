using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    
    public string levelName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SwitchToScene();
        }
    }

    public void SwitchToScene()
    {
        SceneManager.LoadScene(levelName);
    }
}
