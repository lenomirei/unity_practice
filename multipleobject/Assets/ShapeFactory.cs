using UnityEngine;

[CreateAssetMenu]
public class ShapeFactory : ScriptableObject
{
    [SerializeField]
    Shape[] perfabs;
    [SerializeField]
    Material[] materials;

    public Shape Get(int shapeID, int materialID) {
        Shape instance = Instantiate(perfabs[shapeID]);
        instance.ShapeID = shapeID;
        instance.SetMaterial(materials[materialID], materialID);
        return instance;
    }

    public Shape GetRandom() {
        int shapeID = Random.Range(0, perfabs.Length);
        int materialID = Random.Range(0, perfabs.Length);
        Shape instance = Instantiate(perfabs[shapeID]);
        instance.ShapeID = shapeID;
        instance.SetMaterial(materials[materialID], materialID);
        return instance;
    }
}
