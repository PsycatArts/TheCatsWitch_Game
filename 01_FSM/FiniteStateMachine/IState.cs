using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState 
{
    void Enter();           //enter state
    void Execute();         //update
    void Exit();            //exit state
}
