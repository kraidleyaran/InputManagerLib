using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace InputManagerLib.Conditions.GamePad
{
    public class GamePadButtonCondition : IGamePadCondition
    {
        private const GamePadConditionType _gamePadConditionType = GamePadConditionType.Button;
        private const InputConditionType _inputConditionType = InputConditionType.GamePad;
        public GamePadButtonCondition()
        {
            
        }

        public GamePadButtonCondition(string name, PlayerIndex playerIndex, Buttons button, Operator inputOperator, ButtonState buttonState)
        {
            Name = name;
            Player = playerIndex;
            Button = button;
            Operator = inputOperator;
            ButtonState = buttonState;
        }

        public string Name { get; set; }
        public InputConditionType InputConditionType { get { return _inputConditionType; } set { } }
        public GamePadConditionType GamePadConditionType {get { return _gamePadConditionType; } set{}}

        public PlayerIndex Player { get; set; }
        public Buttons Button { get; private set; }
        public Operator Operator { get; set; }
        public ButtonState ButtonState { get; private set; }

    }
}