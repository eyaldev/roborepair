using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerBehaviour : MonoBehaviour, ICanPickupLegBonus
{
    int m_Acceleration = 10;
    float m_Jump = 0;
    private Rigidbody2D m_RigidBody;
    public SpriteRenderer m_Sprite;
    public bool m_OnGround;
    public TriggerCollisionDetector m_LegsDetector;
    private float m_JumpUntil;

    public bool OnLegBonus(LegBonusBehavior legBonusBehavior)
    {
        this.gameObject.transform.position += new Vector3(0, 2, 0);
        this.gameObject.transform.localScale *= new Vector2(1, 2);
        //jump twice as high!
        this.m_Jump = 30;
        //consumeTheBonus
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.gravity = new Vector3(0, -30, 0);
        m_RigidBody = this.GetComponent<Rigidbody2D>();
    }



    // Update is called once per frame
    void Update()
    {
        m_OnGround = m_LegsDetector.IsColliding();
        var acceleration = m_Acceleration;
        //infinite friction by default
        //this.m_RigidBody.isKinematic = true;
        this.m_RigidBody.velocity = new Vector2(0, m_RigidBody.velocity.y);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            m_Sprite.flipX = true;
            this.m_RigidBody.velocity += new Vector2(acceleration, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_Sprite.flipX = false;
            this.m_RigidBody.velocity += new Vector2(-acceleration, 0);
        }

        var jumpDuration = 0.5f;
        if (m_OnGround && Input.GetKeyDown(KeyCode.UpArrow))
        {
            m_JumpUntil = Time.time + jumpDuration;
        }

        var timeInJump = m_JumpUntil - Time.time;
        if (timeInJump > 0 && Input.GetKey(KeyCode.UpArrow))
        {
            //jumping;
            this.m_RigidBody.velocity = new Vector2(this.m_RigidBody.velocity.x, m_Jump*timeInJump);
        }
        else
        {
            if (!m_OnGround)
            {
                this.m_RigidBody.velocity = new Vector2(this.m_RigidBody.velocity.x, -20);
            }

        }

        this.m_RigidBody.isKinematic = false;
        //Debug.Log("onGround " + m_OnGround);
        m_OnGround = false;
    }
}
