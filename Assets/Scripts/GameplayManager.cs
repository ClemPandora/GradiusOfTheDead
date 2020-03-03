using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance;
    public FloatVariable speed;
    public BoolVariable missile;
    public BoolVariable doubleM;
    public BoolVariable laser;
    public IntVariable options;
    public IntVariable barrier;
    public BoolVariable canMove;
    
    void Awake()
    {
        Screen.SetResolution(256, 240, true);
        if(Instance == null)
        {
            Instance = this;
        } else if (Instance != null)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        speed.value = 2;
        missile.value = false;
        doubleM.value = false;
        laser.value = false;
        options.value = 0;
        barrier.value = 0;
        canMove.value = true;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
