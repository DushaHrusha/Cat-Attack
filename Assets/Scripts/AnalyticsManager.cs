using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class AnalyticsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameAnalytics.Initialize();

        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "Monde 1", "Niveau 1", "Checkpoint 2", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}