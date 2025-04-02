using System;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    public static UIController instance=null;
    UIDocument ui;
    RobotController robotController;
    public Button[,] buttons=new Button[6,2];
    public Label[] values=new Label[6];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake() {
        if(instance==null) instance=this;
        ui=GetComponent<UIDocument>();
        robotController=RobotController.instance;
        ButtonInit();
        values[0]=ui.rootVisualElement.Q<Label>("J1Value");
        values[1]=ui.rootVisualElement.Q<Label>("J2Value");
        values[2]=ui.rootVisualElement.Q<Label>("J3Value");
        values[3]=ui.rootVisualElement.Q<Label>("J4Value");
        values[4]=ui.rootVisualElement.Q<Label>("J5Value");
        values[5]=ui.rootVisualElement.Q<Label>("J6Value");
    }

    void ButtonInit() {
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

    void Update() {
        for(int i=0; i<6; i++) {
            values[i].text=robotController.Robots[i].degree.ToString();
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

    public void activep(int idx) {
        buttons[idx,0].SetEnabled(true);
    }

    public void activem(int idx) {
        buttons[idx,1].SetEnabled(true);
    }

    public void inactivep(int idx) {
        buttons[idx,0].SetEnabled(false);
    }

    public void inactivem(int idx) {
        buttons[idx,1].SetEnabled(false);
    }
}
