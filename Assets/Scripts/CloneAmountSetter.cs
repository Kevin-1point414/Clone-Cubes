using UnityEngine;

public class CloneAmountSetter : MonoBehaviour
{
    [SerializeField] private int numberOfClonesToSet;
    private void OnTriggerEnter2D()
    {
        PlayerClone.numberOfClonesCreatable = numberOfClonesToSet;
        PlayerClone.numberOfClonesCreatableDisplay.text = "Number of Clones Creatable: " +
            PlayerClone.numberOfClonesCreatable;
        Destroy(gameObject);
    }
}
