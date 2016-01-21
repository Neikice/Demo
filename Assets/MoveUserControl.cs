using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
public class MoveUserControl : MonoBehaviour {
    Movement _Movement;
	void Start () {
        _Movement = GetComponent<Movement>();
	}
	
	// Update is called once per frame
    void FixedUpdate()
    {
        _Movement.MoveControl(new Vector3(CrossPlatformInputManager.GetAxis("MoveX"), 0, CrossPlatformInputManager.GetAxis("MoveZ")));
	}
}
