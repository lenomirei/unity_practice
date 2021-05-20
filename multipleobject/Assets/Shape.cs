using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : PersistableObject
{
    Color color;
    MeshRenderer renderer;

    private void Awake()
    {
        renderer = GetComponent<MeshRenderer>();
    }

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
        renderer.material = material;
        materialID = id;
    }

    public void SetColor(Color color) {
        this.color = color;
        // 设置材质的颜色会创建一个新的材质
        // GetComponent<MeshRenderer>().material.color = color;
        var propertyBlock = new MaterialPropertyBlock();
        propertyBlock.SetColor("_Color", color);
        renderer.SetPropertyBlock(propertyBlock);
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
