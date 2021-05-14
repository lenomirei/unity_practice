using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PersistentStorage : MonoBehaviour
{
    string savePath;
    // Start is called before the first frame update
    void Start()
    {
        savePath = "./savedata";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save(PersistableObject po)
    {
        var writer = new BinaryWriter(File.Open(savePath, FileMode.Create));
        po.Save(new DataWriter(writer));
    }

    public void Load(PersistableObject po)
    {
        var reader = new BinaryReader(File.Open(savePath, FileMode.Open));
        po.Load(new DataReader(reader));
    }
}
