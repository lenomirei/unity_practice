using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Transform perfab_;
    protected List<Transform> objects_;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        objects_ = new List<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            CreateObject();
        }

        else if (Input.GetKeyDown(KeyCode.N))
        {
            BeginNewGame();
        }
    }

    void CreateObject()
    {
        Transform cube = Instantiate(perfab_);
        cube.localPosition = Random.insideUnitSphere * 5;
        cube.localRotation = Random.rotation;
        cube.localScale = Vector3.one * Random.Range(0.1f, 1f);

        objects_.Add(cube);
    }

    void BeginNewGame()
    {
        for (int i = 0; i < objects_.Count; ++i)
        {
            Destroy(objects_[i].gameObject);
        }

        objects_.Clear();
    }

    void Save()
    { 

    }

    void Load()
    { 

    }
}
