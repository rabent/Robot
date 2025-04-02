using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{   
    public static RobotController instance=null;
    public List<IRobot> Robots=new List<IRobot>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {   
        if(instance==null) instance=this;
        Transform[] joints = GetComponentsInChildren<Transform>();
        int count=0;
        foreach(Transform joint in joints) 
        {   
            if(joint.name == "joint") {
                Robots.Add(joint.GetComponent<IRobot>());
                Robots[count].idx=count; count++;
            }
        }  
    }

    public void rotatem(int idx) {
        Robots[idx].rotatem();
    }

    public void rotatep(int idx) {
        Robots[idx].rotatep();
    }

    public void killRotate(int idx) {
        Robots[idx].killTween();
    }
}
