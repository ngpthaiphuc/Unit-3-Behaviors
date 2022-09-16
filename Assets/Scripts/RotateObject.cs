using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 0.5f;
    [SerializeField] Vector3 rotateDirection;

    //float totalRotateDistance;
    //Quaternion startingOrientation;
    int curTime;

    // Start is called before the first frame update
    void Start()
    {
        curTime = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (curTime > 500)
        {
            FlipMoveDirection();
        }

        gameObject.transform.Rotate(rotateDirection * rotateSpeed);

        curTime++;
    }

    void FlipMoveDirection()
    {
        curTime = 0;
        rotateDirection = -rotateDirection;
    }
}
