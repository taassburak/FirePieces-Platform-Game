using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suControl : MonoBehaviour
{
    float sutime=0;
    public Sprite[] suAnim;
    int suAnimSayac = 0;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        animation();
    }

    void animation()
    {
        sutime += Time.deltaTime;
        if (sutime > 0.05f)
        {
            spriteRenderer.sprite = suAnim[suAnimSayac++];
            if (suAnimSayac == suAnim.Length)
            {
                suAnimSayac = 0;
            }
            sutime = 0;
        }
    }
}
