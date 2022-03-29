using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{

    public float moveSpeed = 0.2f;

    public Transform ground1;
    public Transform ground2;

    public Transform ground1Pos;
    public Transform ground2Pos;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        ground1.position += Vector3.left * moveSpeed * Time.deltaTime;
        ground2.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (ground1.position.x <= -29f)
        {
            ground1.position = new Vector3(ground2Pos.position.x, ground1.position.y, ground1.position.z);
        }
        if (ground2.position.x <= -29f)
        {
            ground2.position = new Vector3(ground1Pos.position.x, ground2.position.y, ground2.position.z);
        }
    }
}
