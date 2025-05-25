using UnityEngine;
using UnityEngine.EventSystems;

public class HoverOverImage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject HoverPanel; // The panel with text and image

    // Called when the mouse pointer enters the object's collider
    public void OnPointerEnter(PointerEventData eventData)
    {
        HoverPanel.SetActive(true);  // Show the panel with image and text
    }

    // Called when the mouse pointer exits the object's collider
    public void OnPointerExit(PointerEventData eventData)
    {
        HoverPanel.SetActive(false);  // Hide the panel when the cursor leaves
    }
}