using UnityEngine;
using UnityEngine.UI;

public class buttonSystem : MonoBehaviour
{
    public Button[] Seasoning_button; //0.오리지날 1.레드콤보 2.황금올리브 3.허니콤보
    public GameObject button_Parent;

    static public int Seasoning; //0.기본 1.Original 2.Red 3.Olive 4.Honey


    void Start()
    {
        Button_close();

        if (Seasoning_button[0] != null)
        {
            Seasoning_button[0].onClick.AddListener(OriginalButton_Click);
        }

        if (Seasoning_button[1] != null)
        {
            Seasoning_button[1].onClick.AddListener(RedButton_Click);
        }

        if (Seasoning_button[2] != null)
        {
            Seasoning_button[2].onClick.AddListener(OliveButton_Click);
        }

        if (Seasoning_button[3] != null)
        {
            Seasoning_button[3].onClick.AddListener(HoneyButton_Click);
        }
    }

    void Button_close()
    {
        //if (Delivery.hasChicken == 2 && Seasoning != 0)
        button_Parent.SetActive(false);
        Debug.Log("버튼off");
    }
    private void Button_open()
    {
        button_Parent.SetActive(true);
        Debug.Log("버튼on");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "AhDriver" && Delivery.hasChicken == 1)
        {
            Button_open();
        }
    }

    void OriginalButton_Click()
    {
        Seasoning = 1;
        Delivery.hasChicken = 2;
        Button_close();
    }

    void RedButton_Click()
    {
        Seasoning = 2;
        Delivery.hasChicken = 2;
        Button_close();
    }

    void OliveButton_Click()
    {
        Seasoning = 3;
        Delivery.hasChicken = 2;
        Button_close();
    }

    void HoneyButton_Click()
    {
        Seasoning = 4;
        Delivery.hasChicken = 2;
        Button_close();
    }


}