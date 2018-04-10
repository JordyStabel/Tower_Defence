using UnityEngine;

public class CameraController : MonoBehaviour {

    public float panSpeed = 20f;
    public float scrollSpeed = 3f;
    public float rotateSpeed = 50f;
    public Vector2 scrollLimit;
    public Vector2 panLimit;

    public Transform target;

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

        Vector3 currentPosition = transform.position;

        //Move camera in dirrection of key or mouse input
        if (Input.GetKey("w"))
        {
            currentPosition.z += (panSpeed * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            currentPosition.z -= (panSpeed * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            currentPosition.x += (panSpeed * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            currentPosition.x -= (panSpeed * Time.deltaTime);
        }
        if (Input.GetKey("e"))
        {
            transform.RotateAround(target.position, Vector3.up, (rotateSpeed * Time.deltaTime));
        }
        if (Input.GetKey("q"))
        {
            transform.RotateAround(target.position, Vector3.down, (rotateSpeed * Time.deltaTime));
        }

        //Get scrollwheel input
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        //Set zoom level (height of camera), with min and max values
        currentPosition.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        currentPosition.y = Mathf.Clamp(currentPosition.y, scrollLimit.x, scrollLimit.y);

        //Implement limits for the camera
        currentPosition.x = Mathf.Clamp(currentPosition.x, -panLimit.x, panLimit.x);
        currentPosition.z = Mathf.Clamp(currentPosition.z, -panLimit.y, panLimit.y);

        //Set camera posistion equal the new currentPosition
        transform.position = currentPosition;
    }
}