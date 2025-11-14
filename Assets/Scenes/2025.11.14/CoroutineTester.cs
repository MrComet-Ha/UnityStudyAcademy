using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CoroutineTester : MonoBehaviour
{
    Coroutine cor;
    WaitForSeconds sec = new WaitForSeconds(1f);
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (cor != null)
                StopCoroutine(cor);
            //cor = StartCoroutine("CoroutineTest");
            cor = StartCoroutine("CoroutineTest2");     // 이런 식으로도 가능하지만...
            Invoke("PrintMess", 2f);                    // Invoke를 통해 사용하는 게 더 좋다.(내부적으로 부담이 적다)
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (cor != null)
                StopCoroutine(cor);
        }
    }
    void PrintMess()
    {
        Debug.Log("실행하고 끝냄2");
    }
    IEnumerator CoroutineTest()
    {
        while (true)
        {
            Debug.Log($"{Time.time} - 1");
            yield return null;
            Debug.Log($"{Time.time} - 2");
        }
        //yield return new WaitForSeconds(2f);
        //Debug.Log($"{Time.time} - 3");
        //yield return new WaitForFixedUpdate();
        //Debug.Log($"{Time.time} - 4");
        //yield return new WaitForSecondsRealtime(2f);
        //Debug.Log($"{Time.time} - 5");
        //yield return new WaitForEndOfFrame();
        //Debug.Log($"{Time.time} - 6");
    }
    IEnumerator CoroutineTest2()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("실행하고 끝냄");
    }
}
