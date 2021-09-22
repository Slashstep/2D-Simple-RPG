using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemyUnits;
    public List<GameObject> activeUnits = new List<GameObject>();
    public TextMeshProUGUI endgameText;
    public Button restartButton;
    public TextMeshProUGUI playerNameText;

    public bool hasWaveStarted;
    public TextMeshProUGUI waveCounter;

    private int randomX = 13;
    private int randomY = 6;
    private int waveAmount = 5;
    private int currentWave = 1;
    private bool isGameOver;

    void Start()
    {
        WaveSpawnManager();
        playerNameText.text = DataManager.Instance.playerName;
    }

    void Update()
    {
        CheckWaveDone();
    }

    private Vector2 SpawnPosition()
    {
        return new Vector2(Random.Range(-randomX, randomX), Random.Range(-randomY, randomY));
    }

    private int enemyType()
    {
        return Mathf.RoundToInt(Random.Range(0, 2));
    }

    private IEnumerator WaveCountdown()
    {
        yield return new WaitForSeconds(3);
        hasWaveStarted = false;
        StopCoroutine(WaveCountdown());
    }

    private void WaveSpawnManager()
    {
        waveCounter.text = "Wave: " + currentWave.ToString();
        int amountOfEnemys = currentWave + 2;

        for (int i = 0; i < amountOfEnemys; i++)
        {
            var enemy = Instantiate(enemyUnits[enemyType()], SpawnPosition(), enemyUnits[enemyType()].transform.rotation);
        }
        hasWaveStarted = true;
        StartCoroutine(WaveCountdown());
    }

    private void FinalWaveSpawnManager()
    {
        waveCounter.text = "FINAL WAVE";
        int amountOfEnemys = currentWave + 2;

        for (int i = 0; i < amountOfEnemys; i++)
        {
            var enemy = Instantiate(enemyUnits[enemyType()], SpawnPosition(), enemyUnits[enemyType()].transform.rotation);
        }

        Instantiate(enemyUnits[2], new Vector2(0, 4), enemyUnits[2].transform.rotation);
        hasWaveStarted = true;
        StartCoroutine(WaveCountdown());
    }

    private void GameFinished()
    {
        endgameText.text = "You Win!";
        endgameText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        currentWave = 1;
        isGameOver = true;
    }

    public void GameOver()
    {
        endgameText.text = "Game Over";
        endgameText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        currentWave = 1;
        isGameOver = true;

        foreach (GameObject enemy in activeUnits)
        {
            activeUnits.Remove(enemy);
            Destroy(enemy);
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        
        SceneManager.LoadScene(1);
    }

    private void CheckWaveDone()
    {
        if(activeUnits.Count <1 && !isGameOver)
        {
            currentWave++;
            if (currentWave < waveAmount)
                WaveSpawnManager();
            else if (currentWave == 5)
                FinalWaveSpawnManager();
            else if (currentWave == 6)
                GameFinished();
        }
    }

}
