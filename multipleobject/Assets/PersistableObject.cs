using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[DisallowMultipleComponent]
public class PersistableObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Save(DataWriter dw)
    {
        dw.Write(this.transform.localPosition);
        dw.Write(this.transform.localRotation);
        dw.Write(this.transform.localScale);
    }

    public virtual void Load(DataReader dw)
    {
        this.transform.localPosition = dw.ReadVector3();
        this.transform.localRotation = dw.ReadQuaternion();
        this.transform.localScale = dw.ReadVector3();
    }
}
