using UnityEngine;

public class TimeTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 게임 내 흐르는 시간 변경
        Time.timeScale = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        // 시간 표기
        Debug.Log($"Time : {Time.time} deltaTime : {Time.deltaTime}");
    }
}
