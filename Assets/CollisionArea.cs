using UnityEngine;

public class CollisionArea : MonoBehaviour
{

    public PinControl pinControl;

    public TMPro.TextMeshProUGUI score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pin"))
        {
            pinControl.AddFallPin(other.gameObject);
            score.text = "SCORE: " + pinControl.GetScore();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
