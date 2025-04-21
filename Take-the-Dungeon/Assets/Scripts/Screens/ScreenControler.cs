using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenControler : MonoBehaviour
{
    
    public static ScreenControler instance;

    public GameObject cont;
    public GameObject login;
    public GameObject register;

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

    #region Comando Botões
    public void ContinuieScreen() {
            cont.SetActive(false);
            login.SetActive(true);
        }
        public void LoginScreen() //Back button
        {
            login.SetActive(true);
            register.SetActive(false);
        }
        public void RegisterScreen() // Regester button
        {
            login.SetActive(false);
            register.SetActive(true);
        }
        public void play() {
            SceneManager.LoadScene(1);
        }
    #endregion
}
