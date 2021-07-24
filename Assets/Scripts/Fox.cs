using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;
        Animator animator = GetComponent<Animator>();
        if (gameObject.GetComponent<Gravestone>())
        {
            animator.SetTrigger("jumpTrigger");
        }
        else if (gameObject.GetComponent<Defender>()) {
            GetComponent<Attacker>().Attack(gameObject);
        }

    }
}
