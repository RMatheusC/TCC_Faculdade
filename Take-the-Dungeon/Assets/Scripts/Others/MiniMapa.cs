using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapa : MonoBehaviour
{
    public Transform player;
    public float suave = 1f;

    private void FixedUpdate()
    {
        Vector3 startPos = new Vector3(player.position.x, player.position.y, -10f);
        Vector3 suave = Vector3.Lerp(transform.position, player.position, 1.5f);
    }
}
