using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MyInputField : InputFieldOriginal
{
    public bool hasSelection = false;
    [SerializeField] Button button;
    int startIndex;
    int endIndex;

    public void DeleteSymbol()
    {
        if (hasSelection)
        {
            DeleteSelectedText();
            OnValueChanged();
            return;
        }
        OnValueChanged();
        caretPosition = caretPositionInternal - 1;
        ShowCaret();
        if (text.Length - 1 >= 0)
        {
            m_Text = text.Remove(caretPositionInternal, 1);
            OnValueChanged();
        }
    }
    public void OnValueChanged() => SendOnValueChangedAndUpdateLabel();
    public void FocusObject() => SelectAll();
    public void DecreaseCaretPosition()
    {
        ShowCaret();
        caretPosition--;
        OnValueChanged();
    }
    public void IncreaseCaretPosition()
    {
        ShowCaret();
        caretPosition++;
        OnValueChanged();
    }
    /// <summary>
    /// Show caret on focused
    /// </summary>
    public void ShowCaret()
    {
        m_AllowInput = true;
        m_CaretVisible = true;
    }
    /// <summary>
    /// Removes selected text
    /// </summary>
    public void DeleteSelectedText()
    {
        if (!hasSelection) return;
        caretPositionInternal = startIndex;
        caretSelectPositionInternal = endIndex;
        GetSelectedString();
        Delete();
        hasSelection = false;
    }
    public override void OnBeginDrag(PointerEventData eventData)
    {
        hasSelection = false;
        base.OnBeginDrag(eventData);
        startIndex = caretPosition;
    }
    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        endIndex = caretPosition;
        hasSelection = true;
    }

}