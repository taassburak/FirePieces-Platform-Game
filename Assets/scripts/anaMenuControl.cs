using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class anaMenuControl : MonoBehaviour
{
    
    
    GameObject leveller,kilitler;
    void Start()
    {
        Time.timeScale = 1;

        leveller = GameObject.Find("LEVELLER");
        kilitler = GameObject.Find("kilitler");

        for (int i = 0; i < leveller.transform.childCount; i++)
        {
            leveller.transform.GetChild(i).gameObject.SetActive(false);
        }

        for (int i = 0; i < kilitler.transform.childCount; i++)
        {
            kilitler.transform.GetChild(i).gameObject.SetActive(false);
        }
        //PlayerPrefs.DeleteAll();
        

        for (int i = 0; i < PlayerPrefs.GetInt("kacincilevel"); i++)
        {
            leveller.transform.GetChild(i).GetComponent<Button>().interactable = true;
            
        }
    }
    public void butonSec(int gelenButon)
    {
        if (gelenButon==1)
        {
            SceneManager.LoadScene(1);
        }
        else if (gelenButon==2)
        {
            for (int i = 0; i < kilitler.transform.childCount; i++)
            {
                kilitler.transform.GetChild(i).gameObject.SetActive(true);
            }

            for (int i = 0; i < leveller.transform.childCount; i++)
            {
                leveller.transform.GetChild(i).gameObject.SetActive(true);
            }

            for (int i = 0; i < PlayerPrefs.GetInt("kacincilevel"); i++)
            {
                kilitler.transform.GetChild(i).gameObject.SetActive(false);
            }

      
        }
        else if (gelenButon==3)
        {
            Application.Quit();
        }
        else if (gelenButon==4)
        {
            PlayerPrefs.DeleteAll();
        }


        
    }

    public void levelsec(int gelenbutonlevel)
    {
        SceneManager.LoadScene(gelenbutonlevel);
    }
    public void levelarasi(int gelenbutonsecim)
    {
        if (gelenbutonsecim==0)
        {
            SceneManager.LoadScene(0);
        }
        else if(gelenbutonsecim==1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (gelenbutonsecim == 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
        }
    }
}
