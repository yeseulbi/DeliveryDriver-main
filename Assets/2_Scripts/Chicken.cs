using UnityEngine;

public class Chicken : MonoBehaviour
{
    [SerializeField] GameObject ChickenPrefab;
    GameObject newChicken;
    public void ChickenStart()
    {
        //Instantiate(ChickenPrefab, new Vector3(Random.Range(0.1f,50f), Random.Range(0.1f, 50f), 0), Quaternion.identity);
        newChicken = Instantiate(ChickenPrefab, new Vector2(39 + Random.Range(0, 43), 4.5f + Random.Range(0, 36)), Quaternion.identity); // ġŲ �����Ǹ鼭 ����(�̿�)
        Debug.Log("������");
    }

    private void OnTriggerStay2D(Collider2D collision) // ġŲ ����
    {
        if (!collision.gameObject.CompareTag("Road"))
        {
            newChicken.transform.position = new Vector2(39 + Random.Range(0, 43), 4.5f + Random.Range(0, 36));
        }
    }
}