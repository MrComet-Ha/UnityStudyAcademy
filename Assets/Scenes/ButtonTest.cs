using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTest : MonoBehaviour
{
    [SerializeField] private Button redButton, blueButton;
    [SerializeField] TextMeshProUGUI text;

    private void OnEnable()
    {
        redButton?.onClick.AddListener(SetTextRed);
        blueButton?.onClick.AddListener(SetTextBlue);
    }

    private void OnDisable()
    {
        redButton?.onClick.RemoveListener(SetTextRed);
        blueButton?.onClick.RemoveListener(SetTextBlue);
    }

    void SetText(string _text)
    {
        if (text != null)
            text.text = _text;
    }

    // 테스트용(권장 X)
    public void SetTextRed()
    {
        if (this.text != null)
            this.text.text = "Red";
    }
    public void SetTextBlue()
    {
        if (this.text != null)
            this.text.text = "Blue";
    }
}
