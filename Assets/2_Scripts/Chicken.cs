using UnityEngine;

public class Chicken : MonoBehaviour
{
    [SerializeField] GameObject ChickenPrefab;
    GameObject newChicken;
    public void ChickenStart()
    {
        //Instantiate(ChickenPrefab, new Vector3(Random.Range(0.1f,50f), Random.Range(0.1f, 50f), 0), Quaternion.identity);
        newChicken = Instantiate(ChickenPrefab, new Vector2(39 + Random.Range(0, 43), 4.5f + Random.Range(0, 36)), Quaternion.identity); // 치킨 생성되면서 랜덤(미완)
        Debug.Log("생성됨");
    }

    private void OnTriggerStay2D(Collider2D collision) // 치킨 랜덤
    {
        if (!collision.gameObject.CompareTag("Road"))
        {
            newChicken.transform.position = new Vector2(39 + Random.Range(0, 43), 4.5f + Random.Range(0, 36));
        }
    }
}