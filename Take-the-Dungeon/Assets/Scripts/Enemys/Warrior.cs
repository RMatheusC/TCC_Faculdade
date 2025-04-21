using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Warrior : MonoBehaviour
{
    [SerializeField] public NavMeshAgent agent;
    private Jogador player;
    private Jogador_status jgsts;

    public Animator anim;
    private Jog_anim Player;
    private bool isHitting = false;
    private float timeCoutn;
    private float recoveryTime = 1.2f;

    [SerializeField] private Transform atakPoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask playerLayer;

    #region Status
    public float life = 15;
    public int dmg = 7;
    #endregion
    void Start()
    {
        jgsts = FindObjectOfType<Jogador_status>();
        player = FindObjectOfType<Jogador>();
        anim = GetComponent<Animator>();
        Player = FindObjectOfType<Jog_anim>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        Death();
        ia();
        Attak();
    }

    #region I.A
    public void ia() {

        agent.SetDestination(player.transform.position);

        if (Vector2.Distance(transform.position, player.transform.position) <= agent.stoppingDistance)
        {
            playAnim(1);
        }
        else
        {
            playAnim(2);
        }

        float posx = player.transform.position.x - transform.position.x;

        if (posx > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 180);
        }

    }
    #endregion

    #region Status
    public void Death() {
        if (life <= 0)
        {
            OnDeath(true);
            jgsts.currentxp += 0.3f;
            jgsts.lvlUp();
        }
        if (life <= 0)
        {
            agent.speed = 0;
        }
    }
    public void Attak() {
        if (isHitting)
        {
            timeCoutn += Time.deltaTime;

            if (timeCoutn >= recoveryTime)
            {
                isHitting = false;
                timeCoutn = 0f;
            }
        }
    }
    #endregion

    #region Animation
    public void playAnim(int value)
    {
        anim.SetInteger("transition", value);
    }

    public void Dano()
    {
        Collider2D hit = Physics2D.OverlapCircle(atakPoint.position, radius, playerLayer);

        if (hit != null)
        {
            Player.OnHit(dmg);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Arrow") || collision.CompareTag("Magic"))
        {
            anim.SetTrigger("hit");
            isHitting = true;
            life -= jgsts.dmg;
        }
    }
    public void OnDeath(bool dead = false)
    {
        if (dead == true)
        {
            anim.SetTrigger("death");
            Destroy(gameObject, 0.7f);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(atakPoint.position, radius);
    }
    #endregion
}
