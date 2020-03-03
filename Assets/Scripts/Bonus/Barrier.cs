using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public IntVariable life;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Enemy Bullet"))
        {
            life.value--;
            if (life.value <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
