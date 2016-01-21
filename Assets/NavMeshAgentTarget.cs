using UnityEngine;
using System.Collections;

public class NavMeshAgentTarget : MonoBehaviour {

    public Transform Target;
    Movement Movement;
    MovementRootMotion MovemnetRM;
    NavMeshAgent nav;
	// Use this for initialization
	void Start () {
	    nav = GetComponent<NavMeshAgent>();
        Movement = GetComponent<Movement>() ;
        MovemnetRM = GetComponent<MovementRootMotion>() ;

	}
	
	// Update is called once per frame
    void FixedUpdate()
    {
        nav.SetDestination(Target.position);
        MovemnetRM.Set_movef(nav.speed);
	}
}
