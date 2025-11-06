using UnityEngine;

public class MathfTest : MonoBehaviour
{
    float time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(Mathf.Cos(50.0f));
        Debug.Log(Mathf.Cos(50.0f * Mathf.Deg2Rad));    // 각도 계산
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Vector3 vec = new Vector3(0, 3f * Mathf.Sin(time), 0);
        transform.position = vec;
    }
}
