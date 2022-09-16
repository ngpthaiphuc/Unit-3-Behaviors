using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementActivator : MonoBehaviour
{
    [SerializeField] GameObject objectToActivate;
    [SerializeField] bool isMoveActivator = true;
    [SerializeField] bool isBowser;

    // Start is called before the first frame update
    void Start()
    {
        //objectToActivate.GetComponent<MoveObject>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator waitSeconds(float sec)
    {
        yield return new WaitForSeconds(sec);
    }

    private void OnTriggerEnter(Collider other)
    {
        Renderer obj_render = objectToActivate.GetComponent<Renderer>();

        if (isBowser)
        {
            objectToActivate.GetComponent<MoveObject>().enabled = true;
            objectToActivate.GetComponent<RotateObject>().enabled = false;
            obj_render.material.color = Color.green;

            waitSeconds(100);

            objectToActivate.GetComponent<MoveObject>().enabled = false;
            objectToActivate.GetComponent<RotateObject>().enabled = true;
            obj_render.material.color = Color.blue;

            waitSeconds(100);
        }
        else if (isMoveActivator)
        {
            objectToActivate.GetComponent<MoveObject>().enabled = true;
            obj_render.material.color = Color.green;
        }
        else
        {
            objectToActivate.GetComponent<RotateObject>().enabled = true;
            obj_render.material.color = Color.blue;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Renderer obj_render = objectToActivate.GetComponent<Renderer>();

        if (isMoveActivator)
        {
            objectToActivate.GetComponent<MoveObject>().enabled = true;
            obj_render.material.color = Color.green;
        }
        else
        {
            objectToActivate.GetComponent<RotateObject>().enabled = true;
            obj_render.material.color = Color.blue;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isMoveActivator)
        {
            objectToActivate.GetComponent<MoveObject>().enabled = false;
        }
        else
        {
            objectToActivate.GetComponent<RotateObject>().enabled = false;
        }

        Renderer obj_render = objectToActivate.GetComponent<Renderer>();
        obj_render.material.color = Color.red;
    }
}
