using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]GameObject followTarget;
    //(�ҹ���)gameObject - MonoBehaviour�� �ڽ�, cs�� ���� ������Ʈ
 
    void LateUpdate()
    {
        //transform - MonoBehaviour�� �ڽ�, cs�� ���� ������Ʈ�� transform
        transform.position = followTarget.transform.position+new Vector3(0,0,-10);
        //-10��ŭ�� ���͸� �� ���ش�
    }
}
