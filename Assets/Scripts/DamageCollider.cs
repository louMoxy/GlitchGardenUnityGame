using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // destroy gameobject
        Destroy(collision.gameObject);
        // remove health
        FindObjectOfType<PlayerHealthDisplay>().takeLife();
    }
}
