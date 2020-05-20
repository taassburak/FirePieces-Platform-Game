using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canver : MonoBehaviour
{
    public Sprite []animasyonkareleri;
    SpriteRenderer spriteRenderer;
    float zaman = 0;
    int animasyonKarelerSayaci = 0;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        zaman += Time.deltaTime;
        if (zaman>0.2f)
        {
            spriteRenderer.sprite = animasyonkareleri[animasyonKarelerSayaci++];
            if (animasyonkareleri.Length == animasyonKarelerSayaci)
            {
                animasyonKarelerSayaci = animasyonkareleri.Length - 1;
            }
            zaman = 0;
        }
        
    }
}
