using UnityEngine;

public class GameObjectTest : MonoBehaviour
{
    GameObject obj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        GameObject findObject = GameObject.Find("Enemy");

        if (findObject != null)
        {
            // 효율적인 코드
            if(findObject.TryGetComponent<Rigidbody>(out Rigidbody rig))
            {
                rig.useGravity = true;
            }
            // 비효율적인 코드
            //Rigidbody rigid = findObject.GetComponent<Rigidbody>();
            //if(rigid != null )
            //{
            //    rigid.useGravity = true;
            //}
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

}
