using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

// 오브젝트 관리 역할
// 게임 시작시 미리 오브젝트 생성 후 비활성화,
// 필요할 때 활성화해줄 예정
// 반환도 받음

public class ObjectPool : MonoBehaviour
{
    [SerializeField] int allocateCount = 32;                        // 최초로 생성할 풀의 크기
    [SerializeField] PoolLabel poolObj;                             // 소환할 오브젝트

    private Stack<PoolLabel> poolStack = new Stack<PoolLabel>();    // 오브젝트를 관리할 풀(스택으로 구현)

    private void Awake()                                            // 오브젝트 풀이 생성되면
    {
        // 미리 필요한 만큼 생성
        for (int i = 0; i < allocateCount; ++i)                     // 최초로 생성할 풀의 크기만큼
        {
            Allocate();                                             // 풀에 추가
        }
    }
    
    private void Allocate()                                         // 풀에 오브젝트를 추가해주는 메서드
    {
        PoolLabel label = Instantiate(poolObj,transform);           // 오브젝트를 생성
        // 함수 호출 파트
        label.Create(this);                                         // 하고 관리해줄 풀을 이 풀로 설정
        poolStack.Push(label);                                      // 스택에 생성한 오브젝트를 넣어줌
    }
    
    //private PoolLabel Spawn()
    //{
    //    PoolLabel label = Instantiate(poolObj, transform);          
    //    // 함수 호출 파트
    //    label.Create(this);
    //    return label;
    //}

    public GameObject Pop(Vector3 position, Quaternion rotation)    // 오브젝트 반환 메서드
    {
        if (poolStack.Count < 1)                                    // 현재 스택이 비어있다면
            Allocate();                                             // 풀에 오브젝트를 추가
        PoolLabel obj = poolStack.Pop();                            // 사용할 오브젝트는 스택의 가장 위에 있는 오브젝트
        //else
        //    obj = Spawn();
        obj.transform.position = position;                          // 위치와
        obj.transform.rotation = rotation;                          // 회전 각도를 설정
        obj.gameObject.SetActive(true);                             // 오브젝트 활성화 하고
        return obj.gameObject;                                      // 사용할 오브젝트를 반환
    }

    public void Push(PoolLabel label)                               // 오브젝트 회수 메서드           
    {
        label.gameObject.SetActive(false);                          // 오브젝트를 비활성화하고
        poolStack.Push(label);                                      // 스택에 다시 넣어두기
    }
}
