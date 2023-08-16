using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ZoomOnImage : MonoBehaviour, IDragHandler, IScrollHandler, IPointerDownHandler
{
    //Drag 
    private RectTransform rectTr;

    //Mouse Scorll Zoom In/Out
    private Vector3 minitialScale;
    private float zoomSpeed = 0.1f;
    private float maxZoom = 5.0f;

    public Button originPositionBtn;

    public Transform faceImage; // faceImage 부모 오브젝트 참조
    public GameObject circlePrefab; 

    private void Start()
    {
        rectTr = GetComponent<RectTransform>(); //스크립트 위치의 Rect Transform
        minitialScale = transform.localScale;  //현재 Local Scale을 저장

        originPositionBtn.onClick.AddListener(OnClickOriginPositionBtn);  // 버튼 클릭 리스너 추가
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Middle) // 마우스 미들버튼이 클릭되었는지 확인
        {
            rectTr.anchoredPosition += eventData.delta * 2; // 드래그 이벤트 함수 선언 및 등록
        }
    }

    public void OnClickOriginPositionBtn()
    {
        rectTr.localPosition = new Vector3(-460f,0f,0f);  
        rectTr.localScale = Vector3.one;
    }

    public void OnScroll(PointerEventData eventData) //마우스 스크롤 이벤트 등록
    {
        var delta = Vector3.one * (eventData.scrollDelta.y * zoomSpeed);
        var desiredScale = transform.localScale + delta;

        desiredScale = ClampDesiredScale(desiredScale);

        transform.localScale = desiredScale;
    }

    private Vector3 ClampDesiredScale(Vector3 desiredScale) // 마우스 스크롤의 최대 줌인/아웃
    {
        desiredScale = Vector3.Max(minitialScale, desiredScale);
        desiredScale = Vector3.Min(minitialScale * maxZoom, desiredScale);

        return desiredScale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            RectTransform faceImageRect = faceImage as RectTransform;  // faceImage를 RectTransform으로 캐스팅
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(faceImageRect, eventData.position, eventData.pressEventCamera, out Vector2 localPointerPosition))
            {
                GameObject circle = Instantiate(circlePrefab, faceImage);
                circle.GetComponent<RectTransform>().anchoredPosition = localPointerPosition;
            }
        }
    }

}