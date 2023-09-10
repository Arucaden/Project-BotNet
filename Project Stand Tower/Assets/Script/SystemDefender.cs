using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemDefender : MonoBehaviour
{
    public SystemDefenderSO systemDefender;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(systemDefender.description);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
