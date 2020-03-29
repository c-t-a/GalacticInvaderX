using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameController_2D : MonoBehaviour
{
    
    public GameObject[] hazards;
    public GameObject coin,restartButton, goMenuButton,Player;

    public Vector3 spawnValues, coinValues;

    public int hazardCount,coinCount;
    private int score,coinScore;

    public float spawnWait,startWait,waveWait;

    public float timeLeft;
    private bool gameWin,gameOver, restart,shoot;

    public TMP_Text socreText,coinText;
    public Text scoreValue;
    public Image winImage,loseImage,coinImage,collectionCoinImage;
    //private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        collectionCoinImage.enabled = false;
        winImage.enabled = false;
        loseImage.enabled = false;
        coinImage.enabled = false;
        coinText.enabled = false;
        goMenuButton.SetActive(false);
        restartButton.SetActive(false);
        gameWin = false;
        gameOver = false;
        shoot = false;

        //audioSource = GetComponent<AudioSource>();

        StartCoroutine(SpawnWaves());
        updateScore();
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer();
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0,hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
                FindObjectOfType<AudioManager_2D>().Stop("Theme_2D");
                FindObjectOfType<AudioManager_2D>().Play("Losing_2D");
                loseImage.enabled = true;
                goMenuButton.SetActive(true);
                restartButton.SetActive(true);
                break;
            }
            if (gameWin)
            {
                FindObjectOfType<AudioManager_2D>().Stop("Theme_2D");
                FindObjectOfType<AudioManager_2D>().Play("Wining_2D");
                collectionCoinImage.enabled = true;
                coinImage.enabled = true;
                coinText.enabled = true;
                shoot = true;
                yield return new WaitForSeconds(5.0f);
                collectionCoinImage.enabled = false;
                for (int i = 0; i < coinCount; i++)
                {
                    Vector3 coinPosition = new Vector3(Random.Range(-coinValues.x, coinValues.x), coinValues.y, coinValues.z);
                    Vector3 movement = Vector3.down;
                    Quaternion coinRotation = Quaternion.LookRotation(movement);
                    Instantiate(coin, coinPosition, coinRotation);
                    yield return new WaitForSeconds(spawnWait);
                }
                yield return new WaitForSeconds(waveWait);
                Player.SetActive(false);
                winImage.enabled=true;
                goMenuButton.SetActive(true);
                restartButton.SetActive(true);
                break;
            }
        }
    }
    public void addScore(int newScoreValue)
    {
        score += newScoreValue;
        updateScore();
    }
    public void CoinScore(int newCoinValue){
        coinScore += newCoinValue;
        updateScore();
    }
    void updateScore()
    {
        socreText.text = "Score : " + score;

        coinText.text = "X" + coinScore;
    }
    void gameTimer()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            gameWin = true;
        }
    }
    public bool StopShooting() {
        return shoot;
    }
    public void GameOver()
    {
        gameOver = true;
    }
    public void GoMenu() {
        SceneManager.LoadScene("Dashboard");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Main_2D");
    }
}
