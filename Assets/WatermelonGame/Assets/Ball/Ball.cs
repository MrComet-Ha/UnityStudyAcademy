using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameManager manager;
    public int currentBallType = 0;
    public Creator creator;
    [SerializeField] private GameObject end;

    private void Start()
    {
        manager.ChangeColor(currentBallType, gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if(collision.gameObject.TryGetComponent<Ball>(out Ball comp))
            {
                if (comp.currentBallType == currentBallType)
                {
                    gameObject.SetActive(false);
                    if (comp.GetInstanceID() < gameObject.GetInstanceID())
                        creator.SpawnBall(currentBallType + 1, transform);
                }
            }
            if (collision.gameObject.tag == "Ball" || collision.gameObject.tag == "Wall")
                end.SetActive(true);
        }
    }
}
