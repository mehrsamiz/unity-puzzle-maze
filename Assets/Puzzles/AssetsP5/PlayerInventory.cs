using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool HasDiamond { get; private set; }

    public bool HasBarg { get; private set; }
    public bool HasMive { get; private set; }
    public bool HasLebas { get; private set; }

    public bool HasFood { get; private set; }
    public bool HasWater { get; private set; }
    public bool HasChoob { get; private set; }
    public bool HasGoosht { get; private set; }
    public bool HasPato { get; private set; }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void CollectDiamond()
    {
        HasDiamond = true;
    }

    public void CollectFood()
    {
        HasFood = true;
    }

    public void CollectWater()
    {
        HasWater = true;
    }
    public void CollectBarg()
    {
        HasBarg = true;
    }

    public void CollectMive()
    {
        HasMive = true;
    }

    public void CollectLebas()
    {
        HasLebas = true;
    }
    public void CollectChoob()
    {
        HasChoob = true;
    }

    public void CollectGoosht()
    {
        HasGoosht = true;
    }

    public void CollectPato()
    {
        HasPato = true;
    }

    public bool IsReadyForWinter()
    {
        return HasFood &&
               HasWater &&
               HasBarg &&
               HasMive &&
               HasLebas &&
               HasChoob &&
               HasGoosht &&
               HasPato;
    }

}
    