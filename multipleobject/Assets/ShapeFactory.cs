using UnityEngine;

[CreateAssetMenu]
public class ShapeFactory : ScriptableObject
{
    [SerializeField]
    Shape[] perfabs;

    public Shape Get(int shapeID) {
        Shape instance = Instantiate(perfabs[shapeID]);
        instance.ShapeID = shapeID;
        return instance;
    }

    public Shape GetRandom() {
        int shapeID = Random.Range(0, perfabs.Length);
        Shape instance = Instantiate(perfabs[shapeID]);
        instance.ShapeID = shapeID;
        return instance;
    }
}
