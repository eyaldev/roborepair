using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerBehaviour : MonoBehaviour
{
    public int m_Acceleration=1000;
    public int m_Jump = 400;
    private Rigidbody2D m_RigidBody;

    // Start is called before the first frame update
    void Start()
    {
        m_RigidBody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var moveForce = m_Acceleration * this.m_RigidBody.mass * Time.deltaTime;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.m_RigidBody.AddForce(new Vector2(moveForce, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.m_RigidBody.AddForce(new Vector2(-moveForce, 0));
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            var jumpForce = m_Jump * this.m_RigidBody.mass; //not multipled by time because this is a burst
            this.m_RigidBody.AddForce(new Vector2(0, jumpForce));
        }

    }
}
