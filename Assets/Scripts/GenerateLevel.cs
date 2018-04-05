using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateLevel : MonoBehaviour
{

    public GameObject node;
    public GameObject road;
    public GameObject wayPoint;
    public GameObject start;
    public GameObject end;

    public Transform spawnPoint;
    public Vector3 startPosition = new Vector3(1, 0, 1);

    public GameManager gameManager;

    public Button button;

    void Start()
    {
        Button testButton = button.GetComponent<Button>();
        testButton.onClick.AddListener(generateLevel);
        generateLevel();
    }

    public void generateLevel()
    {
        int width = 10 ;
        int height = 10;

        List<GameObject> newGrid = new List<GameObject>();

        Instantiate(start, new Vector3(25, 0, 25), Quaternion.identity);
        Instantiate(end, new Vector3(70, 0, 70), Quaternion.identity);

        for (int i = 0; i < width; i++)
        {
            for (int x = 0; x < height; x++)
            {
                node.name = i.ToString() + x.ToString();
                newGrid.Add((GameObject)Instantiate(node, new Vector3(25 + (i * 5.0F), 0, 25 + (x * 5.0F)), Quaternion.identity));
                Debug.Log(node.transform.position);
            }
        }

        List<int> path = new List<int>();

        path.Add(25);
        path.Add(37);
        path.Add(58);
        path.Add(66);
        path.Add(82);
        path.Add(99);

        int startNodeIndex = 0;

        //for (int i = 0; i < 5; i++)
        //{
        //    path.Add(Random.Range(0, 99)); //change back to 99
        //}

        //path.Sort();

        foreach (int deleteNode in path)
        {
            int deleteNodeIdentifier = 0;
            int endPoint = 0;

            if (deleteNode > 9)
            {
                deleteNodeIdentifier = int.Parse(deleteNode.ToString().Substring((deleteNode.ToString().Length - 1)));
                Debug.Log(deleteNodeIdentifier);
            }
            else
            {
                deleteNodeIdentifier = deleteNode;
            }
            int startNodeIdentifier = int.Parse(startNodeIndex.ToString().Substring((startNodeIndex.ToString().Length - 1)));
            Debug.Log(startNodeIdentifier);

            //Make a endpoint with the same ender number as the deleteNode end number
            //e.g. 25 to 37 needs 27 as endpoint
            string endPointString = startNodeIndex.ToString().Remove(startNodeIndex.ToString().Length - 1) + deleteNodeIdentifier.ToString();
            endPoint = int.Parse(endPointString);
            Debug.Log("Endpoint: " + endPoint);

            //If the last number of startNodeIndex is less than the deleteNode itself is less than 9 
            if (deleteNodeIdentifier > startNodeIdentifier)
            {
                //End should be deleteNodeIdentifier
                startNodeIdentifier = deleteLeftToRight(startNodeIndex, endPoint, newGrid);
                startNodeIdentifier = int.Parse(startNodeIdentifier.ToString().Substring((startNodeIdentifier.ToString().Length - 1)));
                Debug.Log(startNodeIdentifier);
            }

            //If the last number of startNodeIndex is more than the last number of the deleteNodeIndex
            if (deleteNodeIdentifier < startNodeIdentifier)
            {
                startNodeIdentifier = deleteRightToLeft(startNodeIndex, endPoint, newGrid);
                startNodeIdentifier = int.Parse(startNodeIdentifier.ToString().Substring((startNodeIdentifier.ToString().Length - 1)));
                Debug.Log("Right to left");
                Debug.Log("endPoint: " + endPoint + " = " + "startNodeIndex: " + startNodeIndex);
            }

            //If the last number of startNodeIndex is equal to the last number of the deleteNodeIndex
            if (deleteNodeIdentifier - 1 == startNodeIdentifier || deleteNodeIdentifier + 1 == startNodeIdentifier)
            {
                deleteTopToBottom(endPoint, deleteNode, newGrid);
                Debug.Log("Top to bottom");
            }
            startNodeIndex = deleteNode;

            Debug.Log(deleteNode + "  =  " + startNodeIndex);
            #region Test code

            //if (startNodeIndex >= 0)
            //{
            //    int identifier = int.Parse(deleteNode.ToString().Substring(1));

            //    if (deleteNode <= 9)
            //    {
            //        for (int i = startNodeIndex; i < deleteNode; i++)
            //        {
            //            //Destroy(newGrid[i]);
            //            newGrid[i].GetComponent<Renderer>().material.color = Color.black;
            //        }
            //    }

            //    if (deleteNode > 9)
            //    {
            //        int goTill = int.Parse(deleteNode.ToString().Substring(1));

            //        //for (int i = delelteNode; i > 0; i -= 10)
            //        //{
            //        //    goTill = i;
            //        //    Debug.Log(i);
            //        //}

            //        for (int i = startNodeIndex; i < goTill; i++) //Not minus 10 but minus 10 * x so it's less than 9
            //        {
            //            //Destroy(newGrid[i]);
            //            newGrid[i].GetComponent<Renderer>().material.color = Color.black;
            //        }

            //        startNodeIndex = goTill + 9;

            //        for (int i = startNodeIndex; i <= deleteNode; i += 10)
            //        {
            //            //Destroy(newGrid[i]);
            //            newGrid[i].GetComponent<Renderer>().material.color = Color.red;
            //        }
            //    }
            //    startNodeIndex = deleteNode;
            //}
            //else
            //{
            //    int temp = int.Parse(deleteNode.ToString().Substring(1));

            //    //Starting positon is more than the end point minus X * 10, so it need to change in direction
            //    //e.g. from 15 to 32 it needs to go backwards
            //    if (startNodeIndex > temp)
            //    {
            //        //if (deleteNode <= 9)
            //        //{
            //        //    for (int i = startNodeIndex; i < delelteNode; i++)
            //        //    {
            //        //        //Destroy(newGrid[i]);
            //        //        newGrid[i].GetComponent<Renderer>().material.color = Color.black;
            //        //    }
            //        //}

            //        if (deleteNode >= 0)
            //        {
            //            int goTill = 0;

            //            for (int i = deleteNode; i > 0; i -= 10)
            //            {
            //                goTill = i;
            //                Debug.Log(i);
            //            }

            //            for (int i = startNodeIndex; i < goTill; i++) //Not minus 10 but minus 10 * x so it's less than 9
            //            {
            //                //Destroy(newGrid[i]);
            //                newGrid[i].GetComponent<Renderer>().material.color = Color.yellow;
            //            }

            //            startNodeIndex = temp + 9;
            //            Debug.Log(startNodeIndex + deleteNode);

            //            for (int i = startNodeIndex; i <= deleteNode; i--)
            //            {
            //                //Destroy(newGrid[i]);
            //                newGrid[i].GetComponent<Renderer>().material.color = Color.green;
            //            }
            //        }
            //        startNodeIndex = deleteNode;
            //    }

            //    //if (delelteNode <= 9)
            //    //{
            //    //    for (int i = startNodeIndex; i < delelteNode; i++)
            //    //    {
            //    //        //Destroy(newGrid[i]);
            //    //        newGrid[i].GetComponent<Renderer>().material.color = Color.black;
            //    //    }
            //    //}

            //    //if (delelteNode > 9)
            //    //{
            //    //    int goTill = 0;

            //    //    for (int i = delelteNode; i > 0; i -= 10)
            //    //    {
            //    //        goTill = i;
            //    //        Debug.Log(i);
            //    //    }

            //    //    for (int i = startNodeIndex; i < goTill; i++) //Not minus 10 but minus 10 * x so it's less than 9
            //    //    {
            //    //        //Destroy(newGrid[i]);
            //    //        newGrid[i].GetComponent<Renderer>().material.color = Color.black;
            //    //    }

            //    //    startNodeIndex = goTill + 9;

            //    //    for (int i = startNodeIndex; i <= delelteNode; i += 10)
            //    //    {
            //    //        //Destroy(newGrid[i]);
            //    //        newGrid[i].GetComponent<Renderer>().material.color = Color.red;
            //    //    }
            //    //}
            //    //startNodeIndex = delelteNode;
            //}

            ////        if (delelteNode <= 9)
            ////        {
            ////            for (int i = startNodeIndex; i < delelteNode; i++)
            ////            {
            ////                //Destroy(newGrid[i]);
            ////                newGrid[i].GetComponent<Renderer>().material.color = Color.black;
            ////            }
            ////        }

            ////        if (delelteNode > 9)
            ////        {
            ////            int goTill = 0;

            ////            for (int i = delelteNode; i > 0; i -= 10)
            ////            {
            ////                goTill = i;
            ////                Debug.Log(i);
            ////            }

            ////            for (int i = startNodeIndex; i < goTill; i++) //Not minus 10 but minus 10 * x so it's less than 9
            ////            {
            ////                //Destroy(newGrid[i]);
            ////                newGrid[i].GetComponent<Renderer>().material.color = Color.black;
            ////            }

            ////            startNodeIndex = goTill + 9;

            ////            for (int i = startNodeIndex; i <= delelteNode; i += 10)
            ////            {
            ////                //Destroy(newGrid[i]);
            ////                newGrid[i].GetComponent<Renderer>().material.color = Color.red;
            ////            }
            ////        }
            ////        startNodeIndex = delelteNode;
            ////    }

            ////    if (delelteNode <= 9)
            ////    {
            ////        for (int i = startNodeIndex; i < delelteNode; i++)
            ////        {
            ////            //Destroy(newGrid[i]);
            ////            newGrid[i].GetComponent<Renderer>().material.color = Color.black;
            ////        }
            ////    }

            ////    if (delelteNode > 9)
            ////    {
            ////        int goTill = 0;

            ////        for (int i = delelteNode; i > 0; i -= 10)
            ////        {
            ////            goTill = i;
            ////            Debug.Log(i);
            ////        }

            ////        for (int i = startNodeIndex; i < goTill; i++) //Not minus 10 but minus 10 * x so it's less than 9
            ////        {
            ////            //Destroy(newGrid[i]);
            ////            newGrid[i].GetComponent<Renderer>().material.color = Color.black;
            ////        }

            ////        startNodeIndex = goTill + 9;

            ////        for (int i = startNodeIndex; i <= delelteNode; i += 10)
            ////        {
            ////            //Destroy(newGrid[i]);
            ////            newGrid[i].GetComponent<Renderer>().material.color = Color.red;
            ////        }
            ////    }
            ////    startNodeIndex = delelteNode;
            ////}


            ////foreach (Node tile in newGrid)
            ////{
            ////    node = GameObject.FindGameObjectWithTag("testNode").GetComponent<Node>();
            ////    Destroy(node);
            ////    //Debug.Log(newGrid.IndexOf(tile));
            ////    Debug.Log(node);
            ////}

            ////for (int i = 0; i < width; i++)
            ////{
            ////    for (int x = 0; x < height; x++)
            ////    {
            ////        Instantiate(node, new Vector3(25 + (i * 5.0F), 0, 25 + (x * 5.0F)), Quaternion.identity);
            ////        if (i == 0 || x == 0) node.name = "Start";
            ////    }
            ////}

            ////Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
            #endregion
        }

        foreach (int point in path)
        {
            newGrid[point].GetComponent<Renderer>().material.color = Color.green;
        }
    }

    //Will recolor all tile from left to right within the range
    public int deleteLeftToRight(int start, int end, List<GameObject> nodes)
    {
        int _return = 0;
        for (int i = start; i < end; i++)
        {
            Instantiate(road, nodes[i].transform.position, Quaternion.identity);
            Instantiate(wayPoint, nodes[i].transform.position, Quaternion.identity);
            Destroy(nodes[i]);
            _return = i;
        }
        return _return;
    }

    //Will recolor all tile from right to left within the range
    public int deleteRightToLeft(int start, int end, List<GameObject> nodes)
    {
        Debug.Log("Start: " + start + " End: " + end);

        int _return = 0;
        for (int i = start; i > end; i--)
        {
            Instantiate(road, nodes[i].transform.position, Quaternion.identity);
            Destroy(nodes[i]);
            _return = i;
        }
        return _return;
    }

    //Will recolor all tile from top to bottom within the range
    public int deleteTopToBottom(int start, int end, List<GameObject> nodes)
    {
        int _return = 0;
        for (int i = start; i <= end; i += 10)
        {
            Instantiate(road, nodes[i].transform.position, Quaternion.identity);
            Destroy(nodes[i]);
            _return = i;
        }
        return _return;
    }
}