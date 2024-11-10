using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerClone : MonoBehaviour
{
    public bool selected = true;
    private static List<GameObject> Clones = new();
    public static int numberOfClonesCreatable;
    public static TextMeshProUGUI numberOfClonesCreatableDisplay;
    void Start()
    {
        Clones.Add(gameObject);
        numberOfClonesCreatableDisplay = GameObject.Find("ClonesCreatableDisplay").GetComponent
            <TextMeshProUGUI>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && selected && numberOfClonesCreatable > 0) 
        {
            numberOfClonesCreatable--;
            GameObject clone = Instantiate(gameObject);
            clone.GetComponent<PlayerClone>().selected = false;
            clone.GetComponent<SpriteRenderer>().color = Color.green;
            numberOfClonesCreatableDisplay.text = "Number of Clones Creatable: " +
                numberOfClonesCreatable;
        }
    }
    private void OnMouseDown()
    {
        foreach(GameObject clone in Clones)
        {
            clone.GetComponent<PlayerClone>().selected = false;
            clone.GetComponent<SpriteRenderer>().color = Color.green;
        }
        selected = true;
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
