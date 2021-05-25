using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu]
public class ShapeFactory : ScriptableObject
{
    [SerializeField]
    Shape[] perfabs;
    [SerializeField]
    Material[] materials;
    [SerializeField]
    bool recycle;

    List<Shape>[] pools;

    public Shape Get(int shapeID, int materialID) {
        Shape instance;
        if (recycle) {
            if (pools == null) {
                CreatePools();
            }

            List<Shape> pool = pools[shapeID];
            int lastIndex = pool.Count - 1;
            if (lastIndex > 0) {
                instance = pool[lastIndex];
                instance.gameObject.SetActive(true);
                pool.RemoveAt(lastIndex);
            }
            else {
                instance = Instantiate(perfabs[shapeID]);
                instance.ShapeID = shapeID;
            }
        }
        else {
            instance = Instantiate(perfabs[shapeID]);
            instance.ShapeID = shapeID;
        }
        instance.SetMaterial(materials[materialID], materialID);
        return instance;
    }

    public void Reclaim(Shape shapeToRecycle) {
        if (recycle) {
            if (pools == null)
            {
                CreatePools();
            }
            pools[shapeToRecycle.ShapeID].Add(shapeToRecycle);
            shapeToRecycle.gameObject.SetActive(false);
        }
        else {
            Destroy(shapeToRecycle);
        }
    }

    public Shape GetRandom() {
        int shapeID = Random.Range(0, perfabs.Length);
        int materialID = Random.Range(0, perfabs.Length);
        Shape instance = Instantiate(perfabs[shapeID]);
        instance.ShapeID = shapeID;
        instance.SetMaterial(materials[materialID], materialID);
        return instance;
    }

    void CreatePools() {
        pools = new List<Shape>[perfabs.Length];

        for (int i = 0; i < perfabs.Length; ++i) {
            pools[i] = new List<Shape>();
        }

    }
}
