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

    private int maxAmount = 10;
    private int currentAmount = 0;

    private void Start()
    {
        //Get the roadtemplate object form the hierarchy only during the start of this object
        roadTemplates = GameObject.FindGameObjectWithTag("Roads").GetComponent<RoadTemplates>();

        //Call the CreateRoad methode with 0.2 seconds delay
        Invoke("CreateRoad", 0.2f);
    }

    void CreateRoad()
    {
        if (!created && currentAmount <= maxAmount)
        {
            if (openingDirection == 1)
            {
                //Need to spawn road with BOTTOM opening
                random = Random.Range(0, roadTemplates.bottomRoads.Length);
                Instantiate(roadTemplates.bottomRoads[random], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 2)
            {
                //Need to spawn road with TOP opening
                random = Random.Range(0, roadTemplates.topRoads.Length);
                Instantiate(roadTemplates.topRoads[random], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 3)
            {
                //Need to spawn road with LEFT opening
                random = Random.Range(0, roadTemplates.leftRoads.Length);
                Instantiate(roadTemplates.leftRoads[random], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 4)
            {
                //Need to spawn road with RIGHT opening
                random = Random.Range(0, roadTemplates.rightRoads.Length);
                Instantiate(roadTemplates.rightRoads[random], transform.position, Quaternion.identity);
            }
            currentAmount++;
            created = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If a road collides with another road it will get destroyed
        if (collision.CompareTag("RoadMarkerTag") && collision.GetComponent<RoadMarker>().created == true)
        {
            Destroy(gameObject);
        }
    }
}