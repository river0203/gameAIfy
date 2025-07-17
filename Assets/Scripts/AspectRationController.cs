using UnityEngine;

[RequireComponent(typeof(Camera))] // �� ��ũ��Ʈ�� Camera ������Ʈ�� �ʿ��մϴ�.
public class AspectRatioController : MonoBehaviour
{
    // ��ǥ�� �ϴ� ȭ�� ���� (��: 16:9 = 1.7777...)
    public float targetAspect = 16.0f / 9.0f;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        UpdateAspectRatio();
    }

    void Update()
    {
        // �� �����Ӹ��� ȭ�� ������ üũ�Ͽ� ������ ���� ��� ������Ʈ�� ���� �ֽ��ϴ�.
        // ������ ������ Start()���� �� ���� �����ص� ����մϴ�.
        // UpdateAspectRatio(); 
    }

    public void UpdateAspectRatio()
    {
        // ���� ȭ���� ������ ���մϴ�.
        float windowAspect = (float)Screen.width / (float)Screen.height;

        // ���� ȭ�� ������ ��ǥ ������ ���մϴ�.
        float scaleHeight = windowAspect / targetAspect;

        Rect rect = cam.rect;

        if (scaleHeight < 1.0f) // ���� ȭ���� ��ǥ���� ���η� �� ���� ��� (���͹ڽ�)
        {
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;
        }
        else // ���� ȭ���� ��ǥ���� ���η� �� �� ��� (�ʷ��ڽ�)
        {
            float scaleWidth = 1.0f / scaleHeight;
            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;
        }

        cam.rect = rect;
    }
}