using UnityEngine;
using UnityEngine.UI;

public class Driver : MonoBehaviour
{
    [SerializeField] Text moveSpeed_Text;
    [SerializeField, Tooltip("속도를 조절해보세요.")] float turnSpeed = 200f;
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float slowAcclerationRatio = 0.5f;
    [SerializeField] float boostAcclerationRatio = 1.5f;
    float boostSpeed;
    float slowSpeed;

    private void Start()
    {
        slowSpeed = moveSpeed * slowAcclerationRatio;
        boostSpeed = moveSpeed * boostAcclerationRatio;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Boost"))
        {
            moveSpeed = boostSpeed;
            Debug.Log("Booost!");
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = slowSpeed;
    }
    void Update()
    {
        float turnamount = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        float moveamount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -turnamount);
        transform.Translate(0, moveamount, 0);

    }
}
