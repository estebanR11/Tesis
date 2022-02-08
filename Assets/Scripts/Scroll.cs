using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Scroll : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] Scrollbar scroll;

    public void onScrollChange()
    {
        RectTransform panelTransform = panel.GetComponent<RectTransform>();

        panelTransform.anchoredPosition = new Vector2(panelTransform.anchoredPosition.x, panelTransform.anchoredPosition.y + scroll.value);
    }
}
