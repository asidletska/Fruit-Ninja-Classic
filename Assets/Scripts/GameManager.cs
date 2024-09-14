using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Image fadeImage;
    private int score;

     private Blade blade;
     private Spawner spawner;
    public UnityEvent bomb;
    public int lives = 3;

    private void Awake()
    {
        blade = FindObjectOfType<Blade>();
        spawner = FindObjectOfType<Spawner>();
    }
    private void Start()
    {
        NewGame();
    }
    private void NewGame()
    {
        Time.timeScale = 1f;
        Clear();

        blade.enabled = true;
        spawner.enabled = true;
        scoreText.text = score.ToString();

    }

    public void Miss()
    {
        lives--;
        if (lives > 0)
        {
            NewGame();
            IncreaseScore(score);
        }
        else
        {
            StartCoroutine(GameOver()); 
        }
    }
    private void Clear()
    {
        Fruit[] fruits = FindObjectsOfType<Fruit>();

        foreach (Fruit fruit in fruits)
        {
            Destroy(fruit.gameObject);
        }
        Bomb[] bombs = FindObjectsOfType<Bomb>();

        foreach (Bomb bomb in bombs)
        {
            Destroy(bomb.gameObject);
        }
    }
    public void IncreaseScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();

    }
    public void Explode()
    {
        
        blade.enabled = false;
        spawner.enabled = false;
        StartCoroutine(ExplodeSequence());
    }
    private IEnumerator ExplodeSequence()
    {
        bomb.Invoke();
        float elapsed = 0f;
        float duration = 0.5f;
        while (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);
            fadeImage.color = Color.Lerp(Color.clear, Color.white, t);

            Time.timeScale = 1f - t;
            elapsed += Time.unscaledDeltaTime;

            yield return null;
        }
        yield return new WaitForSecondsRealtime(2f);
        NewGame();

        elapsed = 0f;
        while (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);
            fadeImage.color = Color.Lerp(Color.white, Color.clear, t);

            elapsed += Time.unscaledDeltaTime;

            yield return null;

        }
    }
    private IEnumerator GameOver()
    {
        bomb.Invoke();
        float elapsed = 0f;
        float duration = 0.5f;
        while (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);
            fadeImage.color = Color.Lerp(Color.clear, Color.white, t);

            Time.timeScale = 1f - t;
            elapsed += Time.unscaledDeltaTime;

            yield return null;
        }
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene(3);
    }
}
