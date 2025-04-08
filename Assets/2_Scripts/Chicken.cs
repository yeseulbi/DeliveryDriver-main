using UnityEngine;

public class Chicken : MonoBehaviour
{
    [SerializeField]GameObject ChickenPrefab;

    public void ChickenStart()
    {
        //Instantiate(ChickenPrefab, new Vector3(Random.Range(0.1f,50f), Random.Range(0.1f, 50f), 0), Quaternion.identity);
        Instantiate(ChickenPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        Debug.Log("»ý¼ºµÊ");
    }
}