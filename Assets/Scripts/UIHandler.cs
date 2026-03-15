using UnityEngine;
using UnityEngine.EventSystems;

public class UIHandler : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Plot plot = hit.collider.GetComponent<Plot>();
                if (plot != null)
                {
                    plot.OnMouseDown();
                }
            }
        }
    }
}
