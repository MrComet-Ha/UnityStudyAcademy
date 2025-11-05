using UnityEngine;

public class MovementGravity : MonoBehaviour
{
    public float jumpPower = 15f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //TryGetComponent<Rigidbody>(out Rigidbody rigid);
            //if (rigid != null)
            //    rigid.AddForce(Vector3.up * jumpPower);
            //TryGetComponent<CharacterController>(out CharacterController charControl);
            //if (charControl != null)
            //{
            //    charControl.Move(Vector3.up * jumpPower);
            //}

        }
    }
}
