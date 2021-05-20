using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : PersistableObject
{
    public ShapeFactory shapeFactory;
    public PersistentStorage storage;
    protected List<Shape> shapes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        shapes = new List<Shape>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            CreateShape();
        }

        else if (Input.GetKeyDown(KeyCode.X)) {
            DestroyShape();
        }

        else if (Input.GetKeyDown(KeyCode.N))
        {
            BeginNewGame();
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            storage.Save(this);
        }

        else if (Input.GetKeyDown(KeyCode.L))
        {
            storage.Load(this);
        }
    }

    void CreateShape()
    {
        Shape shape = shapeFactory.GetRandom();
        Transform shape_transform = shape.transform;
        shape_transform.localPosition = Random.insideUnitSphere * 5;
        shape_transform.localRotation = Random.rotation;
        shape_transform.localScale = Vector3.one * Random.Range(0.1f, 1f);
        shape.SetColor(Random.ColorHSV());

        shapes.Add(shape);
    }

    void DestroyShape() {
        if (shapes.Count > 0) {
            int index = Random.Range(0, shapes.Count);
            Destroy(shapes[index].gameObject);
            shapes[index] = shapes[shapes.Count - 1];
            shapes.RemoveAt(shapes.Count - 1);
        }
    }

    void BeginNewGame()
    {
        for (int i = 0; i < shapes.Count; ++i)
        {
            Destroy(shapes[i].gameObject);
        }

        shapes.Clear();
    }

    public override void Save(DataWriter writer)
    {
        int count = shapes.Count;
        writer.Write(count);
        for (int i = 0; i < count; ++i) {
            int shapeID = shapes[i].ShapeID;
            int materialID = shapes[i].MaterialID;
            writer.Write(shapeID);
            writer.Write(materialID);
            shapes[i].Save(writer);
        }
    }

    public override void Load(DataReader reader)
    {
        int count = reader.ReadInt();
        for (int i = 0; i < count; ++i) {
            int shapeID = reader.ReadInt();
            int materialID = reader.ReadInt();
            Shape shape = Instantiate(shapeFactory.Get(shapeID, materialID));
            shape.Load(reader);
            shapes.Add(shape);
        }
    }
}
