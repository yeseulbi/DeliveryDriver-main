using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]GameObject followTarget;
    //(소문자)gameObject - MonoBehaviour의 자식, cs를 가진 컴포넌트
 
    void LateUpdate()
    {
        //transform - MonoBehaviour의 자식, cs를 가진 컴포넌트의 transform
        transform.position = followTarget.transform.position+new Vector3(0,0,-10);
        //-10만큼의 백터를 더 해준다
    }
}
