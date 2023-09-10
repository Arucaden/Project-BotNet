using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place : MonoBehaviour
{
    public GameObject systemDefender;
    public void OnClick() 
    {
        Vector2 sysDefPosition = systemDefender.transform.position;
        sysDefPosition = PlaceTower.clickedGOPos;

        RaycastHit2D[] check = Physics2D.RaycastAll(sysDefPosition, Vector2.up);
        bool isTowerDetected = false;
        foreach (RaycastHit2D checks in check)
        {
            if (checks.collider.CompareTag("Tower")) 
            {
                isTowerDetected = true;
                break;
            }
        }
        if (!isTowerDetected)
        {
            GameObject sysDef = Instantiate(systemDefender, sysDefPosition, Quaternion.identity);
            sysDef.AddComponent<BoxCollider2D>();
            Collider2D coll = sysDef.GetComponent<Collider2D>();
            coll.tag = "Tower";
        }
        else 
        {
            Debug.Log("tolol!");
        }
    }
}
