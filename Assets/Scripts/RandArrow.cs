using UnityEngine;
using System.Collections;

public class RandArrow : MonoBehaviour
{

    GameObject last;
    GameObject found;
    public bool go;

    // Use this for initialization
    void Start()
    {
        found = this.transform.GetChild(Random.Range(0,7)).transform.GetChild(2).gameObject;
        found.GetComponent<ShootArrow>().on = false;
        last = found;
        go = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (go)
        {
            do
            {
                int rand = Random.Range(0, 7);
                found = this.transform.GetChild(rand).transform.GetChild(2).gameObject;
            } while (last == found);

            if (found.GetComponent<ShootArrow>().on)
            {
                found.GetComponent<ShootArrow>().on = false;
            }
            if (!last.GetComponent<ShootArrow>().on)
            {
                last.GetComponent<ShootArrow>().on = true;
            }
            last = found;
            go = false;
        }
    }
}
