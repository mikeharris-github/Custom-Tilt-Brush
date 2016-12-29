using UnityEngine;

public class Draggable : MonoBehaviour
{
    // add variable for controller
    public SteamVR_TrackedObject trackedObj;

    public bool fixX;
	public bool fixY;
	public Transform thumb;	
	bool dragging;

	void FixedUpdate()
	{
        // add syntax for the controller trigger
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
      //  }
      //replace the GetMouseButtonDown so it utilizes the trigger button
        //    if (Input.GetMouseButtonDown(0)) {
			dragging = false;
            //new ray needs to be created since we are tracking by the controller and not a 2D interface.
            Ray ray = new Ray(trackedObj.transform.position, trackedObj.transform.forward); // it starts from the tracked controller position, then ray forward
			//var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity)) { //Mathf.Infinity replaced 100 units away so the raycast can detect infinite meters
				dragging = true;
			}
		}
        //replaced the GetMouseButtonUp with the steamVR gettouchup
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger)) dragging = false;
		if (dragging && device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            Ray ray = new Ray(trackedObj.transform.position, trackedObj.transform.forward); // it starts from the tracked controller position, then ray forward
                                                                                            //var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity))
            { //Mathf.Infinity replaced 100 so the raycast can detect infinite meters
                var point = hit.point; //Camera.main.ScreenToWorldPoint(Input.mousePosition); is replaced
                point = GetComponent<Collider>().ClosestPointOnBounds(point);
                SetThumbPosition(point);
                SendMessage("OnDrag", Vector3.one - (thumb.position - GetComponent<Collider>().bounds.min) / GetComponent<Collider>().bounds.size.x);
            }

           
		}
	}

	void SetDragPoint(Vector3 point)
	{
		point = (Vector3.one - point) * GetComponent<Collider>().bounds.size.x + GetComponent<Collider>().bounds.min;
		SetThumbPosition(point);
	}

	void SetThumbPosition(Vector3 point)
	{
		thumb.position = new Vector3(fixX ? thumb.position.x : point.x, fixY ? thumb.position.y : point.y, thumb.position.z);
	}
}
