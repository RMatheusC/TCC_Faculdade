using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour
{
    private Jogador_status jg;

    public GameObject ptVG;
    public GameObject cetro;
    public GameObject arco;
    public bool isArco = false;
    public bool isCetro = false;

    void Start()
    {
        jg = FindObjectOfType<Jogador_status>();
    }
    void Update()
    {
        if (Vector2.Distance(jg.transform.position, transform.position) < 1) {
            
            if (Input.GetKeyDown(KeyCode.F)) {
                if (CompareTag("PtVG")) {
                    if (Item_Controler.it.bt.activeSelf == true){ 
                        
                    }
                    else{
                        Item_Controler.it.bt.SetActive(true);
                        Destroy(gameObject);
                    }
                    
                }

                if (CompareTag("cetro")) {
                    if (cetro.activeSelf == false && arco.activeSelf == false) {
                        cetro.SetActive(true);
                        isCetro = true;
                        isArco = false;
                        Destroy(gameObject);
                    }
                    if (cetro.activeSelf == false && arco.activeSelf == true) {
                        arco.SetActive(false);
                        cetro.SetActive(true);
                        isCetro = true;
                        isArco = false;
                        Destroy(gameObject);
                    }
                    
                }
                if (CompareTag("arco")) {
                    if (arco.activeSelf == false && cetro.activeSelf == false)
                    {
                        arco.SetActive(true);
                        isCetro = false;
                        isArco = true;
                        Destroy(gameObject);
                    }
                    if (arco.activeSelf == false && cetro.activeSelf == true)
                    {
                        cetro.SetActive(false);
                        isCetro = false;
                        isArco = true;
                        arco.SetActive(true);
                        Destroy(gameObject);

                    }

                }

                
            }
        }
        #region setInt
        if (isArco && isCetro == false)
        {
            PlayerPrefs.SetInt("TemArco", 1);
            PlayerPrefs.SetInt("TemLanc", 0);
            Debug.Log(PlayerPrefs.GetInt("TemArco"));
        }
        if (isCetro && isArco == false)
        {
            PlayerPrefs.SetInt("TemArco", 0);
            PlayerPrefs.SetInt("TemCetro", 1);
        }
        #endregion
    }
}
