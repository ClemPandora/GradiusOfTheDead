using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public BoolVariable missile;
    public BoolVariable doubleM;
    public BoolVariable laser;
    public IntVariable options;
    public GameObject option1;
    public GameObject option2;
    public BoolVariable canMove;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canMove.value)
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

        if (!option1.activeSelf && options.value >= 1)
        {
            option1.transform.position = transform.position;
            option1.SetActive(true);
        }

        if (!option2.activeSelf && options.value >= 2)
        {
            option2.transform.position = option1.transform.position;
            option2.SetActive(true);
        }
    }
}
