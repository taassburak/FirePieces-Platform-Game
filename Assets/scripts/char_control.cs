using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class char_control : MonoBehaviour
{
    public Sprite[] beklemeAnim;
    public Sprite[] ziplamaAnim;
    public Sprite[] yurumeAnim;
    public Sprite[] olumAnim;
    public Text canText;
    public Image SiyahArkaPlan;
    int can = 10;

    GameObject sonrakilevelbuton;
    GameObject oyunsonubuton;

    public AudioSource jump;
    public AudioSource hasaralma;
    public AudioSource levelsonumusic;
    public AudioSource canalmamusic;
    public AudioSource smashmusic;




    int olumAnimSayac = 0;
    int beklemeAnimSayac=0;
    int ziplamaAnimSayac = 0;
    int yurumeAnimSayac = 0;
    float siyaharkaPlanSayac=0;

    float anaMenuyeDonZaman = 0;

    SpriteRenderer spriteRenderer;
    float horizontal = 0;
    float waitingTime=0;
    float runningTime = 0;
    float olumTime = 0;
    Rigidbody2D physics;
    Vector3 vec;
    bool jumpeonce = true;
    Vector3 kameraSonPos;
    Vector3 kameraIlkPos;
    GameObject kamera;
    void Start()
    {
        sonrakilevelbuton = GameObject.Find("sonrakilevelbutonlari");
        oyunsonubuton = GameObject.Find("oyunsonubutonlari");
        

        spriteRenderer = GetComponent<SpriteRenderer>();
        physics = GetComponent<Rigidbody2D>();
        if (SceneManager.GetActiveScene().buildIndex > PlayerPrefs.GetInt("kacincilevel"))
        {
            PlayerPrefs.SetInt("kacincilevel", SceneManager.GetActiveScene().buildIndex);
        }


        

        kamera = GameObject.FindGameObjectWithTag("MainCamera");
        kameraIlkPos = kamera.transform.position - transform.position;
        canText.text = "HEALT : " + can;
        



    }

    
    void FixedUpdate()
    {
        charmove();
        Animation();
        
        if (can<=0)
        {
            olumTime += Time.deltaTime;
            if (olumTime > 0.05f)
            {
                spriteRenderer.sprite = olumAnim[olumAnimSayac++];
                if (olumAnimSayac == olumAnim.Length)
                {
                    olumAnimSayac = 0;
                }
                olumTime = 0;

            }


            Time.timeScale = 0.4f;
            canText.enabled=false;
            siyaharkaPlanSayac += 0.03f;
            SiyahArkaPlan.color = new Color(0,0,0,siyaharkaPlanSayac);
            anaMenuyeDonZaman += Time.deltaTime;


            


            if (anaMenuyeDonZaman>1)
            {
                SceneManager.LoadScene("anamenu");
            }
        }
    }
    void LateUpdate()
    {
        kameraKontrol();
    }
    void Update()
    {
        //ikinci defa zıplamaması için
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpeonce)
            {
                physics.AddForce(new Vector2(0, 500));
                jumpeonce = false;
            }
            
            
        }
        ziplamasesi();


    }
    void charmove()
    {
        // karakteri yürütmek için
        horizontal = Input.GetAxisRaw("Horizontal");
        vec = new Vector3(horizontal * 10, physics.velocity.y, 0);
        physics.velocity = vec;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //updatede yazdığım kodun çalışması için collision enter verdim
        jumpeonce = true;
    }

    void OnTriggerStay2D(Collider2D col)
    {
      if (col.gameObject.tag == "su")
        {
            can = 0;


        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "kursun")
        {
            can--;
            canText.text = "HEALT : " + can;
            hasaralma.Play();
        }
        else if (col.gameObject.tag == "dusman")
        {
            can = can - 2;
            canText.text = "HEALT : " + can;
            hasaralma.Play();
        }
        else if (col.gameObject.tag == "testere")
        {
            can = can - 2;
            canText.text = "HEALT : " + can;
            hasaralma.Play();
        }
        
        else if (col.gameObject.tag == "canver")
        {
            if (can>=8)
            {
                can = 10;
                canText.text = "HEALT : " + can;
                col.GetComponent<BoxCollider2D>().enabled = false;
                col.GetComponent<canver>().enabled = true;
                canalmamusic.Play();
            }
            else
            {
                can = can + 3;
                canText.text = "HEALT : " + can;
                col.GetComponent<BoxCollider2D>().enabled = false;
                col.GetComponent<canver>().enabled = true;
                canalmamusic.Play();

            }
            
            
        }
        
        
        else if (col.gameObject.tag=="pipe")
        {
            can = 0;
            smashmusic.Play();
        }

        else if (col.gameObject.tag=="ball")
        {
            can = can-5;
            canText.text= "HEALT : " + can;
            hasaralma.Play();
        }
        else if (col.gameObject.tag=="zincirlitop")
        {
            can = can - 5;
            canText.text = "HEALT : " + can;
            smashmusic.Play();
        }
        else if (col.gameObject.tag == "levelbitsin")
        {

            for (int i = 0; i < sonrakilevelbuton.transform.childCount; i++)
            {
                sonrakilevelbuton.transform.GetChild(i).gameObject.SetActive(true);
                
            }
            levelsonumusic.Play();
            
            
            
        }
        else if (col.gameObject.tag == "oyunsonu")
        {

            for (int i = 0; i < oyunsonubuton.transform.childCount; i++)
            {
                oyunsonubuton.transform.GetChild(i).gameObject.SetActive(true);
              
            }
           
            oyunsonubuton.transform.GetChild(2).GetComponent<Button>().interactable = false;
            levelsonumusic.Play();


        }
    }
    void Animation()
    {
        if (jumpeonce == true)
        {
            if (horizontal == 0)
            {
                waitingTime += Time.deltaTime;
                if (waitingTime > 0.05f)
                {
                    spriteRenderer.sprite = beklemeAnim[beklemeAnimSayac++];
                    if (beklemeAnimSayac == beklemeAnim.Length)
                    {
                        beklemeAnimSayac = 0;
                    }
                    waitingTime = 0;
                }

            }
            else if (horizontal > 0)
            {
                runningTime += Time.deltaTime;
                if (runningTime > 0.1f)
                {
                    spriteRenderer.sprite = yurumeAnim[yurumeAnimSayac++];
                    if (yurumeAnimSayac == yurumeAnim.Length)
                    {
                        yurumeAnimSayac = 0;
                    }
                    runningTime = 0;
                }
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (horizontal < 0)
            {
                runningTime += Time.deltaTime;
                if (runningTime > 0.1f)
                {
                    spriteRenderer.sprite = yurumeAnim[yurumeAnimSayac++];
                    if (yurumeAnimSayac == yurumeAnim.Length)
                    {
                        yurumeAnimSayac = 0;
                    }
                    runningTime = 0;
                }
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }

        else if(jumpeonce==false)
        {
            if (physics.velocity.y > 0)
            {
                
                spriteRenderer.sprite = ziplamaAnim[0];

                
            }
            else
            {
                spriteRenderer.sprite = ziplamaAnim[1];

                
            }
            if (horizontal>0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (horizontal<0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }

       
    }
    void ziplamasesi()
    {
        if (Input.GetKeyDown("space"))
        {
            jump.Play();
        }
    }

    public void butonsecimi(int hangibuton)
    {
        if (hangibuton==0)
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }
        else if (hangibuton==1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }
        else if (hangibuton==2)
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Time.timeScale = 1;
        }
    }
    
    void kameraKontrol()
    {
        kameraSonPos = kameraIlkPos + transform.position;
        //kamera.transform.position = Vector3.Lerp(kamera.transform.position, kameraSonPos, 0.5f);
        kamera.transform.position = kameraSonPos;
    }
       
        

        
}
