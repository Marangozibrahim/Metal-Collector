using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stash : MonoBehaviour
{
    public Transform stashParent;
    public List<Stashable> CollectedObjects = new List<Stashable>();
    public int CollectedCount => CollectedObjects.Count;
    public float collectionHeight = 1;
    public int maxCollectableCount = 5;
    public Transform MainPlayer;
    public Transform Car;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Car.parent == MainPlayer)
        {
            maxCollectableCount = 10;
        }
        else
        {
            maxCollectableCount = 5;
        }
    }

    public void AddStash(Collectable collectedObject)
    {
        if (CollectedCount >= maxCollectableCount)
            return;

        var yLocalPosition = CollectedCount * collectionHeight;

        var stashable = collectedObject.Collect(); 
        stashable.CollectStashable(stashParent, yLocalPosition, CompleteCollection);
        CollectedObjects.Add(stashable);
         
    }

    private void CompleteCollection()
    {


    }

    public Stashable RemoveStash()
    {
        if (CollectedCount <= 0)
            return null;

        var stashable = CollectedObjects[CollectedCount - 1];

        CollectedObjects.Remove(stashable);
        stashable.transform.parent = null;

        return stashable;

    }
}
