using UnityEngine;

public class Chicken : MonoBehaviour
{
    [SerializeField] GameObject ChickenPrefab;
    public static GameObject newchicken;

    public void ChickenStart()
    {
        //Instantiate(ChickenPrefab, new Vector3(Random.Range(0.1f,50f), Random.Range(0.1f, 50f), 0), Quaternion.identity);
        newchicken = Instantiate(ChickenPrefab, new Vector2(0.27f, 3.81f), Quaternion.identity); // ġŲ �����Ǹ鼭 ����
        Debug.Log("������");
    }

    /*    private void OnTriggerStay2D(Collider2D collision) // ġŲ ����
        {
            if (ChickenPrefab != null && !collision.gameObject.CompareTag("Road"))
            {
                ChickenPrefab.transform.position = new Vector2(39 + Random.Range(-43, 43), 4.5f + Random.Range(-36, 36));
                Debug.Log("�̵�");
            }
        }*/
}