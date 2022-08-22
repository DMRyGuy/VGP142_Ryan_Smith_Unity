using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public int health;
    Animator eAnim;

    // Start is called before the first frame update
    void Start()
    {
        eAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
            Death();
    }

    private void Death()
    {
        eAnim.SetTrigger("Death");
    }
}
