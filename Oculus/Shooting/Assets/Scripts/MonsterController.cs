using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour {

    public Animator animator;
    public AnimationClip[] clips;
    public static MonsterController sharedInstance;

    void Awake()
    {
        sharedInstance = this;
        clips = animator.runtimeAnimatorController.animationClips;
    }

    public void StartGame()
    {
        EnemyMovement.sharedInstance.alive = true;
        animator.SetBool("isAlive", true);
    }


}
