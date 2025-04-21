using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stairs_Lvl2 : MonoBehaviour
{
    static public int sceneIndex;

    private void Update()
    {
        sceneIndex = Random.Range(7, 9);
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
