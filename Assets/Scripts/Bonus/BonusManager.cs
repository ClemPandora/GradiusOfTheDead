using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    public static BonusManager Instance;
    public BonusIcon[] bonus;
    public float speedAdded;
    public FloatVariable speed;
    public BoolVariable missile;
    public BoolVariable doubleM;
    public BoolVariable laser;
    public IntVariable options;
    public IntVariable barrier;
    
    private int _selected;
    private bool _activ;
    
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        } else if (Instance != null)
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if(Input.GetButtonDown("Fire2") && _activ)
        {
            if (bonus[_selected].CanUse())
            {
                bonus[_selected].Use();
                ApplyBonus();
                bonus[_selected].Deselect();
                _selected = 0;
                _activ = false;
            }
        }
    }

    public void NextBonus()
    {
        if (_activ)
        {
            if (_selected < bonus.Length-1)
            {
                bonus[_selected].Deselect();
                _selected++;
                bonus[_selected].Select();
            }
        }
        else
        {
            _activ = true;
            bonus[_selected].Select();
        }
    }

    public void ApplyBonus()
    {
        switch (_selected)
        {
            //Speed up
            case 0:
                speed.value += speedAdded;
                break;
            //Missile
            case 1:
                missile.value = true;
                break;
            //Double
            case 2:
                doubleM.value = true;
                if (laser.value)
                {
                    laser.value = false;
                    bonus[3].Reset();
                }
                break;
            //Laser
            case 3:
                laser.value = true;
                if (doubleM.value)
                {
                    doubleM.value = false;
                    bonus[2].Reset();
                }
                break;
            //Option
            case 4:
                options.value++;
                break;
            //Barrier
            case 5:
                barrier.value = 4;
                break;
        }
    }
}
