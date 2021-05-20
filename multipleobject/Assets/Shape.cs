using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : PersistableObject
{
    Color color;
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

    public void SetColor(Color color) {
        this.color = color;
        GetComponent<MeshRenderer>().material.color = color;
    }

    public override void Load(DataReader dr)
    {
        base.Load(dr);
        SetColor(dr.ReadColor());
    }

    public override void Save(DataWriter dw)
    {
        base.Save(dw);
        dw.WriteColor(this.color);
    }
}
