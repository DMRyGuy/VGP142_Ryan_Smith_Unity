using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkInCircles : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = 1.0f;



    // Update is called once per frame
    private void Update()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
        transform.Rotate(0f, -1f, 0f);
        
    }
}
