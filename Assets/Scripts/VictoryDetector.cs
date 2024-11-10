using TMPro;
using UnityEngine;

public class VictoryDetector : MonoBehaviour
{
    private void OnTriggerEnter2D()
    {
        GameObject.Find("Victory Text").GetComponent<TextMeshProUGUI>().enabled = true;
    }
}
