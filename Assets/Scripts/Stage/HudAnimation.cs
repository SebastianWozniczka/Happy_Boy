using UnityEngine;

public class HudAnimation : MonoBehaviour
{
    public Animator playerAnim;
    public Animator en1Anim,en2Anim;
    public Hud hud;

    void Update()
    {     
        if (hud.hp < 1)
        {
            playerAnim.SetTrigger("firstTo3");
            en1Anim.SetTrigger("secondToFirst");
            en2Anim.SetTrigger("thirdTo2");          
        }

    }
}
