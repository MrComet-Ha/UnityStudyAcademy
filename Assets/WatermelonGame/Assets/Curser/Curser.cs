using System.IO;
using UnityEngine;

public class Curser : MonoBehaviour
{
    [SerializeField] private GameObject[] pathes = new GameObject[2];
    [SerializeField] private float speed = 1.0f;

    private Vector3[] border = new Vector3[2];

    Vector3 vec = Vector3.zero;
    void Start()
    {
        border[0] = pathes[0].transform.position;
        border[1] = pathes[1].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        vec.x = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        transform.position += vec;
        if (transform.position.x < border[0].x)
            transform.position = border[0];
        if (transform.position.x > border[1].x)
            transform.position = border[1];
    }
}
