using UnityEngine;
using UnityEngine.EventSystems;

public class ApplicationHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject circle;

    public void OnPointerEnter(PointerEventData eventData)
    {
        circle.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        circle.SetActive(false);
    }
}