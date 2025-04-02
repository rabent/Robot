using System;
using UnityEngine;

public interface IRobot {
    float pivot {get; set;}
    void rotatep();
    void rotatem();

    void killTween();
}



