using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : PersistableObject
{
    public int ShapeID {
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

    public int MaterialID {
        get {
            return materialID;
        }

        private set {
        }
    }

    int materialID;

    public void SetMaterial(Material material, int id) {
        GetComponent<MeshRenderer>().material = material;
        materialID = id;
    }
}
