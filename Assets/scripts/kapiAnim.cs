using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kapiAnim : MonoBehaviour
{
    float kapiTime = 0;
    public Sprite[] kapiAnima;
    int kapiAnimSayac = 0;
    SpriteRenderer spriteRenderer;

    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
    }

    
    void Update()
    {
       
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag=="Player")
        {
            kapiAnimas();
            
        }
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            audio.Play();
            
        }
        Destroy(audio);
        
    }
    void kapiAnimas()
    {
        
        kapiTime += Time.deltaTime;
        if (kapiTime > 0.2f)
        {
            spriteRenderer.sprite = kapiAnima[kapiAnimSayac++];
            if (kapiAnimSayac == kapiAnima.Length)
            {
                kapiAnimSayac = kapiAnima.Length-1;
                Time.timeScale = 0.2f;
            }
            kapiTime = 0;
        }
    }

    
}
