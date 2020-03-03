using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed;
    public Sprite baseSprite;
    public Sprite slideSprite;
    private float y;

    private void OnEnable()
    {
        y = -1;
        GetComponent<SpriteRenderer>().sprite = baseSprite;
    }

    void Update()
    {
        transform.Translate(new Vector2(0.5f,y)*speed*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            y = 0;
            GetComponent<SpriteRenderer>().sprite = slideSprite;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            y = -1;
            GetComponent<SpriteRenderer>().sprite = baseSprite;
        }
    }
}
