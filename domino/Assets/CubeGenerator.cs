using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    public GameObject cube_;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = new Vector3(0, 0.5f, 0);
        GameObject.Instantiate(cube_, pos, transform.rotation);
        for (float i = 0.5f; i <= 3f;) {
            pos.z = i;
            GameObject.Instantiate(cube_, pos, transform.rotation);
            pos.z = -i;
            GameObject.Instantiate(cube_, pos, transform.rotation);
            i += 0.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
