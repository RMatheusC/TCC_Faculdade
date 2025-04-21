using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor_Controler : MonoBehaviour
{
    private void Update()
    {
        ArmorMoviment();
    }
    public void ArmorMoviment() {
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        Vector2 offset = new Vector2(mousePos.x - screenPos.x, mousePos.y - screenPos.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg + 180;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
