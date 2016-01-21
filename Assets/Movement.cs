using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class Movement : MonoBehaviour {
    [HideInInspector]
    public Animator anim;
    protected Rigidbody rig;
    public bool isWalking;
    public bool isSlash = false;
    public float SensitivityHor = 9.0f;
    protected float Input_x;
    protected float Input_z;
    protected float movef;
    //Camera
    GameObject Camera;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
        Camera = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Turn();
        move();
        Attack();
	}
    protected virtual void move()
    {
        //anim.SetFloat("MoveX", Input.GetAxis("MoveX"));
        //anim.SetFloat("MoveZ", Input.GetAxis("MoveZ"));
        anim.SetFloat("MoveX", movef);
    }
    protected virtual void Attack()
    {
        bool isSlash = CrossPlatformInputManager.GetButtonUp("Attack");
        //Debug.Log(" isSlash ===>" + isSlash);
        if (isSlash)
        {
            anim.SetTrigger("Slash");
        }
    }

    protected virtual void Turn()
    {
        //攻击锁定方向
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            return;

        if (Input_x != 0 || Input_z != 0 )
        {
            Vector3 targetDir = new Vector3(Input_x, 0, Input_z);
            Vector3 Local = new Vector3(1, 0, 0);
            float angle = Vector3.Angle(Local, targetDir) ;
            if ((Mathf.Sign(Input_z) == -1))
               angle =  360f - angle;
            //考虑到锁定模式，需要加上摄像机修正
            transform.localEulerAngles = new Vector3(0, angle, 0) + new Vector3(0,Camera.transform.localEulerAngles.y,0)  ;
        }
    }

    public virtual void MoveControl(Vector3 MoveDir)
    {
        Input_x = MoveDir.x;
        Input_z = MoveDir.z;
        Set_movef();
    }

    public virtual void MoveControl(float Speed)
    {
        Input_x = Speed;
        Input_z = Speed;
        Set_movef();
    }

    protected  virtual void Set_movef()
    {
        movef = Mathf.Max(Mathf.Abs(Input_x), Mathf.Abs(Input_z));
    }
    public void Set_movef(float speed)
    {
        movef = Mathf.Clamp(speed, 0, 1f);
    }
}

