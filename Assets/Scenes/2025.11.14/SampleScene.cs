using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SampleScene : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI goldText;

    [SerializeField] int gold = 0;

    private void Awake()
    {
        ChangeGold(gold);
    }

    void ChangeGold(int newGold)
    {
        gold = newGold;
        goldText.text = $"Gold : {gold}";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            ChangeGold(gold + 5);
        if (Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene("BattleScene");
    }
}
