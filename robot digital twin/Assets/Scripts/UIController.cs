using System;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    UIDocument ui;
    RobotController robotController=RobotController.getInstance();
    int cur;
    public Button[,] buttons=new Button[6,2];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake() {
        ui=GetComponent<UIDocument>();
        VisualElement grid=ui.rootVisualElement.Q<VisualElement>("ButtonView");
        for(int i=0; i<12; i++) {
            Button button=new Button();
            button.style.width=200;
            button.style.height=40;
            button.style.marginBottom = 5;
            button.style.marginRight = 5;
            if(i%2==0) {
                String s="J" + (i/2)+1 + "+";
                button.text=s; cur=i/2;
                button.RegisterCallback<PointerDownEvent>(rotatep);
                button.RegisterCallback<PointerUpEvent>(rotateKill);
                buttons[i/2,0]=button;
            } else {
                String s="J" + (i/2)+1 + "-";
                button.text=s; cur=i/2;
                button.RegisterCallback<PointerDownEvent>(rotatem);
                button.RegisterCallback<PointerUpEvent>(rotateKill);
                buttons[i/2,1]=button;
            }
            
            grid.Add(button);
        }
    }
    
    void rotatep(PointerDownEvent evt) {
        robotController.rotatep(cur);
    }

    void rotatem(PointerDownEvent evt) {
        robotController.rotatem(cur);
    }
    
    void rotateKill(PointerUpEvent evt) {
        robotController.killRotate(cur);
    }
}
