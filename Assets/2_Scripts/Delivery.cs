using UnityEngine;
using UnityEngine.UI;

public class Delivery : MonoBehaviour
{
    public Chicken chickenCS;
    [SerializeField] float delayTime = 0.5f;
    [SerializeField] Color noChickenColor = new Color(1, 1, 1, 1);
    [SerializeField] Color hasChickenColor = new Color(1, 0.3884149f, 0, 1);

    public static int hasChicken = 0; //0.�⺻ 1.�߰�� ���� 2.ġŲ ����
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
            Debug.Log("ġŲ �Ⱦ���");
            Order.text = "�߰�� ȹ��! ������ �°� ��������";
            hasChicken = 1;
            Seasoning = true;
            Destroy(collision.gameObject, delayTime);
            spriteRenderer.color = hasChickenColor;
        }

        if (collision.gameObject.CompareTag("Customer") && hasChicken == 2)
        {
            Debug.Log("ġŲ ��޵�");
            Order.text = "�߰�Ⱑ �����ϴ�. ��⸦ ȹ���ϼ���";
            chickenCS.ChickenStart();
            hasChicken = 0;
            buttonSystem.Seasoning = 0; //ġŲ ����� ����
            spriteRenderer.color = noChickenColor;
        }
    }
    private void Update()
    {
        if (hasChicken == 2 && Seasoning)
        {
            Order.text = "����� ��������!";
            Seasoning = false;
        }
    }
}
