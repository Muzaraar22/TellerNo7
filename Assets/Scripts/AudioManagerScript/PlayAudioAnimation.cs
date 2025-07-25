using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioAnimation : StateMachineBehaviour
{
    [SerializeField] string clipName;
    [SerializeField] int clipIndex = 0;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}