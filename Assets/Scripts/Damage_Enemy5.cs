using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Enemy5 : MonoBehaviour
{
    void OnCollisionExit2D(Collision2D thing)
    {
        if (thing.gameObject.tag == "Player" && thing.gameObject.GetComponent<Player>().isAlive)
        {
            thing.gameObject.GetComponent<Player>().Energy -= 1;
            //thing.gameObject.GetComponent<Animator>().Play("AppleFighter_hurt");
        }
    }

    void OnTriggerStay2D(Collider2D thing)
    {
        if (thing.gameObject.tag == "Player" && thing.gameObject.GetComponent<Player>().isAlive)
        {
            thing.gameObject.GetComponent<Player>().Energy -= 1;
            //thing.gameObject.GetComponent<Animator>().Play("AppleFighter_hurt");
            //thing.gameObject.GetComponent<Player>().effects.clip = thing.gameObject.GetComponent<Player>().pain;
            //thing.gameObject.GetComponent<Player>().effects.Play();
        }
    }
}
