using UnityEngine;

public class CameraController : MonoBehaviour {

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 100f;

    private bool movementAllowed = true;
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray selectEnemy = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(selectEnemy, out hit, 1500f))
            {
                if (hit.collider.tag == "Enemy")
                {
                    Debug.Log("Raycast worked!");
                    hit.collider.GetComponent<Enemy>().TakeDamage(1000);
                }
            }
        }

        //Disable the camera when game is over
        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        //Toggle movementAllowed when 'Escape-key' is pressed
        if (Input.GetKeyDown (KeyCode.C))
        {
            movementAllowed = !movementAllowed;
        }

        //Cancel action when movermentAllowed if false
        if (!movementAllowed)
            return;

        //Move camera in dirrection of key or mouse input
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        ////Turn the camera
        //if (Input.GetKey("q"))
        //{
        //    Vector3 rotateValue = new Vector3(panSpeed * Time.deltaTime, -0.05f);
        //    transform.eulerAngles = transform.eulerAngles - rotateValue;
        //}
        //if (Input.GetKey("e"))
        //{
        //    Vector3 rotateValue = new Vector3(panSpeed * Time.deltaTime, 1);
        //    transform.eulerAngles = transform.eulerAngles - rotateValue;
        //}

        //Get scrollwheel input
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 position = transform.position;

        //Set zoom level (height of camera), with min and max values
        position.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, minY, maxY);

        //Set camera posistion equal to scroll input
        transform.position = position;
    }
}