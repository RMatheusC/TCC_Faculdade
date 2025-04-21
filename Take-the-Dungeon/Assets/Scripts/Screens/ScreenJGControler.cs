using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenJGControler : MonoBehaviour
{
    static public ScreenJGControler scj;

    private void Awake()
    {
        scj = FindObjectOfType<ScreenJGControler>();
    }

    public GameObject Status;
    public GameObject Evolution;
    public GameObject Inventory;
    public GameObject Pause;
    public GameObject acao;
    public Text pt;

    public void resume()
    {
        Pause.SetActive(false);
        Time.timeScale = 1;
    }
    public void Recomec() {
        SceneManager.LoadScene(3);
        PlayerPrefs.DeleteAll();
        Time.timeScale = 1;
    }
    public void sair()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void status()
    {
        Status.SetActive(false);
        Time.timeScale = 1;
        Hud_Controler.hdcc.tx.text = "";
    }

    public void inventory()
    {
        Inventory.SetActive(false);
        Time.timeScale = 1;
        pt.text = "";

    }
    public void Restart_Game()
    {
        SceneManager.LoadScene(4);
    }
    public void ExitToMenu() {
        SceneManager.LoadScene(3);
        PlayerPrefs.DeleteAll();
        Stairs.sceneIndex = Random.Range(4, 7);
        Stairs_Lvl2.sceneIndex = Random.Range(7, 9);
    }
    public void ativar()
    {
        if (acao.activeSelf == false)
        {
            acao.SetActive(true);
        }
    }
    public void desativar()
    {
        if (acao.activeSelf == true)
        {
            acao.SetActive(false);
        }

    }

}
