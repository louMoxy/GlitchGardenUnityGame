using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;

    public void DealDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            death();
        }
    }

    private void death()
    {
        if (deathVFX)
        {
            GameObject deathVFXObj = Instantiate(deathVFX, transform.position, transform.rotation);
            Destroy(deathVFXObj, 1f);
        }
        Destroy(gameObject);
    }
}
