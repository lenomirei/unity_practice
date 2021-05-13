using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataReader
{
    protected string savePath;
    protected BinaryReader reader;

    public DataReader() {
        savePath = "./savedata";
        reader = new BinaryReader(File.Open(savePath, FileMode.Open));
    }

    public Quaternion ReadQuaternion() {
        Quaternion result = new Quaternion();
        result.x = reader.ReadSingle();
        result.y = reader.ReadSingle();
        result.z = reader.ReadSingle();
        result.w = reader.ReadSingle();
        return result;
    }

    public Vector3 ReadVector3() {
        Vector3 result = new Vector3();
        result.x = reader.ReadSingle();
        result.y = reader.ReadSingle();
        result.z = reader.ReadSingle();
        return result;
    }
}
