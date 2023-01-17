using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    private int score;
    public bool IsGameActive;
    public Button restartButton;
    public GameObject TitleScreen;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void GameOver()
    {
        IsGameActive = false;
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
    }
    IEnumerator SpawnTarget()
    {   
        while (IsGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            

        }
    }
    public void updateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score:" + score;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // Update is called once per frame
    public void StartGame(int difficulty)
    {
        IsGameActive = true;
        score = 0;
        spawnRate /= difficulty;
        TitleScreen.gameObject.SetActive(false);
        StartCoroutine(SpawnTarget());
        updateScore(0);
    }
    void Update()
    {
        
    }
}
