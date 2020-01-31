using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        var collector = collision.gameObject.GetComponent<ICanClimbRopeBehaviour>();
        if (collector != null)
        {
             collector.OnRope(this);
            

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
