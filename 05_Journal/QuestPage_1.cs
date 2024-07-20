using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPage_1 : MonoBehaviour
{
    public GameObject p1;                 //to SHOW a hint 
    public GameObject p1_doneImage;       //to activate the DONE tick image when its done
    //public bool p1_done;                  //bool flag to set true when its done

    public GameObject p2;
    public GameObject p2_doneImage;
    //public bool p2_done;

    public GameObject p3;
    public GameObject p3_doneImage;
    //public bool p3_done;

    public GameObject p4;
    public GameObject p4_doneImage;
    //public bool p4_done;

    public GameObject p5;
    public GameObject p5_doneImage;
    //public bool p5_done;

    public GameObject p6;
    public GameObject p6_doneImage;
    //public bool p6_done;

    public static QuestPage_1 Instance;


    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowTheHint(GameObject hint)
    {
        hint.gameObject.SetActive(true);
    }
    public void FinishedTask(GameObject doneImage)
    {
        //doneFlag = true;
        doneImage.gameObject.SetActive(true);
    }
}
