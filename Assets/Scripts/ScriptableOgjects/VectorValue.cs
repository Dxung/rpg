using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class VectorValue : ScriptableObject,ISerializationCallbackReceiver
{
    public Vector2 _initialValue;
    public Vector2 _defaultValue;
    
    public void OnAfterDeserialize()
    {
        _initialValue = _defaultValue;
    }

    public void OnBeforeSerialize()
    {

    }
}
