using UnityEngine;
using UnityEngine.Device;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject creator;
    [SerializeField] private float coolTime;
    [SerializeField] [Range(0,3)] private int currentBallType = 0;
    [SerializeField] bool canSpawn = true;
    float coolTemp = 0;

    private Creator cre;

    // Update is called once per frame

    private void Start()
    {
        ChangeBall();
        creator.TryGetComponent<Creator>(out cre);
    }

    void Update()
    {
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
            cre.SpawnBall(currentBallType, gameObject);
            ChangeBall();
        }
    }

    void ChangeBall()
    {
        currentBallType = Random.Range(0, 4);
        if(TryGetComponent<SpriteRenderer>(out SpriteRenderer sprRen))
        {
            switch (currentBallType)
            {
                case 0:
                    sprRen.color = Color.red;
                    break;
                case 1:
                    sprRen.color = Color.blue;
                    break;
                case 2:
                    sprRen.color = Color.green;
                    break;
                case 3:
                    sprRen.color = Color.purple;
                    break;
            }
        }
        transform.localScale = new Vector3(0.5f + (0.5f * currentBallType), 0.5f + (0.5f * currentBallType), 1);
    }
}
