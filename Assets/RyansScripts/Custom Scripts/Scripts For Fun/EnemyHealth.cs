using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*public class EnemyHealth : MonoBehaviour
{

   /* [SerializeField]
    private int maxHealth = 100;

    private int currentHealth;

    public event Action<float> OnHealthPctChanged = delegate { };

    private void OnEnable ()
    {
        currentHealth = maxHealth;
    }

    publicvoid ModifyHealth(int amount)
    {
        currentHealth += amount;

        float currenHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged(currentHealthPct);
    }

    /*public int health;
    Animator eAnim;

    // Start is called before the first frame update
    void Start()
    {
        eAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            ModifyHealth(-10);

        if (health <= 0)
            Death();
    }

    private void Death()
    {
        eAnim.SetTrigger("Death");
    }
}*/