using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public static ScoreManager instance;
    private int score { get; set; }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }
    private void Start()
    {
        scoreText.text = "" + score.ToString();
        scoreText.text = PlayerPrefs.GetString("" + score.ToString());
        UpdateScoreText();
    }
    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "" + score.ToString();
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = "" + score.ToString();
    }
}
