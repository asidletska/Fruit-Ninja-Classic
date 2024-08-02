using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartPanel : MonoBehaviour
{
    public void PauseButtonPressed()
    {
            SceneManager.LoadScene(4);
            Time.timeScale = 1.0f;
    }
    public void ContinueHandler()
    {
        Time.timeScale = 1.0f;
       
    }
    public void RestartHandler()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }
    public void BackToMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
}
