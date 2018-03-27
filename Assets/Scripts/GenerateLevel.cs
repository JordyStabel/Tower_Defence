using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateLevel : MonoBehaviour {

    public GameObject node;

    public Transform spawnPoint;
    public Vector3 startPosition = new Vector3(1, 0, 1);

    public GameManager gameManager;

    public Button button;

    void Start()
    {
        Button testButton = button.GetComponent<Button>();
        testButton.onClick.AddListener(generateLevel);
    }

    public void generateLevel()
    {
        int width = 15;
        int height = 15;

        List<GameObject> newGrid = new List<GameObject>();


        for (int i = 0; i < width; i++)
        {
            for (int x = 0; x < height; x++)
            {
                newGrid.Add((GameObject)Instantiate(node, new Vector3(25 + (i * 5.0F), 0, 25 + (x * 5.0F)), Quaternion.identity));
            }
        }

        Destroy(newGrid[5]);
        
        //foreach (Node tile in newGrid)
        //{
        //    node = GameObject.FindGameObjectWithTag("testNode").GetComponent<Node>();
        //    Destroy(node);
        //    //Debug.Log(newGrid.IndexOf(tile));
        //    Debug.Log(node);
        //}

        //for (int i = 0; i < width; i++)
        //{
        //    for (int x = 0; x < height; x++)
        //    {
        //        Instantiate(node, new Vector3(25 + (i * 5.0F), 0, 25 + (x * 5.0F)), Quaternion.identity);
        //        if (i == 0 || x == 0) node.name = "Start";
        //    }
        //}

        //Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}