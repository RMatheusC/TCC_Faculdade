using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogador : MonoBehaviour
{
    public float speed;
    public float runspeed;
    
    private float initialspeed;
    private Rigidbody2D rig;
    private Vector2 _direction;
    private Jog_anim Jogador_Anim;

    public Vector2 direction{
        get { return _direction;}
        set { _direction = value;}
    } 

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        initialspeed = speed;        
    }
    void Update()
    {
        OnImput();
        OnRun();
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    #region Movimentação

    public void moviment() {

    
    }
    void OnImput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove()
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runspeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialspeed;
        }
    }
    #endregion
}
