using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    Player player_;
    Transform transform_;
    NavMeshAgent agent_;
    int enemy_life_ = 10;
    float move_speed_ = 2.5f;
    float rot_speed_ = 5.0f;
    float timer_ = 2f;

    Animator ani_;
    
    // Start is called before the first frame update
    void Start()
    {
        transform_ = this.transform;
        ani_ = GetComponent<Animator>();
        agent_ = GetComponent<NavMeshAgent>();
        player_ = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        agent_.speed = move_speed_;
        agent_.SetDestination(player_.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (player_.life <= 0)
            return;
        timer_ -= Time.deltaTime;
        // 参数layerindex
        AnimatorStateInfo state = ani_.GetCurrentAnimatorStateInfo(0);
        if (state.fullPathHash == Animator.StringToHash("Base Layer.idle") && !ani_.IsInTransition(0))
        {
            ani_.SetBool("idle", false);

            if (timer_ > 0)
                return;

            if (Vector3.Distance(transform_.position, player_.transform_.position) <= 1.5f)
            {
                // 如果使用stopped还要再次启动，这里只需要清空寻路路径
                // agent_.isStopped = true;
                agent_.ResetPath();
                ani_.SetBool("attack", true);

            }
            else
            {
                timer_ = 1;
                agent_.SetDestination(player_.transform.position);
                ani_.SetBool("run", true);
            }
        }

        if (state.fullPathHash == Animator.StringToHash("Base Layer.run") && !ani_.IsInTransition(0))
        {
            ani_.SetBool("run", false);

            // 每隔一段时间重新寻路，可减少寻路次数
            if (timer_ < 0)
            {
                agent_.SetDestination(player_.transform.position);
                timer_ = 1;
            }

            if (Vector3.Distance(transform_.position, player_.transform.position) <= 1.5f)
            {
                //agent_.isStopped = true;
                agent_.ResetPath();
                ani_.SetBool("attack", true);
            }
        }

        if (state.fullPathHash == Animator.StringToHash("Base Layer.attack") && !ani_.IsInTransition(0))
        {
            RotateTo();
            ani_.SetBool("attack", false);

            if (state.normalizedTime >= 1.0f)
            {
                ani_.SetBool("idle", true);
                timer_ = 2;

            }
        }
    }

    void RotateTo()
    {
        Vector3 targetdir = player_.transform.position - transform_.position;
        Vector3 newdir = Vector3.RotateTowards(transform_.forward, targetdir, rot_speed_ * Time.deltaTime, 0.0f);
        transform_.rotation = Quaternion.LookRotation(newdir);
    }
}
