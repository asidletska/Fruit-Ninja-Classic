using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFruitNinja : MonoBehaviour
{
    public void PlayHandler()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
    }
    public void SettingsHandler()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1.0f;
    }
}
