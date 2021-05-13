using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class DataWriter
{
    protected string savePath;
    protected BinaryWriter writer;
    public DataWriter() {
        savePath = "./savedata";
        writer = new BinaryWriter(File.Open(savePath, FileMode.Create));
    }

    public void Write(Quaternion value) {
        writer.Write(value.x);
        writer.Write(value.y);
        writer.Write(value.z);
        writer.Write(value.w);
    }

    public void Write(Vector3 value) {
        writer.Write(value.x);
        writer.Write(value.y);
        writer.Write(value.z);
    }
}
