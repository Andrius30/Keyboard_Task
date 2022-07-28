using Andrius.Utils.Timers;
using System.Collections;
using UnityEngine;

public class DeleteText
{
    public Timer holdTimer;
    VirtualKeyboard keyboard;
    WaitForSeconds wait;
    bool isRoutineRunning = false;

    public DeleteText(VirtualKeyboard keyboard)
    {
        this.keyboard = keyboard;
        holdTimer = new Timer(0, OnHoldDeleteTimeOut, false, true);
        wait = new WaitForSeconds(keyboard.updateRatio);
    }

    public void OnDelete() => keyboard.InputField.DeleteSymbol();
    public void OnUpdate()
    {
        if (holdTimer.IsDone()) return;
        holdTimer.StartTimer();
    }

    void OnHoldDeleteTimeOut()
    {
        if (keyboard.isHolding)
        {
            keyboard.StartCoroutine(HoldDeleteRoultine());
        }
    }
    IEnumerator HoldDeleteRoultine()
    {
        if (isRoutineRunning) yield break;
        isRoutineRunning = true;
        while (keyboard.isHolding)
        {
            OnDelete();
            yield return wait;
        }
        isRoutineRunning = false;
        yield break;
    }
}