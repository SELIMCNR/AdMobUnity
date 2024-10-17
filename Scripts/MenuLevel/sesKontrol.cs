using UnityEngine;


public class sesKontrol : MonoBehaviour
{
   void Start()
    {
        SesiAc();
    }
    public void SesiAc()
    {
        PlayerPrefs.SetInt("sesDurumu", 1);
    }

    public void SesiKapat()
    {
        PlayerPrefs.SetInt("sesDurumu", 0);
    }

}
