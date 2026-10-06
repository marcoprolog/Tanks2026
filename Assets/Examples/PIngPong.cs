using UnityEngine;

public class PIngPong : MonoBehaviour
{
    public Color color1 = Color.white;
    public Color color2 = Color.black;

    // Update is called once per frame
    void Update()
    {
        Color newColor = Color.Lerp(color1, color2, Mathf.PingPong(Time.time, 1));
        gameObject.GetComponent<MeshRenderer>().material.color = newColor;
    }
}
