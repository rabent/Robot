using UnityEngine;
using DG.Tweening;
using System;

[Serializable]
public class ZRobot : MonoBehaviour, IRobot
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public float pivot {get; set;}
    Sequence sequence;
    float target;
    private void Awake() {
        pivot=transform.localEulerAngles.z;
        target=(pivot+180)%360;
    }

    public void rotatep() {
        if(transform.localEulerAngles.z==target) {
            transform.Rotate(new Vector3(0,0,0.01f));
        }
        Vector3 targetp=new Vector3(0,0,(target-transform.localEulerAngles.z+360)%360-0.01f);
        sequence=DOTween.Sequence();
        sequence.Append(
        transform.DOLocalRotate(targetp,4f,RotateMode.LocalAxisAdd).SetEase(Ease.InQuart)
         //.onComplete();
        );
       
    }
    public void rotatem() {
        if(transform.localEulerAngles.z==target) {
            transform.Rotate(new Vector3(0,0,-0.01f));
        }
        Vector3 targetm=new Vector3(0,0,-(transform.localEulerAngles.z-target+360)%360+0.01f);
        sequence=DOTween.Sequence();
        sequence.Append(
        transform.DOLocalRotate(targetm,4f,RotateMode.LocalAxisAdd).SetEase(Ease.InQuart)
        //.onComplete();
        );
    }

    public void oncomplete() {

    }

    public void killTween() {
        sequence.Kill();
    }

}
