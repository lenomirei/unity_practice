using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : PersistableObject
{
    public int ShapeID
    {
        get {
            return shapeID;
        }
        set {
            if (shapeID == 0) {
                shapeID = value;
            }
            else {
                Debug.LogError("Can not change shape");
            }
        }

    }
    int shapeID;
}
