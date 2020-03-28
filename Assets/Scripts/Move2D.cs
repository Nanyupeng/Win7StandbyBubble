using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2D : MonoBehaviour
{
    private Rigidbody2D rig;
    private Vector2 m_preVelocity = new Vector2(4, 0);
    // Use this for initialization
    void Start()
    {
        rig = transform.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        transform.Translate(transform.up * 50f * Time.deltaTime, Space.Self);
    }

    //private void OnMouseDown()
    //{
    //    rig.AddForce(new Vector2(1, 0) * 200);
    //}

    public void OnCollisionEnter2D(Collision2D other)
    {
        ContactPoint2D contactPoint = other.contacts[0];//获取接触点
        Vector2 newDir = Vector2.zero;
        Vector2 curDir = transform.TransformDirection(Vector2.right);
        newDir = Vector2.Reflect(curDir, contactPoint.normal);//计算反射角
        Quaternion rotation = Quaternion.FromToRotation(Vector2.right, newDir);
        transform.rotation = rotation;
        Debug.Log(newDir);
        //rig.velocity = newDir.normalized * m_preVelocity.x / m_preVelocity.normalized.x;
    }
}
