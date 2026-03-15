using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeUIHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool mouse_over = false;
    private Turret turret;

    private void Awake()
    {
        turret = GetComponentInParent<Turret>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
        UIManager.main.SetHoveringState(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
        UIManager.main.SetHoveringState(false);
        if (turret != null)
        {
            turret.CloseUpgradeUI();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
