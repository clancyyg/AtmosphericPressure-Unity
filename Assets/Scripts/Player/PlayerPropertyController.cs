using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPropertyController
{
    // Initial Parameters
    private float                           HPInitialValue;
    private float                           HPDecreaseUpdateInterval;
    private float                           HPDecreaseOverTimeExtent;
    private float                           HPDecreaseWhenJettingExtent;
    private float                           HPYellowToRedCriticalPoint;
    private float                           HPGreenToYellowCriticalPoint;

    // Player Components
    private Transform                       HPDisplayBar;
    private Transform                       HPDisplayHandler;
    private PlayerComponentManager          componentManager;

    // Procedural Parameters
    private float                           HPValue;
    private float                           TimeCounter = 0;
    private float                           HPHandlerHeight;

    public PlayerPropertyController
    (
        float                               HPInitialValue,
        float                               HPDecreaseUpdateInterval,
        float                               HPDecreaseOverTimeExtent,
        float                               HPDecreaseWhenJettingExtent,
        float                               HPYellowToRedCriticalPoint,
        float                               HPGreenToYellowCriticalPoint,

        Transform                           HPDisplayBar,
        Transform                           HPDisplayHandler,
        PlayerComponentManager              componentManager
    )
    {
        this.HPInitialValue                 = HPInitialValue;
        this.HPDecreaseUpdateInterval       = HPDecreaseUpdateInterval;
        this.HPDecreaseOverTimeExtent       = HPDecreaseOverTimeExtent;
        this.HPDecreaseWhenJettingExtent    = HPDecreaseWhenJettingExtent;
        this.HPYellowToRedCriticalPoint     = HPYellowToRedCriticalPoint;
        this.HPGreenToYellowCriticalPoint   = HPGreenToYellowCriticalPoint;

        this.HPDisplayBar                   = HPDisplayBar;
        this.HPDisplayHandler               = HPDisplayHandler;
        this.componentManager               = componentManager;

        HPValue                             = HPInitialValue;
    }
    private void Init()
    {
        HPHandlerHeight = HPDisplayHandler.GetComponent<SpriteRenderer>().bounds.size.y;
    }
    public void Update()
    {
        Init();
        DecreaseHp();
        DisplayValueOnHPBar();
    }
    private void DecreaseHp()
    {
        if (HPValue <= 0) return;
        if (TimeCounter < HPDecreaseUpdateInterval)
        {
            TimeCounter += Time.deltaTime;
        }
        else
        {
            TimeCounter = 0;
            if (componentManager.GetJetting())
                HPValue -= HPDecreaseWhenJettingExtent;
            else HPValue -= HPDecreaseOverTimeExtent;
        }
    }
    private void DisplayValueOnHPBar()
    {
        if (HPValue <= 0) return;

        // Display Length
        HPDisplayBar.localScale = new Vector3(1, HPValue/HPInitialValue, 1);
        HPDisplayBar.position = new Vector3
        (
            HPDisplayHandler.position.x,
            HPDisplayHandler.position.y - (1-HPValue/HPInitialValue) * HPHandlerHeight / 2,
            HPDisplayHandler.position.z
        );

        // Display Color
        if (HPValue < HPYellowToRedCriticalPoint)
            HPDisplayBar.GetComponent<SpriteRenderer>().color = Color.red;
        else if (HPValue < HPGreenToYellowCriticalPoint)
            HPDisplayBar.GetComponent<SpriteRenderer>().color = Color.yellow;
        else HPDisplayBar.GetComponent<SpriteRenderer>().color = Color.green;
    }
    public void RestoreHP(float value)
    {
        HPValue = HPValue + value;
        if (HPValue > HPInitialValue) HPValue = HPInitialValue;
    }
}
