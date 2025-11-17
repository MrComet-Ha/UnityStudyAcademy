using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

// 오브젝트 관리 역할
// 게임 시작시 미리 오브젝트 생성 후 비활성화,
// 필요할 때 활성화해줄 예정
// 반환도 받음

public class ObjectPool : MonoBehaviour
{
    [SerializeField] int allocateCount = 32;
    [SerializeField] PoolLabel poolObj;

    private Stack<PoolLabel> poolStack = new Stack<PoolLabel>();

    private void Awake()
    {
        // 미리 필요한 만큼 생성
        for (int i = 0; i < allocateCount; ++i)
        {
            Allocate();
        }
    }
    
    private void Allocate()
    {
        PoolLabel label = Instantiate(poolObj,transform);
        // 함수 호출 파트
        label.Create(this);
        poolStack.Push(label);
    }
    
    private PoolLabel Spawn()
    {
        PoolLabel label = Instantiate(poolObj, transform);
        // 함수 호출 파트
        label.Create(this);
        return label;
    }
    public GameObject Pop(Vector3 position, Quaternion rotation)
    {
        PoolLabel obj;
        if (poolStack.Count != 0)
            obj = poolStack.Pop();
        else
            obj = Spawn();
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.gameObject.SetActive(true);
        return obj.gameObject;
    }

    public void Push(PoolLabel label)
    {
        label.gameObject.SetActive(false);
        poolStack.Push(label);
    }
}
