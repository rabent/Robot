using UnityEngine;
using DG.Tweening;

public class ZRobot : MonoBehaviour, IRobot
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public float pivot {get; set;}
    void Start()
    {
        pivot=270;
    }

    public void rotatep() {
        Vector3 targetp=new Vector3(0,0,pivot+180);
        this.transform.DORotate(targetp,4f).SetEase(Ease.InQuart)
        .onComplete();
    }
    public void rotatem() {
        Vector3 targetm=new Vector3(0,0,pivot-180);
        this.transform.DORotate(targetm,4f).SetEase(Ease.InQuart)
        .onComplete();
    }

    public void killTween() {
        DOTween.Kill(this);
    }

}
