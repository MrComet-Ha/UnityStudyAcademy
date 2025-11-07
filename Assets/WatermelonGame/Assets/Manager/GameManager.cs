using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private int[] scores = { 1, 2, 4, 8, 16, 32, 64, 128, 256 };
    public int score = 0;
    public bool gameOver = false;
    public void AddScore(int scoreMultiple)
    {
        if (gameOver)
            return;
        score += scores[scoreMultiple];
        scoreText.text = $"Score : {score}";
    }

    public void ChangeColor(int color, GameObject obj)
    {
        if (gameOver)
            return;
        if (obj.TryGetComponent<SpriteRenderer>(out SpriteRenderer sprRen))
        {
            switch(color)
            {
                case 0:
                    sprRen.color = Color.red;
                    break;
                case 1:
                    sprRen.color = Color.orange;
                    break;
                case 2:
                    sprRen.color = Color.yellow;
                    break;
                case 3:
                    sprRen.color = Color.green;
                    break;
                case 4:
                    sprRen.color = Color.blue;
                    break;
                case 5:
                    sprRen.color = Color.darkBlue;
                    break;
                case 6:
                    sprRen.color = Color.purple;
                    break;
            }
        }
        obj.transform.localScale = new Vector3(0.5f * (color + 1), 0.5f * (color + 1), 1);
    }
    public void GameStart()
    {
        SceneManager.LoadScene("WatermelonGame");
    }
}
