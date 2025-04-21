using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public Animator anim;
    public Animator portaAnim;

    public void OnPressed() {

        anim.SetTrigger("Ativo");

        portaAnim.SetBool("Aberto", true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {

            OnPressed();
        }
    }
}
