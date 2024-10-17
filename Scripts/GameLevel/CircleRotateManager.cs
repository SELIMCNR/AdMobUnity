using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CircleRotateManager : MonoBehaviour
{

    string hangiSonuc;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = Object.FindAnyObjectByType<GameManager>();    

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "mermi")
        {

            gameObject.transform.DORotate(transform.eulerAngles + Quaternion.AngleAxis(45, Vector3.forward).eulerAngles, 0.5f);

            if(collision.gameObject!=null)
            {
                Destroy(collision.gameObject);
            }

            if (gameObject.name == "solDaire")
            {
                hangiSonuc = GameObject.Find("solText").GetComponent<Text>().text;
            }
            else if(gameObject.name == "ortaDaire")
            {
                hangiSonuc = GameObject.Find("ortaText").GetComponent<Text>().text;
            }
            else if (gameObject.name == "sagDaire")
            {
                hangiSonuc = GameObject.Find("sagText").GetComponent<Text>().text;
            }

            Debug.Log(hangiSonuc);

            gameManager.sonucuKontrolEt(int.Parse(hangiSonuc)); 

        }


    }

}
