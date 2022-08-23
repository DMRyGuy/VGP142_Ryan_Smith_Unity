using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehave : MonoBehaviour
{
    private GameObject nEnemy;
    public Transform playerTransform;
    private Vector3 playerPosition;
    public float speed;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        nEnemy = transform.GetChild(0).gameObject;

        Vector3 enemyPos = nEnemy.transform.position;
        enemyPos.y += 1.5f;

        iTween.MoveTo(nEnemy, enemyPos, 200.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerTransform)
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        else if (speed < 0)
            transform.rotation = playerTransform.rotation;
        else
            transform.LookAt(playerPosition);
        if (playerTransform)
        {
            playerPosition = new Vector3(playerTransform.position.x, 30f, playerTransform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed);
        }
    }
};
