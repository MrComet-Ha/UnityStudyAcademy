using UnityEngine;

public class Instantiate : MonoBehaviour
{

    public GameObject obj;
    Vector3 vec = Vector3.zero;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 5; ++i)
        {
            vec.x = i * (-3) + 6;
            GameObject go = Instantiate(obj, vec, Quaternion.Euler(0.0f, 0.0f, i * 22.5f - 45f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
