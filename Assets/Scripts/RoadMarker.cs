using UnityEngine;

public class RoadMarker : MonoBehaviour {

    public int openingDirection;
    //1 --> need bottom road
    //2 --> need top road
    //3 --> need left road
    //4 --> need right road

    private RoadTemplates roadTemplates;
    private int random;
    private bool created = false;

    private void Start()
    {
        //Get the roadtemplate object form the hierarchy only during the start of this object
        roadTemplates = GameObject.FindGameObjectWithTag("Roads").GetComponent<RoadTemplates>();

        //Call the CreateRoad methode with 0.2 seconds delay
        Invoke("CreateRoad", 1f);
    }

    void CreateRoad()
    {
        if (created == false)
        {
            if (openingDirection == 1)
            {
                //Need to spawn road with BOTTOM opening
                random = Random.Range(0, roadTemplates.bottomRoads.Length);
                Instantiate(roadTemplates.bottomRoads[random], transform.position, roadTemplates.bottomRoads[random].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                //Need to spawn road with TOP opening
                random = Random.Range(0, roadTemplates.topRoads.Length);
                Instantiate(roadTemplates.topRoads[random], transform.position, roadTemplates.topRoads[random].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                //Need to spawn road with LEFT opening
                random = Random.Range(0, roadTemplates.leftRoads.Length);
                Instantiate(roadTemplates.leftRoads[random], transform.position, roadTemplates.leftRoads[random].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                //Need to spawn road with RIGHT opening
                random = Random.Range(0, roadTemplates.rightRoads.Length);
                Instantiate(roadTemplates.rightRoads[random], transform.position, roadTemplates.rightRoads[random].transform.rotation);
            }
            created = true;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        //If a road collides with another road this roadmarker will get destroyed, thus stop making other roads
        if (collision.CompareTag("RoadMarkerTag"))
        {
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Center"))
        {
            Destroy(gameObject);
            Debug.Log("End the path here");
            //End Road prefab needs to be spawn here
        }
    }
}