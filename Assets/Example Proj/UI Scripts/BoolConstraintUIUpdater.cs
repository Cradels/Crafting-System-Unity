using UnityEngine;
using UnityEngine.UI;

public class BoolConstraintUIUpdater : MonoBehaviour
{
    public BoolConstraint boolConstraint;
    
    public Toggle constraintToggle;

    [SerializeField]
    private InventoryManager inventoryManager;

    private void Start()
    {
        if (boolConstraint == null || constraintToggle == null)
        {
            Debug.LogError("Missing references on BoolConstraintUIUpdater!");
            return;
        }
        
        constraintToggle.isOn = boolConstraint.IsFullfilled();
        
        constraintToggle.onValueChanged.AddListener(OnToggleChanged);
    }

    private void OnToggleChanged(bool newValue)
    {
        boolConstraint.SetCondition(newValue);
        inventoryManager.Filter();
    }
}