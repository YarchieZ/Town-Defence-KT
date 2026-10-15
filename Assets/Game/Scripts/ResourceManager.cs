using UnityEngine;
public enum UnitType
{
    Soldier,
    Villager,
    Coin,
    Paladin
}
public class ResourceManager : MonoBehaviour
{
    [SerializeField] private VictoryCalculator victoryCalculator;
    [SerializeField] private UIManager uiManager;
    public int Coins { get; private set; }
    public int Civillian { get; private set; }
    public int Soldier { get; private set; }
    
    public int Paladin { get; private set; }
    
    public void AddCoins(int value)
    {
        Coins += value;
        uiManager.UpdateUI(UnitType.Coin, Coins);
        if (Coins <= -20)
        {
            victoryCalculator.OnLoseEvent(Coins);
        }
    }
    public void AddCivillian(int civillian)
    {
        if (civillian < 0 && civillian * -1 > Civillian)
        {
            Coins +=  civillian;
            Civillian = 0;
            uiManager.UpdateUI(UnitType.Villager, Civillian);
            return;
        }
        Civillian += civillian;
        uiManager.UpdateUI(UnitType.Villager, Civillian);
    }
    public void AddSoldier(int soldier)
    {
        if (soldier < 0 && soldier * -1 > Soldier)
        {
            Coins +=  soldier;
            Soldier = 0;
            uiManager.UpdateUI(UnitType.Soldier, Soldier);
            return;
        }
        Soldier += soldier;
        uiManager.UpdateUI(UnitType.Soldier, Soldier);
    }

    public void AddPaladin(int paladin)
    {
        if (paladin < 0 && paladin * -1 > Paladin)
        {
            Coins +=  paladin;
            Paladin = 0;
            uiManager.UpdateUI(UnitType.Paladin, Paladin);
        }
        Paladin += paladin;
        uiManager.UpdateUI(UnitType.Paladin, Paladin);
    }
}
