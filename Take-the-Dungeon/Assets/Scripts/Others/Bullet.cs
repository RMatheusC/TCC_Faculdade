using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject inimigo;
    [SerializeField] float speed;
    [SerializeField] private Transform atakPoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask EnemyLayer;

    private Armor_Controler spawn;

    private void Start()
    {
        spawn = FindObjectOfType<Armor_Controler>();
    }

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
