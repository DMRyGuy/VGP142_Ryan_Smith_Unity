using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    EnemyKill enemyKill;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyKill = other.gameObject.GetComponent<EnemyKill>();
            enemyKill.health--;
            Destroy(other.gameObject, 4f); // this destroys the enemy
            Debug.Log(enemyKill.health);
        }
    }
}