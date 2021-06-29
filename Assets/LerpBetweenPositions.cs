using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EndOfCycleOptions
{
    RESTART,
    STOP,
    CONNECT_ENDS
}

public class LerpBetweenPositions : MonoBehaviour
{
    [SerializeField] EndOfCycleOptions atEndOfCycle = EndOfCycleOptions.RESTART;
    [SerializeField] float timePerSegment = 10;
    [SerializeField] float timeIntoSegment = 5;

    [SerializeField] List<Vector3> positionList;

    [SerializeField] int index;
    [SerializeField] int next;

    // Start is called before the first frame update
    void Start()
    {
        positionList = new List<Vector3>();
        for(int i = 0; i < transform.childCount;i++)
        {
            positionList.Add(transform.GetChild(i).position);
        }

        index = 0;
        next = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timeIntoSegment += Time.deltaTime;
        if(timeIntoSegment > timePerSegment)
        {
            index = next;
            next++;

            if(next == positionList.Count)
            {
                if (atEndOfCycle == EndOfCycleOptions.CONNECT_ENDS)
                { 
                    next = 0;
                }
                else if (atEndOfCycle == EndOfCycleOptions.RESTART)
                {
                    index = 0;
                    next = 1;
                }
                else if (atEndOfCycle == EndOfCycleOptions.STOP)
                {
                    transform.position = positionList[index];
                    Destroy(this);
                }
            }

            timeIntoSegment -= timePerSegment;
        }
        float param = timeIntoSegment / timePerSegment;
        transform.position = Vector3.Lerp(positionList[index], positionList[next], param);
    }
}
