using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Screen : MonoBehaviour
{
    public event UnityAction ButtonClick;

    [SerializeField] protected CanvasGroup CanvasGroup;
    [SerializeField] protected Button Button;

    public void Close()
    {
        CanvasGroup.alpha = 0;
        Button.interactable = false;
    }
    public void Open()
    {
        CanvasGroup.alpha = 1;
        Button.interactable = true;
    }
    private void OnButtonClick()
    {
        ButtonClick?.Invoke();
    }


    private void OnEnable()
    {
        Button.onClick.AddListener(OnButtonClick);
    }
    private void OnDisable()
    {
        Button.onClick.RemoveListener(OnButtonClick);
    }
}
