using UnityEngine;

public interface IDamage
{
    public abstract void Take();
    public virtual void Damaged() { }
}

public class TransformTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform : 현재 오브젝터의 Transform 멤버
        // Vector3.forward = Vector3(0,0,1);
        // deltaTime = 매 프레임의 시간
        // 방향 벡터로 이동시키기
        // Vector3.up, Vector3.down 등...
        //transform.Translate(Vector3.forward * (1f * Time.deltaTime));
        transform.Translate(new Vector3(1, -1, 0) * 1f * Time.deltaTime);
    }
}
