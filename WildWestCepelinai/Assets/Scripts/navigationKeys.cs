using UnityEngine;

public class RulesPopup : MonoBehaviour
{
    public GameObject rulesPanel; // Drag the Help/Panel GameObject here in the Inspector
    public float displayDuration = 3f;

    void Start()
    {
        if (rulesPanel != null)
        {
            rulesPanel.SetActive(true);
            Invoke("HideRules", displayDuration);
        }
    }

    void HideRules()
    {
        rulesPanel.SetActive(false);
    }
}
