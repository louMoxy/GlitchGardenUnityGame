using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float speedOfSpin = 2f;
    [SerializeField] float damageValue = 100f;

    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed, Space.World);
        transform.RotateAround(transform.transform.position, Vector3.back, speedOfSpin * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.GetComponent<Health>();
        Attacker attacker = collision.GetComponent<Attacker>();
        if(attacker && health)
        {
            health.DealDamage(damageValue);
            Destroy(gameObject);
        }
    }

}
