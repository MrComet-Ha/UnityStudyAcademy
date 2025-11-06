using UnityEngine;

public class LifeCycle : MonoBehaviour
{
    // 값형 변수(C++에서의 원시형 변수)
    int valueA;
    float valueB;
    Vector2 vec2;
    // 참조형 변수(C++에서의 포인터)
    GameObject obj;

    // 접근 제한자(미표기시 private)
    // [SerializeField] , [HideInInspector] < 유니티의 어트리뷰트
    // [Range] : 범위
    [SerializeField] private int value;
    [HideInInspector]public int Value = 90;
    protected int pValue;
    
    // Prefab이 Instance화 된 직후에 호출됨(Inactive 상태여도 호출됨)
    void Awake()
    {
        
    }
    // 오브젝트의 상태가 Active가 됐을 때마다 호출
    void OnEnable()
    {

    }
    // 첫번째 프레임의 Update가 호출되기 직전에 1회성으로 호출(Active 상태에서만 호출)
    void Start()
    {
        Debug.Log(Value);
    }
    // 물리 계산 프레임
    void FixedUpdate()
    {
        
    }
    // 매 프레임마다 호출
    void Update()
    {
        
    }
    // 매 프레임의 Update가 끝날 때마다 호출
    void LateUpdate()
    {

    }
    // Inactive 상태가 될 때마다 호출됨(Destroy 포함)
    private void OnDisable()
    {

    }
    // Destroy 될 때 호출됨
    private void OnDestroy()
    {

    }
}
