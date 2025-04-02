using UnityEngine;
using DG.Tweening;
using System;

[Serializable]
public class YRobot : MonoBehaviour,IRobot
{
    public float pivot {get; set;}
    Sequence sequence;
    float target;
    private void Awake() {
        pivot=transform.localEulerAngles.z;
        target=(pivot+180)%360;
    }
    public void rotatep() {
        if(transform.localEulerAngles.z==target) {
            transform.Rotate(new Vector3(0,0.01f,0));
        }
        Vector3 targetp=new Vector3(0,(target-transform.localEulerAngles.y+360)%360-0.01f,0);
        sequence=DOTween.Sequence();
        sequence.Append(
        transform.DOLocalRotate(targetp,4f,RotateMode.LocalAxisAdd).SetEase(Ease.InQuart)
         //.onComplete();
        );
       
    }
    public void rotatem() {
        if(transform.localEulerAngles.z==target) {
            transform.Rotate(new Vector3(0,-0.01f,0));
        }
        Vector3 targetm=new Vector3(0,-(transform.localEulerAngles.y-target+360)%360+0.01f,0);
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
