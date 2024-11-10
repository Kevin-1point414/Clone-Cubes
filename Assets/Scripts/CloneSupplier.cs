using UnityEngine;

public class CloneSupplier : MonoBehaviour
{
    [SerializeField] private int NumberOfClonesToGive;
    private void OnTriggerEnter2D()
    {
        PlayerClone.numberOfClonesCreatable += NumberOfClonesToGive;
        PlayerClone.numberOfClonesCreatableDisplay.text = "Number of Clones Creatable: " +
            PlayerClone.numberOfClonesCreatable;
        Destroy(gameObject);
    }
}
