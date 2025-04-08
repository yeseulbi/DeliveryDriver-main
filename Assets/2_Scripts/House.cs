using UnityEngine;
using UnityEngine.UI;

public class House : MonoBehaviour
{
    public string tv = "거실 tv";
    private string diary = "비밀 다이어리";
    protected string secretKey = "집 비밀번호";

    //private int age = 12;

    public string GetDiary()
    {
        return diary;
    }
}

