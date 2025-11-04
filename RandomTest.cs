using UnityEngine;

public class RandomTest : MonoBehaviour
{
    float time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 0.5f)
        {
            // 0~59까지 랜덤으로 출력
            Debug.Log(Random.Range(0, 60));
            Debug.Log(Random.insideUnitCircle);
            time = 0;
        }
    }
}
