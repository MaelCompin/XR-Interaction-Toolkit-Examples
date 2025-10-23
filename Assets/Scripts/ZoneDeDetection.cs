using UnityEngine;

public class ZoneDetection : MonoBehaviour
{
    public static int compteur = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Balle")) 
        {
            compteur++;
            Debug.Log("Collision détectée ! Compteur = " + compteur);
        }
    }
}
