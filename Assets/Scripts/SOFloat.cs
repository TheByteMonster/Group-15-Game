using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOFloat : ScriptableObject
{
    [HideInInspector]
    [SerializeField]
    private float floatValue;
    public float FloatValue { get { return floatValue; } set { floatValue = value; } }
    [SerializeField]
    private float resetValue;

    public void Reset()
    {
        floatValue = resetValue;
    }
}
