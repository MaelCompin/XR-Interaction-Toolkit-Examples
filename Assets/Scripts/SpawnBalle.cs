using UnityEngine;

public class SpawnBalle : MonoBehaviour
{
    public Vector3 posi;
    [SerializeField] public GameObject balle; 
    public void SpawnerBalle()
    {
    posi = GameObject.Find("SpawnerPoint").transform.position; 
        Instantiate(balle, posi, Quaternion.identity);
    }
}
