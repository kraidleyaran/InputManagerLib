using Microsoft.Xna.Framework;

namespace InputManagerLib.Conditions.GamePad
{
    public interface IGamePadCondition: IInputCondition
    {
        PlayerIndex Player { get; set; }
        GamePadConditionType GamePadConditionType { get; set; }
    }
}