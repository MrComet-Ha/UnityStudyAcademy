using UnityEngine;

public class PoolLabel : MonoBehaviour
{
    ObjectPool ownerPool;               // 부모 풀
    public void Create(ObjectPool pool) // 부모를 받아온다.
    {
        ownerPool = pool;               // 부모 저장
        gameObject.SetActive(false);    // 자기 자신을 꺼둔다.
    }
    public void ReturnPush()            // 자기 자신 반환
    {
        ownerPool.Push(this);
    }
}
