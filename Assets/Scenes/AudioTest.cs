using UnityEngine;

public class AudioTest : MonoBehaviour
{
    AudioSource source;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TryGetComponent<AudioSource>(out source);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            source?.Play();
        }
    }
}
