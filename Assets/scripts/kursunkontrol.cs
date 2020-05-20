using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kursunkontrol : MonoBehaviour
{
    dusmancontrol dusman;
    Rigidbody2D fizik;
    float ateszamani = 0;
    void Start()
    {
        dusman = GameObject.FindGameObjectWithTag("dusman").GetComponent<dusmancontrol>();
        fizik = GetComponent<Rigidbody2D>();
        if (Time.deltaTime*(15)>ateszamani)
        {
            fizik.AddForce(dusman.getYon() * 1000);
            ateszamani++;
        }
            
    }
}
