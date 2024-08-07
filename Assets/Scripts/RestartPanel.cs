using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartPanel : MonoBehaviour
{
    public GameObject panelPause;
    public void PauseButtonPressed()
    {
        Time.timeScale = 0f;
        panelPause.SetActive(true);
    }
    public void ContinueHandler()
    {
        panelPause.SetActive(false);
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
