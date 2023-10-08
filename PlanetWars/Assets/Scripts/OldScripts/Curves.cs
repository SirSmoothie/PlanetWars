using UnityEngine;

public class Curves : MonoBehaviour
{
    public float A;
    public float B;
    public float curveTimer;
    public AnimationCurve curve;

    // Update is called once per frame
    void Update()
    {
        if (curveTimer >= 0)
        {
            curveTimer -= Time.deltaTime;
        }

        B = curve.Evaluate(curveTimer);
    }
}
