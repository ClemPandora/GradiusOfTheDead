using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Double : MonoBehaviour
{
    public float speed;
    
    void Update()
    {
        transform.Translate(new Vector2(1,1)*speed*Time.deltaTime);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Ground"))
        {
            gameObject.SetActive(false);
        }
    }
}
