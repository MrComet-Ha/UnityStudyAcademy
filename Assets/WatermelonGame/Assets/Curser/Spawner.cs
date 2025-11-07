using UnityEngine;
using UnityEngine.Device;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameManager manager;
    [SerializeField] private Creator creator;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private float coolTime;
    [SerializeField] [Range(0,3)] private int currentBallType = 0;
    [SerializeField] bool canSpawn = true;
    float coolTemp = 0;

    // Update is called once per frame

    private void Start()
    {
        ChangeBall();
    }

    void Update()
    {
        if (manager.gameOver)
            return;
        if (!canSpawn)
        {
            coolTemp += Time.deltaTime;
            if (coolTemp > coolTime)
            {
                coolTemp = 0;
                canSpawn = true;
            }
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            canSpawn = false;
            creator.SpawnBall(currentBallType, spawnPos);
            ChangeBall();
        }
    }

    void ChangeBall()
    {
        currentBallType = Random.Range(0, 4);
        manager.ChangeColor(currentBallType, gameObject);
    }
}
