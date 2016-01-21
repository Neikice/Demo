using UnityEngine;
using System.Collections;

public class MovementRootMotion : Movement
{
    public float MoveSpeed = 0f;
    protected override void move()
    {
        base.move();
        //攻击锁定方向
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            return;

        if (Input_x != 0 || Input_z != 0)
        {
            rig.MovePosition((rig.position + transform.forward.normalized * Time.fixedDeltaTime * MoveSpeed * movef));
        }
    }
}
