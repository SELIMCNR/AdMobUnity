using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

using System;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private Text soruText,birinciSonucText,ikinciSonucText,ucuncuSonucText;

    [SerializeField]
    private Text dogruAdetText, yanlisAdetText, puanText;


    public GameObject baslaImage;


    [SerializeField]
    private GameObject dogruImage, yanlisImage;



    string hangiOyun;
    int birinciCarpan;
    int ikinciCarpan;
    int dogruSonuc;
    int birinciYanlýþSonuc;
    int ikinciYanlýþSonuc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public  int dogruAdet,yanlisAdet,toplamPuan;

    PlayerManager playerManager;

    AdMobManager adMobManager;

  
    private void Awake()
    {
        playerManager = UnityEngine.Object.FindObjectOfType<PlayerManager>();   
        adMobManager= FindObjectOfType<AdMobManager>();
    }

    void Start()
    {
        dogruAdet = 0;
        yanlisAdet = 0;
        toplamPuan = 0;

        dogruImage.GetComponent<RectTransform>().localScale = Vector3.zero;
        yanlisImage.GetComponent<RectTransform>().localScale= Vector3.zero; 



        if (PlayerPrefs.HasKey("hangiOyun"))
        {
            hangiOyun = PlayerPrefs.GetString("hangiOyun");
          
        }

        StartCoroutine(baslaYaziRoutine());
    }

    IEnumerator baslaYaziRoutine()
    {
        baslaImage.GetComponent<RectTransform>().DOScale(1.3f, 0.5f);
        yield return new WaitForSeconds(0.6f);
        baslaImage.GetComponent<RectTransform>().DOScale(0f, 0.5f).SetEase(Ease.InBack);
        baslaImage.GetComponent<CanvasGroup>().DOFade(0f,1f);
        yield return new WaitForSeconds(0.6f);

        OyunaBasla();

    }
    void OyunaBasla()
    {
        playerManager.rotaDegissinmi = true;
        SoruyuYazdir();
        adMobManager.LoadAd();

    }

    void BirinciCarpaniAyarla()
    {
        switch (hangiOyun)
        {
            case "iki":
                birinciCarpan = 2 ; break;
            case "üc":
                birinciCarpan = 3; break;
            case "dört":
                birinciCarpan = 4; break;
            case "bes":
                birinciCarpan = 5; break;
            case "altý":
                birinciCarpan = 6; break;
            case "yedi":
                birinciCarpan = 7; break;
            case "sekiz":
                birinciCarpan = 8; break;
            case "dokuz":
                birinciCarpan = 9; break;
            case "on":
                birinciCarpan = 10; break;
            case "karisikCarpma":
                birinciCarpan = UnityEngine.Random.Range(2,11); break;
        }
        Debug.Log(birinciCarpan);
    }

    void SoruyuYazdir()
    {
        BirinciCarpaniAyarla();
        ikinciCarpan = UnityEngine.Random.Range(2,11);
        int rastgeleDeger = UnityEngine.Random.Range(1,100);

        if (rastgeleDeger <= 50)
        {
            soruText.text = birinciCarpan.ToString() + "x" + ikinciCarpan.ToString();
        }
        else
        {
            soruText.text = ikinciCarpan.ToString() + "x" + birinciCarpan.ToString();

        }
        dogruSonuc = birinciCarpan * ikinciCarpan;
        sonuclariYazdir();
    }

    void sonuclariYazdir()
    {
        birinciYanlýþSonuc = dogruSonuc + UnityEngine.Random.Range(2,10);

        if (dogruSonuc > 10)
        {
            ikinciYanlýþSonuc = dogruSonuc - UnityEngine.Random.Range(2,10);   
        }
        else
        {
            ikinciYanlýþSonuc = Math.Abs( dogruSonuc - UnityEngine.Random.Range(1, 5));
        }

        int rastgeleDeger = UnityEngine.Random.Range(1, 100);
        if (rastgeleDeger <= 33)
        {
            birinciSonucText.text = dogruSonuc.ToString();
            ikinciSonucText.text = birinciYanlýþSonuc.ToString();
            ucuncuSonucText.text = ikinciYanlýþSonuc.ToString();
        }
        else if (rastgeleDeger <= 66 && rastgeleDeger>33)
        {
            birinciSonucText.text = ikinciYanlýþSonuc.ToString();
            ikinciSonucText.text = birinciYanlýþSonuc.ToString();
            ucuncuSonucText.text =  dogruSonuc.ToString();
        }
        else
        {
            birinciSonucText.text = birinciYanlýþSonuc.ToString();
            ikinciSonucText.text =  dogruSonuc.ToString();
            ucuncuSonucText.text = ikinciYanlýþSonuc.ToString();
        }
    }

    public void sonucuKontrolEt(int textSonucu)
    {
        dogruImage.GetComponent<RectTransform>().localScale = Vector3.zero;
        yanlisImage.GetComponent<RectTransform>().localScale = Vector3.zero;


        if (textSonucu == dogruSonuc)
        {
            dogruAdet++;
            toplamPuan += 20;
            dogruImage.GetComponent<RectTransform>().DOScale(1, .1f);
        }
        else
        {
            yanlisAdet++;
            yanlisImage.GetComponent<RectTransform>().DOScale(1, .1f);
        }
        dogruAdetText.text = dogruAdet.ToString() + " Doðru";  

        yanlisAdetText.text = yanlisAdet.ToString() + " Yanlýþ";

        puanText.text = toplamPuan.ToString() + " Puan";

        SoruyuYazdir();
    }
}
