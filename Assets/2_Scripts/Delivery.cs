using UnityEngine;
using UnityEngine.UI;

public class Delivery : MonoBehaviour
{
    public Chicken chickenCS;
    [SerializeField] float delayTime = 0.5f;
    [SerializeField] Color noChickenColor = new Color(1, 1, 1, 1);
    [SerializeField] Color hasChickenColor = new Color(1, 0.3884149f, 0, 1);

    public static int hasChicken = 0; //0.기본 1.닭고기 보유 2.치킨 보유
    bool Seasoning = false;

    [SerializeField] Text Order;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Chicken") && hasChicken == 0)
        {
            Debug.Log("치킨 픽업됨");
            Order.text = "닭고기 획득! 오더에 맞게 조리하자";
            hasChicken = 1;
            Seasoning = true;
            Destroy(collision.gameObject, delayTime);
            spriteRenderer.color = hasChickenColor;
        }

        if (collision.gameObject.CompareTag("Customer") && hasChicken == 2)
        {
            Debug.Log("치킨 배달됨");
            Order.text = "닭고기가 없습니다. 고기를 획득하세요";
            chickenCS.ChickenStart();
            hasChicken = 0;
            buttonSystem.Seasoning = 0; //치킨 시즈닝 제거
            spriteRenderer.color = noChickenColor;
        }
    }
    private void Update()
    {
        if (hasChicken == 2 && Seasoning)
        {
            Order.text = "배달을 시작하자!";
            Seasoning = false;
        }
    }
}
