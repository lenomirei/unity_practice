using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class DataWriter
{
    protected string savePath_;
    protected BinaryWriter writer;
    public DataWriter(BinaryWriter writer) {
        this.writer = writer;
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

    public void Write(float value) {
        writer.Write(value);
    }

    public void Write(int value) {
        writer.Write(value);
    }

    public void WriteColor(Color color) {
        writer.Write(color.r);
        writer.Write(color.g);
        writer.Write(color.b);
        writer.Write(color.a);
    }
}
