using UnityEngine;
using System.Collections;

public class CookWaddle : MonoBehaviour {

    private bool rotatingClockwise;
    [SerializeField]
    private float waddleLimit;
    [SerializeField]
    private float rotationSpeed;

    void Start()
    {
        rotatingClockwise = true;
    }

    void Update ()
    {
        if (gameObject.transform.rotation.eulerAngles.z > waddleLimit && gameObject.transform.rotation.eulerAngles.z < 360f-waddleLimit)
        {
            rotatingClockwise = !rotatingClockwise;
        }

        if (rotatingClockwise)
        {
            gameObject.transform.Rotate(new Vector3(0, 0, rotationSpeed));
        }
        else
        {
            gameObject.transform.Rotate(new Vector3(0, 0, -rotationSpeed));
        }
    }
}
