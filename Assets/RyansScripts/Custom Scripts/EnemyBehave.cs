using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehave : MonoBehaviour
{
    private GameObject nEnemy;

    // Start is called before the first frame update
    void Start()
    {
        nEnemy = transform.GetChild(0).gameObject;

        Vector3 enemyPos = nEnemy.transform.position;
        enemyPos.y += 5.0f;

        iTween.MoveTo(nEnemy, enemyPos, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
};
