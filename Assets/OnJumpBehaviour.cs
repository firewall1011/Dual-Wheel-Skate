using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnJumpBehaviour : StateMachineBehaviour
{
    [SerializeField] private float threshold = .5f;
    [SerializeField] private VoidEventChannelSO JumpAction = default;

    private bool hasJumped = false;

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        if (!hasJumped && stateInfo.normalizedTime >= threshold)
        {
            JumpAction?.RaiseEvent();
            hasJumped = true;
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        hasJumped = false;
    }
}
