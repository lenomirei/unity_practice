using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    Player player_;
    Transform transform_;
    NavMeshAgent agent_;
    void Start()
    {
        transform_ = this.transform;
        agent_ = GetComponent<NavMeshAgent>();
        player_ = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        agent_.speed = 2.5f;
        agent_.SetDestination(player_.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
