using UnityEngine;
using DG.Tweening;
using System;

[Serializable]
public class YRobot : MonoBehaviour,IRobot
{
    public int idx {get; set;}
    public float pivot {get; set;}
    public int degree {get; set;}
    Sequence sequence;
    UIController ui;
    float target;
    private void Awake() {
        pivot=transform.localEulerAngles.y;
        target=(pivot+180)%360;
        ui=UIController.instance;
    }

    void Update()
    {
        float org=transform.localEulerAngles.y-pivot;
        degree=(int) Math.Round(org);
        if(org>180) degree-=360;
        if(org<-180) degree+=360;
    }

    public void rotatep() {
        Vector3 targetp=new Vector3(0,(target-transform.localEulerAngles.y+360)%360-0.01f,0);
        sequence=DOTween.Sequence();
        sequence.InsertCallback(0.3f,insertCallbackp);
        sequence.Append(
        transform.DOLocalRotate(targetp,4f,RotateMode.LocalAxisAdd).SetEase(Ease.InQuart)
        .OnComplete(oncompletep)
        );
       
    }
    public void rotatem() {
        Vector3 targetm=new Vector3(0,-(transform.localEulerAngles.y-target+360)%360+0.01f,0);
        sequence=DOTween.Sequence();
        sequence.InsertCallback(0.3f,insertCallbackm);
        sequence.Append(
        transform.DOLocalRotate(targetm,4f,RotateMode.LocalAxisAdd).SetEase(Ease.InQuart)
        .OnComplete(oncompletem)
        );
    }

    void insertCallbackp() {
        ui.activem(idx);
    }

    void insertCallbackm() {
        ui.activep(idx);
    }

    public void oncompletep() {
        ui.inactivep(idx);
    }

    public void oncompletem() {
        ui.inactivem(idx);
    }

    public void killTween() {
        sequence.Kill();
    }
}
