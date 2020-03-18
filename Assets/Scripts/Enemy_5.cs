using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_5 : MonoBehaviour
{
    Animator EnemyAnim;
    Rigidbody2D EnemyRB;
    // Start is called before the first frame update
    void Start()
    {
        EnemyAnim = GetComponent<Animator>();
    }

    public void Attack()
    {
        int RandomNumber = Random.Range(1, 7);
        EnemyAnim.Play("Goblin_" + RandomNumber);
    }
}
