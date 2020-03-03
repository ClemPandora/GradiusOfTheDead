using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public BoolVariable canMove;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Ground") || other.CompareTag("Enemy Bullet"))
        {
            GetComponent<Animator>().SetTrigger("Death");
            GetComponent<BoxCollider2D>().enabled = false;
            canMove.value = false;
            Invoke(nameof(End), 3);
        }
    }

    private void End()
    {
        GameplayManager.Instance.GameOver();
    }
}
