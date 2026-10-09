using UnityEngine;
public enum UnitType
{
    Soldier,
    Villager,
    Coin
}
public class ResourceManager : MonoBehaviour
{
    
    [SerializeField] private UIManager uiManager;
    public int Coins { get; private set; }
    public int Civillian { get; private set; }
    public int Soldier { get; private set; }
    
    public void AddCoins(int value)
    {
        Coins += value;
        uiManager.UpdateUI(UnitType.Coin, Coins);
    }
    public void AddCivillian(int civillian)
    {
        Civillian += civillian;
        uiManager.UpdateUI(UnitType.Villager, Civillian);
    }
    public void AddSoldier(int soldier)
    {
        Soldier += soldier;
        uiManager.UpdateUI(UnitType.Soldier, Soldier);
    }
}
