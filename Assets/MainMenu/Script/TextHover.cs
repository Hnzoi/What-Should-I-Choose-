using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverScaleEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform textTransform;
    public Vector3 hoverScale = new Vector3(1.5f, 1.5f, 1.5f);
    public Vector3 normalScale = new Vector3(1f, 1f, 1f);

    public void OnPointerEnter(PointerEventData eventData)
    {
        textTransform.localScale = hoverScale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textTransform.localScale = normalScale;
    }

    public void NormalSize()
    {
        textTransform.localScale = normalScale;
    }
}