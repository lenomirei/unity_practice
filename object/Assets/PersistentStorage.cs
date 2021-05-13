using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentStorage : MonoBehaviour
{
    // Start is called before the first frame update
    protected DataWriter writer;
    protected DataReader reader;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save(PersistableObject po)
    {
        po.Save(writer);
    }

    public void Load(PersistableObject po)
    {
        po.Load(reader);
    }
}
