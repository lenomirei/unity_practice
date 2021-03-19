using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField, Range(0f, 100f)] float max_speed = 10f;
    [SerializeField, Range(0f, 100f)] float max_acceleration = 10f;
    [SerializeField] Rect allowed_area = new Rect(-4.5f, -4.5f, 9.0f, 9.0f);

    Vector3 v;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 player_input;
        player_input.x = Input.GetAxis("Horizontal");
        player_input.y = Input.GetAxis("Vertical");

        player_input = Vector2.ClampMagnitude(player_input, 1.0f);
        Vector3 desired_v = new Vector3(player_input.x, 0f, player_input.y) * max_speed;
        float max_speed_change = max_acceleration * Time.deltaTime;
        // MoveTowards的作用是,第一个参数为目前值，第二个参数为目标值，第三个参数为变化值，当目前值变化超过目标值，则返回值为目标值（防止过冲）
        v.x = Mathf.MoveTowards(v.x, desired_v.x, max_speed_change);
        v.z = Mathf.MoveTowards(v.z, desired_v.z, max_speed_change);
        Vector3 d = v * Time.deltaTime;
        Vector3 new_position = transform.localPosition + d;
        if (!allowed_area.Contains(new Vector2(new_position.x, new_position.z))) {
            new_position.x = Mathf.Clamp(new_position.x, allowed_area.xMin, allowed_area.xMax);
            new_position.z = Mathf.Clamp(new_position.z, allowed_area.yMin, allowed_area.yMax);
            v.x = -v.x;
            v.z = -v.z;
        }
        transform.localPosition = new_position;
    }
}
