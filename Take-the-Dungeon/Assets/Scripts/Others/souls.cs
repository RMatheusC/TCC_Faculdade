using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class souls : MonoBehaviour
{
    public GameObject soul;
    public Jogador_status jg;

    public static souls sos;

    private void Awake()
    {
        if (sos == null)
        {
            sos = this;
        }
        else if (sos != null)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
        
    }

    private void Start()
    {
        jg = FindObjectOfType<Jogador_status>();
    }

    public void soulactive() {
        soul.SetActive(true);
    }

    public void getSoul()
    {
        while (gameObject.CompareTag("soul") == true) {
            if (Vector2.Distance(jg.transform.position, transform.position) < 1)
            {
                jg.countSoul += Random.Range(1, 20);
                Destroy(gameObject);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        getSoul();
    }
}
