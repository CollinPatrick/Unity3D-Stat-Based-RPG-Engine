using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// MOSTLY PSUDO AND NOT IMPLIMENTED
/// </summary>
public class LevelManager : MonoBehaviour
{
    //Popup : marker enable method plays oneshot animation
    //popup : disable method clears all changes
    //Popup : Make public method to reset all changes between consecutive levels

    //public LevelPopup popup;

    private bool running = false;

    private static LevelManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        GameSystem.levelManager = instance;
    }

    private Queue<LevelUpDataSheet> levelQueue = new Queue<LevelUpDataSheet>();

    public void AddToQueue(LevelUpDataSheet s)
    {
        levelQueue.Enqueue(s);
    }

    private void Update()
    {
        if(!running)
        {
            if(levelQueue.Count > 0)
            {
                running = false;
                StartCoroutine(RunQueue(levelQueue.Dequeue()));
            }
        }
    }

    private IEnumerator RunQueue(LevelUpDataSheet s)
    {
        //Sets all old values. Represented with number and bar.
        for (int i = 0; i < s.curStats.Count; i++)
        {
            //popup.values[i].value = s.oldStats[i];
        }

        //popup.gameObject.setActive(true);

        //Displays new stats in 0.5s interval
        for (int i = 0; i < s.curStats.Count; i++)
        {
            if (s.curStats[i] > s.oldStats[i])
            {
                //popup.values[i].value = s.curStats[i];
                //popup.values[i].indicator.gameObject.setactive(true);
                yield return new WaitForSecondsRealtime(0.5f);
            }
        }

        while(!Input.anyKeyDown)
        {
            yield return null;
        }

        if(levelQueue.Count > 0)
        {
            StartCoroutine(RunQueue(levelQueue.Dequeue()));
        }
        else
        {
            //popup.gameObject.setActive(false);
            running = false;
        }
        
    }
}
