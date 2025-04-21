using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Acher : MonoBehaviour
{
    [SerializeField] private Transform bow;
    [SerializeField] private Animator aniArcher;
    [SerializeField] private NavMeshAgent agent;
    private Jogador_status jgsts;
    private bool death = false;
    private int armor = 4;
    private Jogador player;
    private float timeCoutn;
    private float recoveryTime = 1.2f;
    private bool isHitting = false;
    bool detected = false;

    public GameObject arrow;
    public Transform target;
    public float speed = 1.5f;
    public float range;

    #region Status
    public float life = 15;
    public int dmg = 4;

    #endregion
    void Start()
    {
        jgsts = FindObjectOfType<Jogador_status>();
        player = FindObjectOfType<Jogador>();
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

    public void OnDeath()
    {
        if (life <= 0)
        {
            aniArcher.SetTrigger("death");
            agent.speed = 0;
            Destroy(gameObject, 0.7f);
            jgsts.currentxp += 0.25f;
            jgsts.lvlUp();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Arrow") || collision.CompareTag("Magic") || collision.CompareTag("Sword"))
        {
            aniArcher.SetTrigger("Dmg");
            isHitting = true;
            life -= jgsts.dmg;
        }
    }

    public void shoot()
    {
        if (armor > 0) {
            GameObject magics = Instantiate(arrow, bow.position, Quaternion.identity);
            Instantiate(arrow, bow.position, transform.rotation);

            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(bow.position, range);
    }


    public void AniAll()
    {
        agent.SetDestination(player.transform.position);

        if (Vector2.Distance(transform.position, player.transform.position) <= agent.stoppingDistance)
        {
            aniArcher.SetInteger("transition", 1);
            shoot();
        }
        else
        {
            aniArcher.SetInteger("transition", 2);
            

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
