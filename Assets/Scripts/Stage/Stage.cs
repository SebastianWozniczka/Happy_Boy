using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public GameObject[] Enemies;

    private float timer;
  
    void Start()
    {
        timer = 0;
    }
  
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 20)
        {
            for (int i = 0; i < Enemies.Length; i++)
            Enemies[i].SetActive(true);
        }
    }
}
