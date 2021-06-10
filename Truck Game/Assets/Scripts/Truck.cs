using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
    LogitechGSDK.LogiControllerPropertiesData properties;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("SteeringInit:" + LogitechGSDK.LogiSteeringInitialize(false));
    }

    void Awake() 
    {
        //Setting example values
        properties.wheelRange = 90;
        properties.forceEnable = true;
        properties.overallGain = 80;
        properties.springGain = 80;
        properties.damperGain = 80;
        properties.allowGameSettings = true;
        properties.combinePedals = false;
        properties.defaultSpringEnabled = true;
        properties.defaultSpringGain = 80;
        LogitechGSDK.LogiSetPreferredControllerProperties(properties);
    }

    // Update is called once per frame
    void Update()
    {
        if (LogitechGSDK.LogiUpdate() && LogitechGSDK.LogiIsConnected(0))
        {
            LogitechGSDK.DIJOYSTATE2ENGINES rec;
            rec = LogitechGSDK.LogiGetStateUnity(0);

            //lX is steering force, will not change anything with it for now
            Debug.Log("x-axis position :" + rec.lX + "\n");
            //lY is gas pedal, needs to be mapped, 32767 - ~-32767 to 0 - ???
            Debug.Log("y-axis position :" + rec.lY + "\n");
        }
    }

    void OnApplicationQuit()
    {
        Debug.Log("SteeringShutdown:" + LogitechGSDK.LogiSteeringShutdown());
    }
}
