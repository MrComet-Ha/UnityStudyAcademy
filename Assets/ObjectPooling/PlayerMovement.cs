using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 p_lotation = Vector3.zero;                              // 플레이어 회전 각도
    Vector3 b_position = Vector3.zero;                              // 탄환 소환 위치(실제로 사용할 Vector3 멤버)
    [SerializeField] Transform spawn_pos;                           // 탄환 소환 위치(Transform으로 받아두기 위한 멤버)
    [SerializeField] float rotateSpeed = 1f;                        // 플레이어 회전 속도
    [SerializeField] float shootTime = 0.3f;                        // 사격 쿨타임(쿨타임을 비교하는 용도)
    bool canShoot = true;                                           // 현재 사격 가능한지 세주기 위한 용도
    float shootDelta = 0f;                                          // 사격 쿨타임(실제로 쿨타임을 세어주는 용도)
    ObjectPool projectilePool;                                      // 오브젝트 풀(탄환을 꺼내쓰기 위해)

    private void Awake()                                            // 플레이어가 생성될 때 이하의 코드 실행
    {
        GameObject obj = GameObject.Find("ProjectilePool");         // ProjectilePool 이라고 이름 붙은 오브젝트를 찾아서
        if (!obj.TryGetComponent<ObjectPool>(out projectilePool))   // ObjectPool 컴포넌트를 찾았을 때, Null이 나온다면(찾지 못했다면)
            Debug.Log("Pool 참조 실패");                            // Pool 참조 실패 라는 디버그 로그를 띄운다.
    }
    void Movement()                                                 // 이동을 관리하는 메서드
    {
        p_lotation.z = 
        -Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed;// 회전 값을 Horizontal(A,D)에 따라 결정해서 
        transform.Rotate(p_lotation);                               // 회전시킨다.
        if (Input.GetKeyDown(KeyCode.Space))                        // Space를 누르면
            Shoot();                                                // Shoot 메서드 호출
    }

    void Shoot()                                                    // 탄환을 쏘는 메서드
    {
        if (canShoot)                                               // 지금 사격 가능하다면
        {
            b_position = spawn_pos.position;                        // 소환 위치를 정하고
            GameObject obj = 
            projectilePool.Pop(b_position, transform.rotation);     // 풀에서 꺼내서 활성화 해준다.
            if (obj != null)                                        // 오브젝트를 발사하는 것에 성공했다면
                canShoot = false;                                   // 사격 쿨타임을 센다.
        }
    }
    void Update()
    {
        Movement();                                                 // Movement메서드를 매 프레임마다 호출
        if (!canShoot)                                              // 지금 사격할 수 없는 상태라면
        {
            shootDelta += Time.deltaTime;                           // 사격 쿨타임을 매 프레임마다 채우고
            if (shootDelta > shootTime)                             // 사격 쿨타임이 돌았다면
            {
                canShoot = true;                                    // 사격 가능하게 해주고
                shootDelta = 0f;                                    // 사격 쿨타임을 다시 셀 수 있도록 초기화
            }
        }
    }
}
