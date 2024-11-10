using UnityEngine;

public class CloneSupplier : MonoBehaviour
{
    [SerializeField] private int numberOfClonesToGive;
    private void OnTriggerEnter2D()
    {
        PlayerClone.numberOfClonesCreatable += numberOfClonesToGive;
        PlayerClone.numberOfClonesCreatableDisplay.text = "Number of Clones Creatable: " +
            PlayerClone.numberOfClonesCreatable;
        Destroy(gameObject);
    }
}
