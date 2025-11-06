using UnityEngine;

public class Ball : MonoBehaviour
{
    public int currentBallType = 0;
    public GameObject creator;
    [SerializeField] private GameObject end;
    Creator cre;
    void Start()
    {
        creator.TryGetComponent<Creator>(out cre);
     
    }

    // Update is called once per frame
    void Update()
    {
        
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
                    {
                        cre.SpawnBall(currentBallType + 1, gameObject);
                    }
                }
            }
            if (collision.gameObject.tag == "Ball" || collision.gameObject.tag == "Wall")
                end.SetActive(true);
        }
    }
}
