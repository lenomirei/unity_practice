using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Indicator : MonoBehaviour
{
    public Transform second_indicator_;
    public Transform minute_indicator_;
    public Transform hour_indicator_;
    public Transform canvas_;
    public bool continuous = false;
    protected const float drgree_per_hour_ = 30f;
    protected const float drgree_per_ms_ = 6f;
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.UI.Toggle continuous_toggle = canvas_.Find("Toggle").GetComponent<UnityEngine.UI.Toggle>();

        continuous_toggle.onValueChanged.AddListener(delegate (bool changed)
        {
            continuous = changed;
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (continuous)
        {
            UpdateContinuous();
        }
        else
        {
            UpdateDicret();
        }
        
    }

    protected void UpdateContinuous()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;
        hour_indicator_.localRotation = Quaternion.Euler(new Vector3(0, (float)time.TotalHours * drgree_per_hour_, 0));
        minute_indicator_.localRotation = Quaternion.Euler(new Vector3(0, (float)time.TotalMinutes * drgree_per_ms_, 0));
        second_indicator_.localRotation = Quaternion.Euler(new Vector3(0, (float)time.TotalSeconds * drgree_per_ms_, 0));
    }

    protected void UpdateDicret()
    {
        DateTime time = DateTime.Now;
        hour_indicator_.localRotation = Quaternion.Euler(new Vector3(0, time.Hour * drgree_per_hour_, 0));
        minute_indicator_.localRotation = Quaternion.Euler(new Vector3(0, time.Minute * drgree_per_ms_, 0));
        second_indicator_.localRotation = Quaternion.Euler(new Vector3(0, time.Second * drgree_per_ms_, 0));
    }
}
