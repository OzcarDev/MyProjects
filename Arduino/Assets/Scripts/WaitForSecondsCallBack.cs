using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WaitForSecondsCallBack : CustomYieldInstruction
{

    private float time;
    private Action callBack;
    private float actualTime;
    public override bool keepWaiting{ get
        {
            callBack?.Invoke();
            actualTime += Time.deltaTime;
            return actualTime < time;
        }
    }

    public WaitForSecondsCallBack(float time, Action callBack) {

        this.time = time;
        this.callBack = callBack;

    
    }
}
