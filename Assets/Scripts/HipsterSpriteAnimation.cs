using UnityEngine;
using System.Collections;

public class HipsterSpriteAnimation : MonoBehaviour {

	public GameObject hipster;
	Animator anim;
	NavMeshAgent agent;
	int xVelocityHash = Animator.StringToHash("xVelocity");
	int drinkingHash = Animator.StringToHash("drinking");
	int idleHash = Animator.StringToHash("idle");
//	bool drinking;
	
	void Start () {
		anim = GetComponent<Animator>();
		agent = hipster.GetComponent<NavMeshAgent>();
//		drinking = hipster.GetComponent<HipsterNav>().drinking;
	}
	
	void Update () {
		anim.SetBool(drinkingHash,hipster.GetComponent<HipsterNav>().drinking);
		float xVelocity = agent.velocity.x;
		if(xVelocity == 0f){
			anim.SetBool(idleHash, true);
		} else {
			anim.SetBool(idleHash, false);
		}
		anim.SetFloat(xVelocityHash,xVelocity);
	}
}
