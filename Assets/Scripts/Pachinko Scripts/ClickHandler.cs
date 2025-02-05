using UnityEngine;

//I decided to go with this method of handling clicks with help from Chatgpt. Especially when I get to making upgrades, there'll be a good
//few different clickable areas, so it's best to make one class that handles clicking instead of writing the same code into the update method of half a dozen scripts. 

public class ClickHandler : MonoBehaviour
{
    //Every clickable area will be set to the clickable layer, to make sure the click collider doesn't mess with the game in any way.
    public LayerMask clickable;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //Casts a ray from camera to where you clicked
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            /*
             * Ray is the ray created by the click. Out hit is the output of the RaycastHit, storing information about the intersected collider.
             * Mathf.Infinity means the ray will keep going either forever or until it hits something. Clickable makes sure only something in the clickable
             * layer will be acted upon.
             */
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, clickable))
            {
                //On a legal click, get the part of the clickable object that implements clicks and call it's onClick method, passing where the click was to it.
                Clickable clickable = hit.collider.GetComponent<Clickable>();
                if(clickable != null)
                {
                    clickable.onClick(hit.point);
                }
            }


        }
    }
}
