using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_StateMachine : MonoBehaviour
{
    private IState currentlyRunningState;
    private IState previousState;


    public void ChangeState(IState newState)            //method to call to change a state (takes in a IState var)
    {
        if (currentlyRunningState != null)              //error flag (if there's no current state, cant call exit, so say if there is a state..)
        {
            currentlyRunningState.Exit();               //call EXIT on the current state
        }
        previousState = currentlyRunningState;          //then set the current state to PREVIOUS state (make it the last used state)
        currentlyRunningState = newState;               //then set current state to the new parameter state (state we wanna enter)
        currentlyRunningState.Enter();                  //call enter on new state
    }

    public void ExecuteStateUpdate()                    //method call constantly on the currently running state
    {
        var runningState = currentlyRunningState;
        if (runningState != null)                       //if there IS a currently running state (if its not null)
        {
            currentlyRunningState.Execute();            //call update on current state
        }
    }


    public void SwitchToPreviousState()                 //method to call if you wanna go back to previous state
    {
        currentlyRunningState.Exit();                   //exit current state
        currentlyRunningState = previousState;          //set current state to previous (fetch the previous one and put it to current one)
        currentlyRunningState.Enter();                  //call enter on current (which is now the previous one)
    }
}
