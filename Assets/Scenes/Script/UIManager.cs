using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public RectTransform UI_Element;
    public RectTransform CanvasRect;
    public Transform trashBinPos;
    public float xOffset;
    public float yOffset;
    public Text   coinNumber;
    void Start()
    {
        
    }

    
    void Update()
    {
        Vector2 viewportPos = Camera.main.WorldToViewportPoint(trashBinPos.position);
        Vector2 worldObjectScreenPos = new Vector2((viewportPos.x*CanvasRect.sizeDelta.x)-
                                                (CanvasRect.sizeDelta.x*0.5f)+xOffset,
                                                (viewportPos.y*CanvasRect.sizeDelta.x)-
                                                (CanvasRect.sizeDelta.y*0.5f)+yOffset);
        UI_Element.anchoredPosition=worldObjectScreenPos;
    }
}
