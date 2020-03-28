using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed;

    void Awake()
    {
    }

    void FixedUpdate()
    {
        transform.Translate(transform.up * moveSpeed * Time.deltaTime, Space.World);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "wall")
        {
            float angleValue = Vector3.Angle(transform.up, other.transform.up);
            Vector3 reflect = Vector3.Reflect(transform.position, other.transform.position);
            transform.position = reflect;
            if (angleValue < 90)
            {
                transform.eulerAngles += new Vector3(0, 0, 2 * angleValue);
            }
            else if (Vector3.Angle(transform.up, other.transform.up) > 90)
            {
                transform.eulerAngles -= new Vector3(0, 0, 360 - 2 * angleValue);
            }
            else
            {
                transform.eulerAngles += new Vector3(0, 0, 180);
            }
        }
    }
}
