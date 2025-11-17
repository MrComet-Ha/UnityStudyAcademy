using UnityEngine;

public class Bullet : PoolLabel
{
    [SerializeField] float bulletSpeed = 150f;
    Rigidbody2D rigid;
    private void OnEnable()
    {
        TryGetComponent<Rigidbody2D>(out rigid);
        if (rigid != null)
            rigid.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.tag == "DestroyWall")
        {
            ReturnPush();
        }
    }

    private void OnDisable()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        rigid.linearVelocity = Vector2.zero;
        rigid.angularVelocity = 0f;
    }
}
