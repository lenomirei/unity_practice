using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Indicator : MonoBehaviour
{
    public Transform second_indicator_;
    public Transform minute_indicator_;
    public Transform hour_indicator_;
    protected const float drgree_per_hour_ = 30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        DateTime time = DateTime.Now;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
