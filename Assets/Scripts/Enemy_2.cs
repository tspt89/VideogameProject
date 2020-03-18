using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : MonoBehaviour
{
    Animator EnemyAnim;
    Rigidbody2D EnemyRB;
    // Start is called before the first frame update
    void Start()
    {
        EnemyAnim = GetComponent<Animator>();
    }

    public void AttackEnemy2()
    {
        int RandomNumber = Random.Range(1, 6);
        EnemyAnim.Play("Gollem2_" + RandomNumber);
    }
}
