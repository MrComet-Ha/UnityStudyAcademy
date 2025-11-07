using System.IO;
using UnityEngine;

public class Curser : MonoBehaviour
{
    [SerializeField] private GameManager manager;
    [SerializeField] private Transform[] pathes = new Transform[2];
    [SerializeField] private float speed = 1.0f;

    Vector3 vec = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        if (manager.gameOver)
            return;
        vec.x = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        transform.position += vec;
        if (transform.position.x < pathes[0].position.x)
            transform.position = pathes[0].position;
        if (transform.position.x > pathes[1].position.x)
            transform.position = pathes[1].position;
    }
}
