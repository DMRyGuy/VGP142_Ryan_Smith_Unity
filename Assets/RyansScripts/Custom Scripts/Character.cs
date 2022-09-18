using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController), typeof(Animator))]


public class Character : MonoBehaviour
{
    CharacterController controller;
    Animator anim;

    [Header("Player Settings")]
    [Space(10)]
    [Tooltip("Speed value between 1 and 10")]
    [Range(1.0f, 900.0f)]

    public float speed = 200;
    public float gravity = 9.81f;
    public float jumpSpeed = 25.0f;



    Vector3 moveDir;

    [Header("Weapon Settings")]
    [Space(10)]
    public float projectileForce = 60.0f;
    public Rigidbody projectilePrefab;
    public Transform projectileSpawnPoint;

    public int maxHealth = 10;
    public int currentHealth;

    public HealthBar healthBar;


    // Start is called before the first frame update
    void Start()
    {
        try
        {
            controller = GetComponent<CharacterController>();
            anim = GetComponent<Animator>();
            controller.minMoveDistance = 0.0f;

            if (speed <= 0.0f)
            {
                speed = 25.0f;
                throw new UnassignedReferenceException("Speed not set on " + name + "defaulting to " + speed.ToString());
            }

            if (jumpSpeed <= 0)
            {
                jumpSpeed = 25.0f;
            }
        }

        catch (NullReferenceException e)
        {
            Debug.Log(e.Message);
        }
        catch (UnassignedReferenceException e)
        {
            Debug.Log(e.Message);
        }
        finally
        {
            Debug.Log("this code always runs");
        }

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        if (controller.isGrounded)
        {
            moveDir = new Vector3(horizontal, 0.0f, vertical);
            moveDir *= speed;

            moveDir = transform.TransformDirection(moveDir);

            if (Input.GetButtonDown("Jump"))
            {
                moveDir.y = jumpSpeed;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.SetTrigger("Punch");
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                anim.SetTrigger("Kick");
            }
        }

        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);

        anim.SetFloat("Horizontal", horizontal);
        anim.SetFloat("Vertical", vertical);

        if (Input.GetButtonDown("Fire1"))
            Fire();


        void Fire()
        {
            if (projectilePrefab && projectileSpawnPoint)
            {
                Rigidbody temp = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);

                temp.AddForce(projectileSpawnPoint.forward * projectileForce, ForceMode.Impulse);

                Destroy(temp.gameObject, 2.0f);
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "PickUps")
        {
            TakeDamage(-5);;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(10);
        }
         if (collision.gameObject.tag == "DoT")
        {
            TakeDamage(5);
            Debug.Log("Player is being damaged by Dot effect");
        }
    }

   public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
           SceneManager.LoadScene("GameOver");
        }
    }
}
            




       

       
    

  
