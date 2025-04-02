using System;
using UnityEngine;

public interface IRobot {
    int idx {get; set;}
    float pivot {get; set;}
    int degree {get; set;}
    void rotatep();
    void rotatem();

    void killTween();
}



