using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingletonGoldManager : MonoBehaviour
{
    public static SingletonGoldManager Instance { get; private set; }
    private int gold = 0;

    private TextMeshProUGUI goldTMP;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Debug.Log("중복객체 파괴");
            Destroy(gameObject);
            return;
        }
        Instance = this;
        SceneManager.sceneLoaded += OnSceneLoaded;
        // 선택적인 구현
        DontDestroyOnLoad(Instance.gameObject);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
            ChangeGold(gold + 5);
        if(Input.GetKeyDown(KeyCode.Space))
            SwitchScene();
    }

    void SwitchScene()
    {
        string curScene = SceneManager.GetActiveScene().name;

        string nextScene = curScene == "BattleScene" ? "SampleScene" : "BattleScene";

        SceneManager.LoadScene(nextScene);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"현재 로드된 씬 : {scene.name}");
        GameObject.Find("GoldText").TryGetComponent<TextMeshProUGUI>(out goldTMP);

        ChangeGold(gold);
    }

    void ChangeGold(int newGold)
    {
        if (goldTMP == null)
            GameObject.Find("GoldText").TryGetComponent<TextMeshProUGUI>(out goldTMP);
        gold = newGold;
        if (goldTMP != null)
            goldTMP.text = $"Gold : {gold}";
    }
}
