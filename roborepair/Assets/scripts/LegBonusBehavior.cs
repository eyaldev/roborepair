using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegBonusBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collector=collision.gameObject.GetComponent<ICanPickupLegBonus>();
        if (collector != null)
        {
            bool pickedUp = collector.OnLegBonus(this);
            if (pickedUp)
            {
                GameObject.Destroy(this.gameObject);
                Debug.Log("leg bonus picked up");
            }

        }
    }

}
