using UnityEngine;
using System.Collections;

public class WizardSpriteAnimation : MonoBehaviour {

	public GameObject wizard;
	Animator anim;
	UnityEngine.AI.NavMeshAgent agent;
	int xVelocityHash = Animator.StringToHash("xVelocity");
	int dizzyHash = Animator.StringToHash("dizzy");
	int idleHash = Animator.StringToHash("idle");
	public string dizzyTag = "Dizzy";

	void Start () {
		anim = GetComponent<Animator>();
		agent = wizard.GetComponent<UnityEngine.AI.NavMeshAgent>();
	}
	
	void Update () {
		if (wizard.CompareTag(dizzyTag)){
			anim.SetBool(dizzyHash, true);
		} else {
			anim.SetBool(dizzyHash, false);
		}
		float xVelocity = agent.velocity.x;
		if(xVelocity == 0f){
			anim.SetBool(idleHash, true);
		} else {
			anim.SetBool(idleHash, false);
		}
		anim.SetFloat(xVelocityHash,xVelocity);
	}
}
