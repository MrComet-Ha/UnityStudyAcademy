using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastTest : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;

    private Vector3 horizontalRotate;

    private Transform fireTrans;
    void Start()
    {
        fireTrans = transform.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalRotate = new Vector3(0, 0, - Input.GetAxis("Horizontal"));
        transform.Rotate(horizontalRotate * rotateSpeed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit2D hit = Physics2D.Raycast(fireTrans.position, fireTrans.TransformDirection(Vector2.up), 20);

            Debug.DrawRay(fireTrans.position, fireTrans.TransformDirection(Vector2.up) * 20f, Color.red, 2.0f);
            if (hit)
            {
                Debug.Log(hit.transform.name);
            }
        }
    }
    private void FixedUpdate()
    {
       
    }
}
