using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    
    public int Wheat { get; private set; }
    public int Civillian { get; private set; }
    public int Soldier { get; private set; }

    public void AddWheat(int wheat)
    {
        Wheat += wheat;
    }
    public void AddCivillian(int civillian)
    {
        Civillian += civillian;
    }
    public void AddSoldier(int soldier)
    {
        Soldier += soldier;
    }
}
