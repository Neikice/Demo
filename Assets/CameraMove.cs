using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
    public bool Lock = false;
    public float speed = 2f;
    public float LockHeight = 1.3f;
    public float FlowY = 2.3f;
    public float FlowZ = -4.4f;
    public GameObject Target;
    GameObject Player_Go;
    // Use this for initialization
    void Start()
    {
        Player_Go = GameObject.Find("Player");
    }

    public void LockCamera()
    {
        Lock = !Lock;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float step = speed * Time.fixedDeltaTime;
        if (Lock)
        {
            //先判断Player和对象的方向
            Vector3 targetDir = new Vector3(Player_Go.transform.position.x, 0, Player_Go.transform.position.z) - new Vector3(Target.transform.position.x, 0, Target.transform.position.z);
            //延长向量
            targetDir = targetDir + targetDir.normalized * 2.5f;
            transform.position =  Vector3.MoveTowards( transform.position , Target.transform.position + targetDir + new Vector3(0, LockHeight) , step);
            //Debug.DrawRay(Target.transform.position, targetDir, Color.red);
            //锁定目标            
            transform.LookAt(new Vector3(Player_Go.transform.position.x, transform.position.y, Player_Go.transform.position.z));
            return;
        }
        
        Vector3 FollowPonit = Player_Go.transform.position + new Vector3(0, FlowY, FlowZ);
        transform.position = Vector3.MoveTowards(transform.position, FollowPonit, step);
        transform.LookAt(new Vector3(Player_Go.transform.position.x,transform.position.y,Player_Go.transform.position.z));
    }
}
