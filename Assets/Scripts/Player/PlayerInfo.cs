using UnityEngine;

public class PlayerInfo : MonoBehaviour {

    [SerializeField,Range(0,2)]
    private int _USBAmount;

    public int USBAmount {

        get {
        
            return _USBAmount;
        
        }

    }

    public void IncreaseAmount() {
        if (USBAmount >= 2) return;
        _USBAmount++;
        
    }

    public bool DecreaseAmount() {
        if (USBAmount <= 0) return false;
        _USBAmount--;
        return true;
    }

}