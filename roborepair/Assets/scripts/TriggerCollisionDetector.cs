using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCollisionDetector : MonoBehaviour
{
    private bool m_Colliding;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool IsColliding()
    {
        return m_Colliding;
    }

    private void FixedUpdate()
    {
        m_Colliding = false;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        m_Colliding = true;
    }

}
