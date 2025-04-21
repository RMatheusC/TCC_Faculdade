using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jog_anim : MonoBehaviour
{
    private Jogador player;
    private Animator anim;
    private Jogador_status sts;
    private Warrior wr;
    private bool isHitting = false;
    private float timeCoutn;
    private float recoveryTime = 1.5f;

    [Header("Area do Ataque")]
    [SerializeField] private Transform AtkPoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask EnemyLayer;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Jogador>();
        anim = GetComponent<Animator>();
        sts = GetComponent<Jogador_status>();
        wr = GetComponent<Warrior>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();

        if (isHitting) {
            timeCoutn += Time.deltaTime;

            if (timeCoutn >= recoveryTime)
            {
                isHitting = false;
                timeCoutn = 0f;
            }
        }
    }

    public void OnMove()
    {
        switch (player.direction.sqrMagnitude)
        {
            case 0:
                anim.SetInteger("transition", 0);
                break;
            case 1:
                if (player.direction.y > 0)
                {
                    anim.SetInteger("transition", 1);
                }
                else if (player.direction.y < 0)
                {
                    anim.SetInteger("transition", 4);
                }
                if (player.direction.x < 0)
                {
                    anim.SetInteger("transition", 2);
                }
                else if (player.direction.x > 0)
                {
                    anim.SetInteger("transition", 3);
                }
                break;
        }

    }

    public void OnHit(int dmg) {
        if (!isHitting) {
            anim.SetTrigger("hit");
            isHitting = true;
            sts.currentlife -= dmg;

            if (sts.currentlife <= 0) {
                anim.SetTrigger("death");
            }
        }         
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(AtkPoint.position, radius);
    }
}


