using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stairs_lvl3 : MonoBehaviour
{
    static public int sceneIndex;
    static public Stairs_lvl3 st3;

    private void Start()
    {
        st3 = FindObjectOfType<Stairs_lvl3>();
    }

    private void Update()
    {
        sceneIndex = 9;
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LoadScene();
        }
    }
}
