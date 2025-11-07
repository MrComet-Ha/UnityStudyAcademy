using UnityEngine;

public class Creator : MonoBehaviour
{
    [SerializeField] GameManager manager;
    [SerializeField] GameObject ball;
    public void SpawnBall(int currentBallType, Transform target)
    {
        if (manager.gameOver)
            return;
        manager.AddScore(currentBallType);
        if (currentBallType == 7)
            return;
        target.GetPositionAndRotation(out Vector3 pos, out Quaternion rot);
        GameObject newBall = Instantiate(ball, pos, rot);
        if(newBall.TryGetComponent<Ball>(out Ball b))
        {
            b.currentBallType = currentBallType;
            b.creator = this;
            b.manager = manager;
        }
    }
}
