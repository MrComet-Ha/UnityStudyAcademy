using UnityEngine;

public class Bullet : PoolLabel
{
    [SerializeField] float bulletSpeed = 150f;                              // 탄환 이동 속도
    Rigidbody2D rigid;                                                      // AddForce를 쓰기 위한 리지드바디 참조
    private void OnEnable()
    {
        TryGetComponent<Rigidbody2D>(out rigid);                            // TryGetComponent를 통해 rigid에 Rigidbody2D 컴포넌트를 적용
        if (rigid != null)                                                  // 컴포넌트를 찾았다면
            rigid.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);// transform의 up 방향으로 속도만큼 날아간다.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.tag == "DestroyWall") // 현재 트리거끼리 충돌중이고, 그 태그가 DestroyWall이라면
        {
            ReturnPush();                                                   // 탄환을 반환시킨다.
        }
    }

    private void OnDisable()                                                // 꺼질 때
    {
        transform.position = Vector3.zero;                                  // 위치를 초기화
        transform.rotation = Quaternion.identity;                           // 회전각도를 초기화
        rigid.linearVelocity = Vector2.zero;                                // 속도를 0으로 초기화
        rigid.angularVelocity = 0f;                                         // 회전 속도도 0으로 초기화
    }
}
