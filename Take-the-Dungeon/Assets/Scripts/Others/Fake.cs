using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fake : MonoBehaviour
{
    public Animator anim;

    public void OnPressed()
    {
        anim.SetTrigger("Ativo");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnPressed();
        }
    }
}
