using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Screen : MonoBehaviour
{
    [SerializeField] protected CanvasGroup CanvasGroup;
    [SerializeField] protected Button Button;


    public abstract void Open();
    public abstract void Close();
    protected abstract void OnButtonClick();


    private void OnEnable()
    {
        Button.onClick.AddListener(OnButtonClick);
    }
    private void OnDisable()
    {
        Button.onClick.RemoveListener(OnButtonClick);
    }
}
