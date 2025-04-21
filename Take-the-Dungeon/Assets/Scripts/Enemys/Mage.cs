using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Mage : MonoBehaviour
{
    [SerializeField] private Transform ceter;
    [SerializeField]private Animator aniMage;
    [SerializeField]private NavMeshAgent agent;
    private Jogador_status jgsts;
    private bool death = false;
    private Jogador player;
    private float timeCoutn;
    private float recoveryTime = 1.2f;
    private bool isHitting = false;
    bool detected = false;

    public GameObject magic;
    public Transform target;
    public float range;

    #region Status
    public float life = 12;
    public int dmg = 4;

    #endregion
    void Start()
    {
        player = FindObjectOfType<Jogador>();
        jgsts = FindObjectOfType<Jogador_status>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    void Update()
    {
        OnDeath();
        AniAll();

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

    public void OnDeath() {
        if (life <= 0)
        {
            aniMage.SetTrigger("death");
            agent.speed = 0;
            Destroy(gameObject, 0.7f);
            jgsts.currentxp += 0.15f;
            jgsts.lvlUp();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Arrow") || collision.CompareTag("Magic") || collision.CompareTag("Sword"))
        {
            aniMage.SetTrigger("hit");
            isHitting = true;
            life -= jgsts.dmg;
        }
    }

    public void shoot() {
        GameObject magics = Instantiate(magic, ceter.position, Quaternion.identity);
        Instantiate(magic, ceter.position, transform.rotation);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(ceter.position,range);

    }


    public void AniAll() {
        agent.SetDestination(player.transform.position);

        if (Vector2.Distance(transform.position, player.transform.position) <= agent.stoppingDistance)
        {
            aniMage.SetInteger("transition", 2);
            shoot();
        }
        else
        {
            aniMage.SetInteger("transition", 1);
            
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
}
