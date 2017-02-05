using UnityEngine;

public class Draggable : MonoBehaviour
{
    public SteamVR_TrackedObject rightController;

    public Transform minBound;

	public bool fixX;
	public bool fixY;
	public Transform thumb;	
	bool dragging;

	void FixedUpdate()
	{
        // SteamVR Controller
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)rightController.index);
        if(device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            dragging = false;
            Ray ray = new Ray(rightController.transform.position, rightController.transform.forward);
            RaycastHit hit;
            if (GetComponent<Collider>().Raycast(ray, out hit, 100))
            {
                dragging = true;
            }
        }
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            dragging = false;
        }
        if (dragging && device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            Ray ray = new Ray(rightController.transform.position, rightController.transform.forward);
            RaycastHit hit;
            if (GetComponent<Collider>().Raycast(ray, out hit, 100))
            {
                dragging = true;
            }

            var point = hit.point;
            SetThumbPosition(point);
            SendMessage("OnDrag", Vector3.one - (thumb.position - minBound.localPosition) / GetComponent<BoxCollider>().size.x);
        }

        // Mouse Controller
        /*
        if (Input.GetMouseButtonDown(0)) {
			dragging = false;
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (GetComponent<Collider>().Raycast(ray, out hit, 100)) {
				dragging = true;
			}
		}
		if (Input.GetMouseButtonUp(0)) dragging = false;
		if (dragging && Input.GetMouseButton(0)) {
			var point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			point = GetComponent<Collider>().ClosestPointOnBounds(point);
			SetThumbPosition(point);
			SendMessage("OnDrag", Vector3.one - (thumb.position - GetComponent<Collider>().bounds.min) / GetComponent<Collider>().bounds.size.x);
		}
        */
	}

	void SetDragPoint(Vector3 point)
	{
        

        // Mouse Controller
        /*
        point = (Vector3.one - point) * GetComponent<Collider>().bounds.size.x + GetComponent<Collider>().bounds.min;
		SetThumbPosition(point);
        */
	}

	void SetThumbPosition(Vector3 point)
	{
        // SteamVR Controller
        Vector3 tempThumbPos = thumb.localPosition;
        thumb.position = point;
        thumb.localPosition = new Vector3(fixX ? tempThumbPos.x : thumb.localPosition.x, fixY ? tempThumbPos.y : thumb.localPosition.y, tempThumbPos.z - 1);

        // Mouse Controller
        /*
        thumb.position = new Vector3(fixX ? thumb.position.x : point.x, fixY ? thumb.position.y : point.y, thumb.position.z);
        */
    }
}
