using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalScale;
    private static GameObject lastClickedButton = null; // Store the last clicked button

    void Start()
    {
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (lastClickedButton != gameObject) // Only enlarge if it's not the selected button
        {
            LeanTween.scale(gameObject, originalScale * 1.1f, 0.2f).setEaseOutExpo();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (lastClickedButton != gameObject) // Do not shrink if it's the selected button
        {
            LeanTween.scale(gameObject, originalScale, 0.2f).setEaseOutExpo();
        }
    }

    public void OnClick()
    {
        if (lastClickedButton != null && lastClickedButton != gameObject)
        {
            // Reset the previous button's scale
            LeanTween.scale(lastClickedButton, lastClickedButton.GetComponent<ButtonHoverEffect>().originalScale, 0.2f).setEaseOutExpo();
        }

        // Store the newly clicked button
        lastClickedButton = gameObject;

        // Enlarge the clicked button
        LeanTween.scale(gameObject, originalScale * 1.1f, 0.2f).setEaseOutExpo();
    }
}
