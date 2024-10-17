using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPaneli;

    [SerializeField]
    private AudioSource audioSource;


    [SerializeField]
    private AudioClip btnClip;

    [SerializeField]
    private GameObject sesPaneli;

    bool sesPaneliAcikmi;

     void Start()
    {
        sesPaneliAcikmi = false;

        sesPaneli.GetComponent<RectTransform>().localPosition = new Vector3 (0, 19, 0);  

        menuPaneli.GetComponent<CanvasGroup>().DOFade(1, 1f);
        menuPaneli.GetComponent<RectTransform>().DOScale(1f, 1f).SetEase(Ease.OutSine);
    }

    public void ikinciLeveleGec()
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(btnClip);
        }
        audioSource.PlayOneShot(btnClip);
        SceneManager.LoadScene(1);
    }

    public void AyarlariYap()
    {

        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(btnClip);
        }
        // daha sonra
        if (!sesPaneliAcikmi)
        {
            sesPaneli.GetComponent<RectTransform>().DOLocalMoveY(-40, 0.5f);
            sesPaneliAcikmi=true;
        }
        else
        {
            sesPaneli.GetComponent<RectTransform>().DOLocalMoveY(15, 0.5f);
            sesPaneliAcikmi = false;
        }

    }

    public void OyundanCik()
    {

        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(btnClip);
        }
        Application.Quit();
    }
   
}
