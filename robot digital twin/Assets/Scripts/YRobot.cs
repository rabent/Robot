using UnityEngine;
using DG.Tweening;

public class YRobot : MonoBehaviour,IRobot
{
    public float pivot {get; set;}
    void Start()
    {
        pivot=0;
    }

    public void rotatep() {
        Vector3 targetp=new Vector3(0,pivot+180,0);
        this.transform.DORotate(targetp,4f).SetEase(Ease.InQuart)
        .onComplete();
    }
    public void rotatem() {
        Vector3 targetm=new Vector3(0,pivot-180,0);
        this.transform.DORotate(targetm,4f).SetEase(Ease.InQuart)
        .onComplete();
    }

    public void killTween() {
        DOTween.Kill(this);
    }
}
