using UnityEngine;

public class Drift_Sub : MonoBehaviour
{
    public Transform leader;         // ���� ������Ʈ (��: Player)
    public float followDistance = 1f; // �󸶳� �ڿ� ������
    public float moveSpeed = 5f;

    private Vector2 lastLeaderPos;

    void Start()
    {
        if (leader != null)
            lastLeaderPos = leader.position;
    }

    void Update()
    {
        if (leader == null) return;

        // ���� �̵� ���� ���
        Vector2 currentLeaderPos = leader.position;
        Vector2 moveDir = ((Vector2)currentLeaderPos - lastLeaderPos).normalized;

        // ��ǥ ��ġ = ������ ��ġ - �̵����� * �Ÿ�
        Vector2 targetPos = (Vector2)leader.position - moveDir * followDistance;

        // �ε巴�� �̵� (����)
        transform.position = Vector2.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);

        // ���� ��ġ ����
        lastLeaderPos = currentLeaderPos;
    }
}