using System;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    UIDocument ui;
    RobotController robotController;
    public Button[,] buttons=new Button[6,2];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake() {
        ui=GetComponent<UIDocument>();
        robotController=RobotController.instance;
        VisualElement grid=ui.rootVisualElement.Q<VisualElement>("ButtonView");
        for(int i=0; i<12; i++) {
            Button button=new Button();
            button.style.width=200;
            button.style.height=40;
            button.style.marginBottom = 5;
            button.style.marginRight = 5;
            grid.Add(button);
            if(i%2==0) {
                String s="J" + ((i/2)+1) + "+";
                button.text=s;
                int a=i/2;
                button.RegisterCallback<PointerDownEvent>(evt => rotatep(evt,a),TrickleDown.TrickleDown);
                button.RegisterCallback<PointerUpEvent>(evt => rotateKill(evt,a));
                buttons[i/2,0]=button;
            } else {
                String s="J" + ((i/2)+1) + "-";
                button.text=s;
                int a=i/2;
                button.RegisterCallback<PointerDownEvent>(evt => rotatem(evt,a),TrickleDown.TrickleDown);
                button.RegisterCallback<PointerUpEvent>(evt => rotateKill(evt,a));
                buttons[i/2,1]=button;
            }
            
        }
    }
    
    void rotatep(PointerDownEvent evt, int idx) {
        Debug.Log(idx);
        if(robotController==null) Debug.Log("robot null");
        robotController.rotatep(idx);
    }

    void rotatem(PointerDownEvent evt, int idx) {
        robotController.rotatem(idx);
    }
    
    void rotateKill(PointerUpEvent evt, int idx) {
        robotController.killRotate(idx);
    }
}
