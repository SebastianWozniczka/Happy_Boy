
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.VisualScripting.Member;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject flame,mugs;
  
    public GameObject[] mug;
    public GameObject soul;
    public Canvas state;
    public Material mat;
    public Hud hud;
    public SpriteRenderer spriteRenderer;


    public float timeRemaining = 1;
    public bool isAlive = true;  
    public float timer;   
    public float countJump;
    public float countHit;
    public int j;


    void Awake()
    {  
      
        timer = 0;
        countJump = 2;
        countHit = 0;       
    }

    void Update()
    {
        PlayerBehaviour();
    }

    private void PlayerBehaviour()
    {
        if (countHit == 9)
            Die();
        if (isAlive)
        {
            Var();
        }
    }

    internal void Die()
    {
        flame.SetActive(true);     
    }

    private void Var()
    {

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            spriteRenderer.material.SetFloat("Animation Speed",0);
            spriteRenderer.material = mat;
            
            timeRemaining = 0;
        }
          
        if (countHit == 10 || transform.position.y < -10)
        {
            Dissolve();           
        }

        if (j == 10)
        {
            Time.timeScale = 0f;

            hud.win.enabled = true;           
        }

        j = 0;
        for (int i = 0; i < mug.Length; i++)
        {
            if (mug[i] == null)
            {
                j++;
            }
        }
        hud.p = j;
    }

    private void Dissolve()
    {
        isAlive = false;
        //soul.gameObject.active = true;
        soul.GetComponent<SpriteRenderer>().enabled = true;     
        flame.SetActive(false);
        hud.lose.enabled = true;
        hud.health.enabled = false;
        hud.mana.enabled = false;

        timer += Time.deltaTime;
        if (timer > 3)
        {
            SceneManager.LoadScene(0);
            timer = 0;
        }
    }
}
