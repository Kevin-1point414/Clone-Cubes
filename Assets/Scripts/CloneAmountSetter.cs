using UnityEngine;

public class CloneAmountSetter : MonoBehaviour
{
    [SerializeField] private int NumberOfClonesToSet;
    private void OnTriggerEnter2D()
    {
        PlayerClone.numberOfClonesCreatable = NumberOfClonesToSet;
        PlayerClone.numberOfClonesCreatableDisplay.text = "Number of Clones Creatable: " +
            PlayerClone.numberOfClonesCreatable;
        Destroy(gameObject);
    }
}
