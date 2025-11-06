using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float Speed = 1.0f;
    public float Prequency = 1.0f;
    public float StartPoint = 0f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Mathf.Sin(Time.time * Prequency + StartPoint) * Time.deltaTime * Speed);
    }
}
