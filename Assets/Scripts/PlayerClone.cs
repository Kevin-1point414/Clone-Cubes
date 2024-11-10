using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerClone : MonoBehaviour
{
    public bool selected = true;
    public static List<GameObject> clones = new();
    public static int numberOfClonesCreatable;
    public static TextMeshProUGUI numberOfClonesCreatableDisplay;
    new Rigidbody2D rigidbody;
    void Start()
    {
        clones.Add(gameObject);
        numberOfClonesCreatableDisplay = GameObject.Find("ClonesCreatableDisplay").GetComponent
            <TextMeshProUGUI>();
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && selected && numberOfClonesCreatable > 0) 
        {
            numberOfClonesCreatable--;
            Vector3 changeInPosition = rigidbody.velocity * Time.deltaTime;
            changeInPosition.y *= 4;
            GameObject clone = Instantiate(gameObject, gameObject.transform.position - changeInPosition,
                gameObject.transform.rotation);
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.y * 2);
            clone.GetComponent<PlayerClone>().selected = false;
            clone.GetComponent<SpriteRenderer>().color = Color.green;
            numberOfClonesCreatableDisplay.text = "Number of Clones Creatable: " +
                numberOfClonesCreatable;
        }
    }
    private void OnMouseDown()
    {
        foreach(GameObject clone in clones)
        {
            clone.GetComponent<PlayerClone>().selected = false;
            clone.GetComponent<SpriteRenderer>().color = Color.green;
        }
        selected = true;
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
