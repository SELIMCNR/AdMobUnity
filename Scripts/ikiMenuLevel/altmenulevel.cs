using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class altmenulevel : MonoBehaviour
{
    [SerializeField]
    private GameObject altmenuPaneli;

    [SerializeField]
    private AudioSource audioSource;


    [SerializeField]
    private AudioClip btnClip;

    void Start()
    {
        if (altmenuPaneli != null)
        {
            altmenuPaneli.GetComponent<CanvasGroup>().DOFade(1, 1f);
            altmenuPaneli.GetComponent<RectTransform>().DOScale(1f, 1f).SetEase(Ease.OutSine);

        }
    }
    public void HangiOyunAcilsin(string hangiOyun)
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(btnClip);
        }

        PlayerPrefs.SetString("hangiOyun", hangiOyun);
        SceneManager.LoadScene(2);
    }

    public void geriDon()
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(btnClip);
        }
        SceneManager.LoadScene(0);
    }
}
