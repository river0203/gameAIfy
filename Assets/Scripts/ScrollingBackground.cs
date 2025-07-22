using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float speed = 5f; // ����� �����̴� �ӵ�
    private float width;     // ��� �̹����� ���� ����

    void Start()
    {
        // SpriteRenderer ������Ʈ���� �̹����� ���� ���̸� �����ɴϴ�.
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        width = sr.bounds.size.x;
    }

    void Update()
    {
        // �� �����Ӹ��� �������� ����� �̵���ŵ�ϴ�.
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // ����� �������� Ư�� ����(-width)��ŭ �̵��ߴٸ�,
        // ���� ��ġ���� ���� ������ 2�踸ŭ ���������� �̵����� ���ġ�մϴ�.
        if (transform.position.x <= -width)
        {
            Reposition();
        }
    }

    // ����� ���ġ�ϴ� �Լ�
    void Reposition()
    {
        // ���� ��ġ���� ���������� ���� ������ 2�踸ŭ �̵��մϴ�.
        // (�� ���� ����̹Ƿ� 2��)
        transform.position += new Vector3(width * 4f, 0, 0);
    }
}