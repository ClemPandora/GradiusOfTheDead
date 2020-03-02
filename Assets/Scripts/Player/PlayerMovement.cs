using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public FloatVariable speed;
    public BoolVariable canMove;
    
    private Vector2 _screenBounds;
    private float _objectWidth;
    private float _objectHeigth;
    private Animator _anim;
    
    void Start()
    {
        //On récupère la taille de l'écran
        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        _objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        _objectHeigth = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
        _anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        //Si on peut bouger
        if (canMove.value)
        {
            //On déplace le joueur selon les inputs
            transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * (Time.deltaTime * speed.value));
            _anim.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));
        }

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = ObjectPooler.Instance.GetPooledObject("Player Bullet");
            if (bullet != null) {
                bullet.transform.position = transform.position;
                bullet.SetActive(true);
            }
        }
    }
    
    void LateUpdate()
    {
        //On bloque le player aux bords de l'écran
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, _screenBounds.x * -1 + _objectWidth, _screenBounds.x - _objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, _screenBounds.y * -1 + _objectHeigth, _screenBounds.y - _objectHeigth);
        transform.position = viewPos;
    }
}
