using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;
    AttackerSpawner myLaneSpawner;
    Animator animator;
    GameObject projectileSpawner;
    const string PROJECTILES_PARENT_NAME = "Projectiles";

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateParent();
    }

    private void CreateParent()
    {
        projectileSpawner = GameObject.Find(PROJECTILES_PARENT_NAME);
        if(!projectileSpawner)
        {
            projectileSpawner = new GameObject(PROJECTILES_PARENT_NAME);
        }
    }

    private void Update()
    {
        if (animator && IsAttackInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }


    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (var spawner in spawners)
        {
            bool isCloseEnough = Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon;
            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackInLane()
    {
        if(!myLaneSpawner || myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        } else
        {
            return true;
        }
    }

    public void Shoot()
    {
        projectile = Instantiate(projectile, gun.transform);
        projectile.transform.parent = projectileSpawner.transform;
    }
}
