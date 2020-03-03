using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class Option : MonoBehaviour
{
    public BoolVariable missile;
    public BoolVariable doubleM;
    public BoolVariable laser;
    public FloatVariable speed;
    public float distance;
    public Transform target;

    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) >= distance)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                target.position, (speed.value+2)*Time.deltaTime);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (laser.value)
            {
                GameObject bullet = ObjectPooler.Instance.GetPooledObject("Laser Bullet");
                if (bullet != null)
                {
                    bullet.transform.position = transform.position;
                    bullet.SetActive(true);
                }
            }
            else
            {
                GameObject bullet = ObjectPooler.Instance.GetPooledObject("Player Bullet");
                if (bullet != null)
                {
                    bullet.transform.position = transform.position;
                    bullet.SetActive(true);
                }
            }

            if (doubleM.value)
            {
                GameObject bullet = ObjectPooler.Instance.GetPooledObject("Double Bullet");
                if (bullet != null)
                {
                    bullet.transform.position = transform.position;
                    bullet.SetActive(true);
                }
            }

            if (missile.value)
            {
                GameObject bullet = ObjectPooler.Instance.GetPooledObject("Missile Bullet");
                if (bullet != null)
                {
                    bullet.transform.position = transform.position;
                    bullet.SetActive(true);
                }
            }
        }
    }

}
