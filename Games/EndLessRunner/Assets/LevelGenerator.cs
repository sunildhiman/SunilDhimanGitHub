using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_FROM_ENDPOINT = 20f;
    //GameLevelPart1
    [SerializeField] private Transform levelPart01,levelMaster,levelFinal;
    [SerializeField] private Rigidbody2D gameplayer;
    private Vector3 EndPoint = new Vector3(25, 2);
    public Vector3 Difference = new Vector3(10,5);
    int levelCount = 0;
    public int MaxNoOfLevels;
    bool AddFinallevel = false;
    // Start is called before the first frame update
    void Start()
    {
        gameplayer = Rigidbody2D.FindObjectOfType<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(gameplayer.position, EndPoint) < PLAYER_DISTANCE_FROM_ENDPOINT)
        {
            AddNextLevel();
        }
    }
    private void AddNextLevel()
    {
        try
        {
            Transform LevelPartTransform;
            if (levelCount<MaxNoOfLevels)
            {
                LevelPartTransform = Instantiate(levelPart01, EndPoint + Difference, Quaternion.identity);
                levelCount++;
            }
            else if(AddFinallevel)
            {
                LevelPartTransform = Instantiate(levelFinal, EndPoint + new Vector3(10, -5), Quaternion.identity);
            }
            else 
            {
                LevelPartTransform = Instantiate(levelMaster, EndPoint + Difference, Quaternion.identity);
                AddFinallevel = true;
            }

            EndPoint = LevelPartTransform.Find("Endpoint").position;

            //Debug.Log(" found the end point for the level");
        }
        catch (Exception ex)
        {
            //Debug.Log(" In AddNextLevel. Exception :" + ex.InnerException); 
        }
    }
}
