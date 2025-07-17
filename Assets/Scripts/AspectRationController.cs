using UnityEngine;

[RequireComponent(typeof(Camera))] // 이 스크립트는 Camera 컴포넌트가 필요합니다.
public class AspectRatioController : MonoBehaviour
{
    // 목표로 하는 화면 비율 (예: 16:9 = 1.7777...)
    public float targetAspect = 16.0f / 9.0f;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        UpdateAspectRatio();
    }

    void Update()
    {
        // 매 프레임마다 화면 비율을 체크하여 변경이 있을 경우 업데이트할 수도 있습니다.
        // 하지만 보통은 Start()에서 한 번만 설정해도 충분합니다.
        // UpdateAspectRatio(); 
    }

    public void UpdateAspectRatio()
    {
        // 현재 화면의 비율을 구합니다.
        float windowAspect = (float)Screen.width / (float)Screen.height;

        // 현재 화면 비율과 목표 비율을 비교합니다.
        float scaleHeight = windowAspect / targetAspect;

        Rect rect = cam.rect;

        if (scaleHeight < 1.0f) // 현재 화면이 목표보다 가로로 더 넓은 경우 (레터박스)
        {
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;
        }
        else // 현재 화면이 목표보다 세로로 더 긴 경우 (필러박스)
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