using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TextFormat
{
    PlainText,
    Time,
    Percentage
};

[RequireComponent(typeof(Text))]
public class DisplaySOFloatText : MonoBehaviour
{
    private Text text;
    public SOFloat displayFloat;
    public SOFloat secondFloat;
    public string prefix;
    public string suffix;
    public TextFormat format;

    void Start()
    {
       text = GetComponent<Text>();
    }

    void Update()
    {
        if (format == TextFormat.PlainText)
        {
            text.text = prefix + displayFloat.FloatValue.ToString("0") + suffix;
        }
        else if (format == TextFormat.Time)
        {
            System.TimeSpan t = System.TimeSpan.FromSeconds(displayFloat.FloatValue);
            text.text = prefix + string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds) + suffix;
        }
        else if (format == TextFormat.Percentage)
        {
            string percent = string.Format("{0,4:P1}",(displayFloat.FloatValue/secondFloat.FloatValue));
            text.text = prefix + percent + suffix;
        }

    }
}
