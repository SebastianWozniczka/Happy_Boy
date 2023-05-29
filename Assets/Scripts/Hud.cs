using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public Image tut,health,mana;
    public PlayerMove playerMove;
    public Canvas lose, win;
    public TMP_Text textMeshPro;

    public int p; 
    void Start()
    {
        lose.enabled = false;
        win.enabled = false;
        p = 0;
    }    
    void Update()
    {

        health.fillAmount = 1;
        textMeshPro.text = p.ToString();

        Scene();
        Tutor();     
    }

    private void Scene()
    {
        if (playerMove.countHit == 1)
        {
            health.fillAmount = 0.5f;
        }

        if (playerMove.countHit == 2)
        {
            health.fillAmount = 0f;
        }

        mana.fillAmount = playerMove.countJump / 2;
    }

    private void Tutor()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Destroy(tut, 5);
        }
    }
}
