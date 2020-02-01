using UnityEngine;

public class Explosion : MonoBehaviour
{


    void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            transform.localScale = new Vector3(Random.Range(0, 10),Random.Range(0, 10),1);
        }
    }
}
