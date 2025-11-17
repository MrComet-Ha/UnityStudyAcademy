using UnityEngine;

public class PoolLabel : MonoBehaviour
{
    ObjectPool ownerPool;
    public void Create(ObjectPool pool)
    {
        ownerPool = pool;
        gameObject.SetActive(false);
    }

    public void ReturnPush()
    {
        ownerPool.Push(this);
    }
}
