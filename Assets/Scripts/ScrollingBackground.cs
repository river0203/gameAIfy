using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float speed = 5f; // 배경이 움직이는 속도
    private float width;     // 배경 이미지의 가로 길이

    void Start()
    {
        // SpriteRenderer 컴포넌트에서 이미지의 가로 길이를 가져옵니다.
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        width = sr.bounds.size.x;
    }

    void Update()
    {
        // 매 프레임마다 왼쪽으로 배경을 이동시킵니다.
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // 배경이 왼쪽으로 특정 지점(-width)만큼 이동했다면,
        // 원래 위치에서 가로 길이의 2배만큼 오른쪽으로 이동시켜 재배치합니다.
        if (transform.position.x <= -width)
        {
            Reposition();
        }
    }

    // 배경을 재배치하는 함수
    void Reposition()
    {
        // 현재 위치에서 오른쪽으로 가로 길이의 2배만큼 이동합니다.
        // (두 개의 배경이므로 2배)
        transform.position += new Vector3(width * 4f, 0, 0);
    }
}