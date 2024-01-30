using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public Image tut,health,mana;
    public PlayerMove playerMove;
    public Canvas lose, win;
    public TMP_Text textMeshPro;
   
    public float hp;
    public int p;
  
    private float h = 1;
        
    void Start()
    {
        lose.enabled = false;
        win.enabled = false;
        hp = 1;
        p = 0;
    }    
    void Update()
    {        
        Scene();
        Tutor();     
    }

    private void Scene()
    {
        if (hp >= 1)
            hp = 1;

        textMeshPro.text = p.ToString();
        health.fillAmount = h - playerMove.countHit / 10;
        hp = health.fillAmount;
        mana.fillAmount = playerMove.countJump / 2;
    }

    public void Damage()
    {
        playerMove.countHit++;
       
    }

    private void Tutor()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Destroy(tut, 5);
        }
    }
}
