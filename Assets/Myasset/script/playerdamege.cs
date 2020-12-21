using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerdamege : StateMachineBehaviour

{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("damege", false);
    }
}
