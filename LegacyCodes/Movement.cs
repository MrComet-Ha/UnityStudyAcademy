using NUnit.Framework;
using System.Collections;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    int move = 0;
    bool moving = true;
    bool moveFront = true;

    public float speed = 2.0f;
    public Vector3[] movePoints = new Vector3[4];

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            move += moveFront ? 1 : -1;
            if (move > 3)
            {
                moveFront = false;
                move = 3;
            }
            else if (move < 0)
            {
                moveFront = true;
                move = 0;
            }
            moving = false;
        }
        transform.position = Vector3.MoveTowards(transform.position, movePoints[move], speed * Time.deltaTime);
        if (transform.position == movePoints[move])
            moving = true;
    }
}
