using TMPro;
using UnityEngine;

public class GameOverChecker : MonoBehaviour
{
    public GameManager manager;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private float gameOverTime = 0;

    private float gameOverTemp = 0;
    private bool timer = false;
    // Update is called once per frame
    void Update()
    {
        if (gameOverTemp > gameOverTime)
            GameOver();
        if (timer)
        {
            gameOverTemp += Time.deltaTime;
            Debug.Log(gameOverTemp);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
            timer = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
        {
            timer = false;
            gameOverTemp = 0;
        }
    }
    private void GameOver()
    {
        scoreText.text = manager.score.ToString();
        if (gameOverScreen)
            gameOverScreen.SetActive(true);
        manager.gameOver = true;
    }
}
