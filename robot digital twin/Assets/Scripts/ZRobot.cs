using UnityEngine;
using DG.Tweening;

public class ZRobot : MonoBehaviour, IRobot
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public float pivot {get; set;}
    void Start()
    {
        pivot=270;
        Vector3 targetp=new Vector3(0,0,pivot+180);
        Vector3 targetm=new Vector3(0,0,pivot-180);
    }

    public void rotatep() {
        this.tramsform.DoRotate(targetp,4f);
        
    }
    public void rotatem() {

    }

}
