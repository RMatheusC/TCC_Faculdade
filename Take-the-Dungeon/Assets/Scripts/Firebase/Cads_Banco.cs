using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cads_Banco : MonoBehaviour
{
    public GameObject[] gm_obj;
    public int requestCode = 0;

    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public static FireBanco instance;
    public FirebaseAuth auth;
    public FirebaseUser User;

    [Header("Cadastro")]
    public InputField nome;
    public InputField email;
    public InputField senha;
    public InputField conf_Senha;

    private void Awake()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;

            if (dependencyStatus == DependencyStatus.Available)
            {
                InitializeFirebase();
            }
            else
            {
                Debug.LogError("Error: " + dependencyStatus);
            }
        });
    }
    public void InitializeFirebase()
    {
        auth = FirebaseAuth.DefaultInstance;
    }

    public void CadastroButton()
    {
        StartCoroutine(Cadastro(nome.text, email.text, senha.text));
    }
    public IEnumerator Cadastro(string _nome, string _email, string _senha)
    {

        if (senha.text != conf_Senha.text)
        {
            Debug.LogError("Problema com senha");
        }
        else
        {
            var RegisterTask = auth.CreateUserWithEmailAndPasswordAsync(_email, _senha);
            yield return new WaitUntil(predicate: () => RegisterTask.IsCompleted);

            if (RegisterTask.Exception == null)
            {
                requestCode = 1;

                SwitchTrade(requestCode);
            }
        }
    }
    public void SwitchTrade(int requestCode)
    {
        switch (requestCode)
        {
            case 1:
                gm_obj[1].SetActive(false);
                gm_obj[0].SetActive(true);
                break;
        }
    }

}
