using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    public GameObject towerPrefab;
    private GameObject tower;

    private bool isPlaceTower()
    {
        return tower == null;
    }

    private void OnMouseUp()
    {
        if(isPlaceTower())
        {
            tower = (GameObject)
                Instantiate(towerPrefab, transform.position,Quaternion.identity);
        }
    }

}
