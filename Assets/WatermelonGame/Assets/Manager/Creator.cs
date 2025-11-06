using UnityEngine;

public class Creator : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject ball;
    public void SpawnBall(int currentBallType, GameObject target)
    {
        target.transform.GetPositionAndRotation(out Vector3 pos, out Quaternion rot);
        GameObject newBall = Instantiate(ball, pos, rot);
        if (newBall.TryGetComponent<SpriteRenderer>(out SpriteRenderer sprRen))
        {
            switch (currentBallType)
            {
                case 0:
                    sprRen.color = Color.red;
                    break;
                case 1:
                    sprRen.color = Color.blue;
                    break;
                case 2:
                    sprRen.color = Color.green;
                    break;
                case 3:
                    sprRen.color = Color.purple;
                    break;
            }
        }
        newBall.transform.localScale = new Vector3(0.5f + 0.5f * currentBallType, 0.5f + 0.5f * currentBallType, 1);
        if(newBall.TryGetComponent<Ball>(out Ball b))
        {
            b.currentBallType = currentBallType;
            b.creator = gameObject;
        }
    }
}
