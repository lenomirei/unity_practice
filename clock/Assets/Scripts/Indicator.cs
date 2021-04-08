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
    protected const float drgree_per_ms_ = 6f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DateTime time = DateTime.Now;
        hour_indicator_.localRotation = Quaternion.Euler(new Vector3(0, time.Hour * drgree_per_hour_, 0));
        minute_indicator_.localRotation = Quaternion.Euler(new Vector3(0, time.Minute * drgree_per_ms_, 0));
        second_indicator_.localRotation = Quaternion.Euler(new Vector3(0, time.Second * drgree_per_ms_, 0));
    }
}
