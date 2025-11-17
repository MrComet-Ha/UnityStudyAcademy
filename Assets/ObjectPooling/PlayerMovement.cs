using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 p_lotation = Vector3.zero;
    Vector3 b_position = Vector3.zero;
    [SerializeField] Transform spawn_pos;
    [SerializeField] float rotateSpeed = 1f;
    [SerializeField] float shootTime = 0.3f;
    bool canShoot = true;
    float shootDelta = 0f;
    ObjectPool projectilePool;

    private void Awake()
    {
        GameObject obj = GameObject.Find("ProjectilePool");
        if (!obj.TryGetComponent<ObjectPool>(out projectilePool))
            Debug.Log("Pool 참조 실패");
    }
    void Movement()
    {
        p_lotation.z = -Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed;
        transform.Rotate(p_lotation);
        if (Input.GetKeyDown(KeyCode.Space))
            Shoot();
    }

    void Shoot()
    {
        if (canShoot)
        {
            b_position = spawn_pos.position;
            GameObject obj = projectilePool.Pop(b_position, transform.rotation);
            if (obj != null)
                canShoot = false;
        }
    }
    void Update()
    {
        Movement();
        if (!canShoot)
        {
            shootDelta += Time.deltaTime;
            if (shootDelta > shootTime)
            {
                canShoot = true;
                shootDelta = 0f;
            }
        }
    }
}
