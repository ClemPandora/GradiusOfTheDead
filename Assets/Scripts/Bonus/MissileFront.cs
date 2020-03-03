using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileFront : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Ground"))
        {
            transform.parent.gameObject.SetActive(false);
        }
    }
}
