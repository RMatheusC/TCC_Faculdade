using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Controler : MonoBehaviour
{

    public Jogador_status jg;
    public GameObject bt;
    public GameObject bt2;
    public Text pt;

    public static Item_Controler it;

    private void Awake()
    {
        it = FindObjectOfType<Item_Controler>();
    }

    void Update()
    {
        transform.position += (transform.parent.position - transform.position) * 5 * Time.deltaTime;
        jg = FindObjectOfType<Jogador_status>();
        

    }
    public void usar() {
        if (jg.currentlife < 30)
        {
            jg.currentlife = jg.currentlife + 10;
            bt.SetActive(false);
        }
        else {
            pt.text = "Vida Cheia!!!";
        }
    }
}
