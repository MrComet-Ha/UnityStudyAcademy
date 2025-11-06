using UnityEngine;

public class InstantiateTest : MonoBehaviour
{
    float time = 0;
    [SerializeField] private GameObject prefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 0.5f)
        {
            Vector3 spawnPos = Random.insideUnitSphere * 10f;
            Instantiate(prefab, spawnPos, Quaternion.identity);
            time = 0;
        }
    }
}
