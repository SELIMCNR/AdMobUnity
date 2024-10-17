using UnityEngine;

public class MermiManager : MonoBehaviour
{

    float mermiHizi = 15f;
    
   

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up *Time.deltaTime*mermiHizi);
    }
}
