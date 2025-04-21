using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenTIControler : MonoBehaviour
{

    public static ScreenTIControler instance;

    public GameObject Inicio;
    public GameObject Credito;
    public Animator PanelAnimator;

    public int sceneIndex2;
    public int bossRoom;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    private void Update()
    {
        
        sceneIndex2 = Random.Range(7, 8);
        bossRoom = 9;
    }

    #region Comando Botões
    public void playgame()
    {
        SceneManager.LoadScene(3);
        PlayerPrefs.DeleteAll();
    }
    public void ConfigScene()
    {
        SceneManager.LoadScene(2);
    }

    public void CreditScene()
    {
        Inicio.SetActive(false);
        Credito.SetActive(true);
    }

    public void ExitLogin() {
        SceneManager.LoadScene(0);
    }
    public void ReturnIn()
    {
        Inicio.SetActive(true);
        Credito.SetActive(false);
    }
    #endregion
}
