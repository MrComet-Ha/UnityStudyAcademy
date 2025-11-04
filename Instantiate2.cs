using UnityEngine;

public class Instantiate2 : MonoBehaviour
{
    public GameObject obj;
    void Start()
    {
        for(int i = 0; i < 5; ++i)
        {
            GameObject newObj = Instantiate(obj, new Vector3(i * (-3) + 6, (i - 2) * 0.5f, 0), Quaternion.identity);
            if(newObj.TryGetComponent<ObjectMovement>(out ObjectMovement move))
            {
                move.Speed = 3f;
                move.Prequency = 1 + (i * 1.5f);
                move.StartPoint += i * 0.5f;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
