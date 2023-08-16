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

    public Transform faceImage; // faceImage �θ� ������Ʈ ����
    public GameObject circlePrefab; 

    private void Start()
    {
        rectTr = GetComponent<RectTransform>(); //��ũ��Ʈ ��ġ�� Rect Transform
        minitialScale = transform.localScale;  //���� Local Scale�� ����

        originPositionBtn.onClick.AddListener(OnClickOriginPositionBtn);  // ��ư Ŭ�� ������ �߰�
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Middle) // ���콺 �̵��ư�� Ŭ���Ǿ����� Ȯ��
        {
            rectTr.anchoredPosition += eventData.delta * 2; // �巡�� �̺�Ʈ �Լ� ���� �� ���
        }
    }

    public void OnClickOriginPositionBtn()
    {
        rectTr.localPosition = new Vector3(-460f,0f,0f);  
        rectTr.localScale = Vector3.one;
    }

    public void OnScroll(PointerEventData eventData) //���콺 ��ũ�� �̺�Ʈ ���
    {
        var delta = Vector3.one * (eventData.scrollDelta.y * zoomSpeed);
        var desiredScale = transform.localScale + delta;

        desiredScale = ClampDesiredScale(desiredScale);

        transform.localScale = desiredScale;
    }

    private Vector3 ClampDesiredScale(Vector3 desiredScale) // ���콺 ��ũ���� �ִ� ����/�ƿ�
    {
        desiredScale = Vector3.Max(minitialScale, desiredScale);
        desiredScale = Vector3.Min(minitialScale * maxZoom, desiredScale);

        return desiredScale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            RectTransform faceImageRect = faceImage as RectTransform;  // faceImage�� RectTransform���� ĳ����
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(faceImageRect, eventData.position, eventData.pressEventCamera, out Vector2 localPointerPosition))
            {
                GameObject circle = Instantiate(circlePrefab, faceImage);
                circle.GetComponent<RectTransform>().anchoredPosition = localPointerPosition;
            }
        }
    }

}