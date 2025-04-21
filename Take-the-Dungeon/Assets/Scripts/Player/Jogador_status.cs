using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Jogador_status : MonoBehaviour
{
    private int chgclass;
    public GameObject end;
    public Text level_txt;
    public Text Soul_pt;
    public int countSoul = 0;
    private Hud_Controler hd;


    #region anotherStatus
    public int mana = 20;
    public float dmg;
    public int str;

    public float currentMana;
    public float currentStr;

    private float maxMana = 20;
    private float maxDmg = 6;
    private float maxStr = 0;
    #endregion

    private void Start()
    {
        dmg = maxDmg;
    }

    #region life
    public int life = 20;
    public bool isdead = false;
    public float currentlife;
    private float maxlife = 30;
    #endregion

    #region xp
    public int xp = 0;
    public int level = 1;
    public bool ismax = false;

    public float currentxp = 0;
    private float maxXp = 75;

    private int maxlevel = 8;
    #endregion

    public float MaxXp { get => maxXp; set => maxXp = value; }
    public float Maxlife { get => maxlife; set => maxlife = value; }
    public float MaxMana { get => maxMana; set => maxMana = value; }
    public float MaxDmg { get => maxDmg; set => maxDmg = value; }
    public float MaxStr { get => maxStr; set => maxStr = value; }

    public void LifeControler() {
        if (currentlife == 0) {
            isdead = true;
        }
    }

    public void XPControler(float xp) {
        if (currentxp >= MaxXp) {
            level = level + 1;
            MaxXp += 25;
            currentxp = 0;
            currentlife += 7;
            currentMana += 6;
            maxDmg += 2;

        }
        else if (level == maxlevel ) {
            ismax = true;
            MaxXp = 10000000000000;
        }
    }

    #region Telas

    public GameObject Inventory;
    public GameObject Status;
    public GameObject Evolution;
    public GameObject Pause;
    public GameObject sword;
    public GameObject bow;
    public GameObject ceter;

    public void OpenInv() {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (Inventory.activeSelf)
            {
                Inventory.SetActive(false);
                Time.timeScale = 1;
                ScreenJGControler.scj.pt.text = "";

            }
            else
            {
                Inventory.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
    public void OpenStatus()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Status.activeSelf)
            {
                Status.SetActive(false);
                Time.timeScale = 1;
                Hud_Controler.hdcc.tx.text = "";

            }
            else
            {
                Status.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
    public void OpenPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pause.activeSelf)
            {
                Pause.SetActive(false);
                Time.timeScale = 1;

            }
            else
            {
                Pause.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void ChooseClass() { 
        
    }

    #endregion

    private void Update()
    {
        OpenInv();
        OpenStatus();
        OpenPause();
        Levels();
        carregardados();

        endGame();
    }

    public void endGame() {
        if (currentlife <= 0) {
            end.SetActive(true);
            level = 0;
            PlayerPrefs.DeleteAll();
            Destroy(gameObject, 2.15f);
        }
    }
    #region StatusControler
    public Image LifeBar;
    public Image ManaBar;
    public Image StaminaBar;
    //public Image SpeedBar;
    private float Dec = 100f;
    


    #endregion

    private void FixedUpdate()
    {
        LifeBar.fillAmount = Maxlife/Dec;
        ManaBar.fillAmount = maxMana / Dec;
        StaminaBar.fillAmount = maxStr / Dec;
        //SpeedBar.fillAmount = maxDmg / Dec;        
    }

    public void lvlUp() {
        countSoul += Random.Range(0, 2);
    }

    private void Levels() {
        level_txt.text = level.ToString();
        Soul_pt.text = countSoul.ToString();
    }

    public void carregardados() {
        #region getInt
        if (PlayerPrefs.GetInt("TemArco") == 1)
        {
            ceter.SetActive(false);
            bow.SetActive(true);
        }
        if (PlayerPrefs.GetInt("TemCetro") == 1)
        {
            bow.SetActive(false);
            ceter.SetActive(true);
        }
        #endregion
    }
}
