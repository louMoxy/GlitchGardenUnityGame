using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float speedOfSpin = 2f;

    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed, Space.World);
        transform.RotateAround(transform.transform.position, Vector3.back, speedOfSpin * Time.deltaTime);
    }
}
