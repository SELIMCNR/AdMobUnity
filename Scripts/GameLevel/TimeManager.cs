using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{

    [SerializeField]
    private Text SureText;


    int kalanSure ;

    bool sureSaysinmi ;

    [SerializeField]
    private GameObject sonucPanel;


    [SerializeField]
    private GameObject sonuclarObje,zamanObje,dogruYanlisObje,playerObje,puanObje;


    void Start()
    {
        kalanSure = 90;
        sureSaysinmi = true;
        sonucPanel.SetActive(false);

        StartCoroutine(SureTimerRoutine());

    }

    IEnumerator  SureTimerRoutine()
    {
        while (sureSaysinmi)
        {
            yield return new WaitForSeconds(1f);

            if (kalanSure < 10)
            {
                SureText.text = "0" + kalanSure.ToString();
            }
            else
            {
                SureText.text = kalanSure.ToString();
            }

            if (kalanSure <= 0)
            {
                sureSaysinmi=false;
                SureText.text = "";

                ekraniTemizle();
                sonucPanel.SetActive(true);


            }
            kalanSure--;
        }

 
    }

    void ekraniTemizle()
    {
        sonuclarObje.SetActive(false);
        zamanObje.SetActive(false);
        dogruYanlisObje.SetActive(false);
        playerObje.SetActive(false);
        puanObje.SetActive(false);
    }

}
