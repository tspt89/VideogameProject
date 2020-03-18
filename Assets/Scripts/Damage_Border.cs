using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Border : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D thing)
    {
        if (thing.gameObject.tag == "Player" && thing.gameObject.GetComponent<Player>().isAlive)
        {
            thing.gameObject.GetComponent<Player>().Energy -= 5;
            
        }
    }

    void OnTriggerEnter2D(Collider2D thing)
    {
        if (thing.gameObject.tag == "Player" && thing.gameObject.GetComponent<Player>().isAlive)
        {
            thing.gameObject.GetComponent<Player>().Energy -= 5;
            
        }
    }
}
