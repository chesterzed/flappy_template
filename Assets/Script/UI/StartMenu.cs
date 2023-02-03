using UnityEngine;
using UnityEngine.Events;

public class StartMenu : ScreenMenu
{
    public event UnityAction PlayButtonClick;

    protected override void OnButtonClick()
    {
        PlayButtonClick?.Invoke();
    }

    public override void Open()
    {
        canvasGroup.alpha = 1;
        button.interactable = true;
    }

    public override void Close()
    {
        canvasGroup.alpha = 0;
        button.interactable = false;
    }
}
