using InputManagerLib.Conditions.GamePadObjects;
using Microsoft.Xna.Framework;

namespace InputManagerLib.Conditions.GamePad
{
    public class GamePadThumbStickCondition : IGamePadCondition
    {
        private const GamePadConditionType _gamePadConditionType = GamePadConditionType.ThumbStick;
        private const InputConditionType _inputConditionType = InputConditionType.GamePad;
        public GamePadThumbStickCondition()
        {
            
        }

        public GamePadThumbStickCondition(string name,PlayerIndex playerIndex, ThumbStick thumbStick, Coords coordsType, Operator inputOperator,
            float compareValue)
        {
            Name = name;
            Player = playerIndex;
            ThumbStick = thumbStick;
            CoordsType = coordsType;
            Operator = inputOperator;
            CompareValue = compareValue;
        }

        public string Name { get; set; }
        public InputConditionType InputConditionType { get { return _inputConditionType;}set { } }
        public GamePadConditionType GamePadConditionType { get { return _gamePadConditionType; } set { } }
        public PlayerIndex Player { get; set; }
        public ThumbStick ThumbStick { get; private set; }
        public Coords CoordsType { get; private set; }
        public Operator Operator { get; set; }
        public float CompareValue { get; private set; }
    }
}