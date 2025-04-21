using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject MouseItem;
    public void OnMouseDrag(GameObject button)
    {
        MouseItem = button;
        MouseItem.transform.position = Input.mousePosition;
    }
}
