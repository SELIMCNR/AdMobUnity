using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    [SerializeField]
    private Transform gun;

    float angle;

  

    float donusHizi = 5f;

    [SerializeField]
    private GameObject[] mermiPrefab;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip ballClip;

    [SerializeField]
    private Transform mermiYeri;

    float ikiMermiArasiSure = 200f;
    float sonrakiAtýþ;

    // Update is called once per frame
    public bool rotaDegissinmi;
    private void Start()
    {
        rotaDegissinmi = false;
    }
    void Update()
    {
        if (rotaDegissinmi)
        {
            RotateDegistir();
        }
    }

    void RotateDegistir()
    {



        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gun.transform.position;
        ;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
      
        if(angle <45 && angle > -45)
        {
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            gun.transform.rotation = Quaternion.Slerp(gun.transform.rotation, rotation, donusHizi * Time.deltaTime);

        }




        if (Input.GetMouseButtonDown(0))
        {
        

            if (Time.time > sonrakiAtýþ)
            {
                sonrakiAtýþ= Time.time+ikiMermiArasiSure/1000;
                MermiAt();
            }
           
        }


 

    }

    void MermiAt()
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(ballClip);
        }
   
        GameObject mermi = Instantiate(mermiPrefab[Random.Range(0,mermiPrefab.Length)],mermiYeri.position,mermiYeri.rotation) as GameObject;


    }
}
