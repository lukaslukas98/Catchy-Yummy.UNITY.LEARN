using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnTime = 1f;

    public TextMeshProUGUI scoreText;
    public int score;

    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public bool isGameActive;

    public GameObject titleScreen;

    public TextMeshProUGUI livesText;
    public int lives;

    public bool isGamePaused = false;


    public GameObject volumeScreen;

    public GameObject pauseScreen;


    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        isGameActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isGameActive)
        {
            if(isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }

    void ResumeGame()
    {
        isGamePaused = false;
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }

    IEnumerator SpawnTarget(float spawnRate)
    {
        while (isGameActive && !isGamePaused)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }

    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.SetText("Score: " + score);
    }

    public void gameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        float spawnRate = spawnTime / difficulty;
        StartCoroutine(SpawnTarget(spawnRate));
        score = 0;
        scoreText.SetText("Score: " + score);
        titleScreen.SetActive(false);
        volumeScreen.SetActive(false);
        livesText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
        livesText.text = "Lives: " + lives;
    }

    public void LoseLives()
    {
        lives--;
        livesText.text = "Lives: " + lives;
    }
}
