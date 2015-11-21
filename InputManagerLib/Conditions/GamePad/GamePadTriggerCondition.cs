using InputManagerLib.Conditions.GamePadObjects;
using Microsoft.Xna.Framework;

namespace InputManagerLib.Conditions.GamePad
{
    public class GamePadTriggerCondition : IGamePadCondition
    {
        private InputConditionType _inputConditionType = InputConditionType.GamePad;
        private GamePadConditionType _gamePadConditionType = GamePadConditionType.Trigger;
        public GamePadTriggerCondition()
        {
            
        }


        public GamePadTriggerCondition(string name, PlayerIndex playerIndex, Trigger trigger, Operator inputOperator, float compareValue)
        {
            Name = name;
            Player = playerIndex;
            Trigger = trigger;
            Operator = inputOperator;
            CompareValue = compareValue;
        }

        public string Name { get; set; }
        public InputConditionType InputConditionType { get { return _inputConditionType; } set { } }
        public GamePadConditionType GamePadConditionType { get { return _gamePadConditionType; }set { } }
        public PlayerIndex Player { get; set; }
        public Trigger Trigger { get; private set; }
        public Operator Operator { get; set; }
        public float CompareValue { get; private set; }
    }
}