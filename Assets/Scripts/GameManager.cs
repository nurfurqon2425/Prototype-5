using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI liveText;
    public Button restartButton;
    public GameObject titleScreen;
    public GameObject volumeSlide;
    public GameObject pauseScreen;
    private AudioSource backgroundMusic;


    private float spawnRate = 1.0f;
    private int score;
    public bool isGameActive;
    public int lives = 3;
    private Vector3 mousePosition;
    

    // Start is called before the first frame update
    void Start()
    {
        backgroundMusic = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (lives == 0)
        {
            GameOver();
        }

        PauseGame();
    }

    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int targetIndex = Random.Range(0, targets.Count);
            Instantiate(targets[targetIndex]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void UpdateLive(int livesToAdd)
    {
        lives += livesToAdd;
        liveText.text = "Lives : " + lives;
    }

    public void StartGame(int difficulty)
    {
        titleScreen.gameObject.SetActive(false);
        volumeSlide.gameObject.SetActive(false);

        isGameActive = true;
        score = 0;
        spawnRate /= difficulty; 

        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        UpdateLive(0);
    }

    private void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.timeScale == 1.0f)
            {
                Time.timeScale = 0.0f;
                pauseScreen.gameObject.SetActive(true);
                backgroundMusic.Pause();
            }
            else
            {
                Time.timeScale = 1.0f;
                pauseScreen.gameObject.SetActive(false);
                backgroundMusic.Play();
            }
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        backgroundMusic.Stop();
    }


}
