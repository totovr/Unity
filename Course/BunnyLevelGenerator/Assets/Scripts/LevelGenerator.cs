using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    /*
     * Public variables to generate the levels
     */

    public static LevelGenerator sharedInstance;

    public List<LevelBlock> allTheLevelBlocks = new List<LevelBlock>(); // List that contain all the levels
    public List<LevelBlock> currentLevelBlocks = new List<LevelBlock>(); // List of the blocks that are currently displaying
    public Transform levelInitialPoint; // Initial point where the first level will be created 

    void Awake()
    {
        sharedInstance = this;
    }

	// Use this for initialization
	void Start () {
        GenerateInitialBlocks(); // Generate the initial blocks 
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // Generate the initial blocks two times
    public void GenerateInitialBlocks()
    {
        for (int i = 0; i < 3; i++)
        {
            AddNewBlock();
        }
    }

    public void AddNewBlock()
    {
        // Select a random block of the ones that are available
        int randomIndex = Random.Range(0, allTheLevelBlocks.Count);

        LevelBlock block = (LevelBlock)Instantiate(allTheLevelBlocks[randomIndex]); // Generate a copy of the block that we have
        block.transform.SetParent(this.transform, false);

        // Position of the block 
        Vector3 blockPosition = Vector3.zero;

        // Assign the position of the block 
        if(currentLevelBlocks.Count == 0)
        {
            // This means that we are going to create the first block 
            blockPosition = levelInitialPoint.position;
        }
        else
        {
            // Access to the last block that was displayed
            blockPosition = currentLevelBlocks[currentLevelBlocks.Count - 1].exitPoint.position;
        }

        block.transform.position = blockPosition;
        // Add the block that we generate and add it to the levelBlocks
        currentLevelBlocks.Add(block);
    }

    public void RemoveOldBlock()
    {
        // Save the old block in a new object 
        LevelBlock block = currentLevelBlocks[0];
        // Remove the block from the list
        currentLevelBlocks.Remove(block);
        Destroy(block.gameObject);
    }

}
