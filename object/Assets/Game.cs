using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public PersistableObject perfab_;
    public PersistentStorage storage_;
    protected List<PersistableObject> objects_;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        objects_ = new List<PersistableObject>();
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

        else if (Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }

        else if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }

    void CreateObject()
    {
        PersistableObject cube = Instantiate(perfab_);
        Transform cube_transform = cube.transform;
        cube_transform.localPosition = Random.insideUnitSphere * 5;
        cube_transform.localRotation = Random.rotation;
        cube_transform.localScale = Vector3.one * Random.Range(0.1f, 1f);

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

    public void Save()
    {
        for (int i = 0; i < objects_.Count; ++i) { 

        }
    }

    public void Load()
    { 

    }
}
