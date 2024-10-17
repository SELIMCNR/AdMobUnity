using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
public class SonucManager1 : MonoBehaviour
{
    [SerializeField]
    private Image sonucImage;


    float sureTimer;
    bool resimAcilsinmi;

    [SerializeField]
    private Text dogruText, yanlisText, PuanText;

    [SerializeField]
    private GameObject tekrarOynaBtn, anaMenuBtn;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = Object.FindAnyObjectByType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager component not found!");
            return;
        }

    }

    private void OnEnable()
    {
        sureTimer = 0;
        resimAcilsinmi = true;


        dogruText.text = "";
        yanlisText.text = "";
        PuanText.text = "";

        sonucImage.fillAmount = 0f;
        tekrarOynaBtn.GetComponent<RectTransform>().localScale = Vector3.zero;
        anaMenuBtn.GetComponent<RectTransform>().localScale = Vector3.zero;

        StartCoroutine(ResimAcRoutine());
    }

    IEnumerator ResimAcRoutine()
    {
        while (resimAcilsinmi)
        {
            sureTimer += 0.15f;
            sonucImage.fillAmount = sureTimer;

            yield return new WaitForSeconds(0.1f);

            if (sureTimer >= 1)
            {
                sureTimer = 1;
                resimAcilsinmi = false;

                dogruText.text = gameManager.dogruAdet.ToString()+ " doðru";
                yanlisText.text = gameManager.yanlisAdet.ToString()+ " yanlýþ";
                PuanText.text = gameManager.toplamPuan.ToString() + " puan ";

                tekrarOynaBtn.GetComponent<RectTransform>().DOScale(1, .3f);
                anaMenuBtn.GetComponent<RectTransform>().DOScale(1, .3f);


      
            }
        }
    }


    public void tekrarOyna()
    {
        SceneManager.LoadScene(2);
    }
    public void anaMenüyeDön()
    {
        SceneManager.LoadScene(0);
    }


}
