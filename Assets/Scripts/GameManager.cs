using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public GameObject gameOverPannel;

    public GameObject pipeSpawner;
    public GameObject gameOutPannel;

    private int highScore;

    public Text highScoreText;

    private bool resetScore = false;

    public void Score()
    {
        score++;
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", score);
        }
        scoreText.text = score.ToString();
    }

    private void Start()
    {
        PipeBehaviour.speed = 5;
        gameOutPannel.SetActive(false);
        resetScore = false;
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "Best Score : " + PlayerPrefs.GetInt("HighScore").ToString();

    }
    public void GameOver()
    {
        PipeBehaviour.speed = 0;
        pipeSpawner.SetActive(false);
        GameObject.Find("Bird").GetComponent<PlayerController>().enabled = false;
        gameOutPannel.SetActive(true);
    }

    private void Update()
    {
        highScoreText.text = "Best Score : " + highScore.ToString();
        if (resetScore)
        {
            highScoreText.text = "Best Score : 0";
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ResetHighScore()
    {
        Debug.Log("HighScore Reset");
        PlayerPrefs.SetInt("HighScore", 0);
        resetScore = true;
    }

}
