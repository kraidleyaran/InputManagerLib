using Microsoft.Xna.Framework.Input;

namespace InputManagerLib.Conditions.Keyboard
{
    public class KeyboardCondition : IInputCondition
    {
        private InputConditionType _inputConditionType = InputConditionType.Keyboad;
        public KeyboardCondition()
        {
            
        }

        public KeyboardCondition(string name, Keys key, Operator inputOperator, KeyState keystate)
        {
            Name = name;
            Key = key;
            Operator = inputOperator;
            KeyState = keystate;
        }
        public string Name { get; set; }
        public InputConditionType InputConditionType { get { return _inputConditionType; } set { } } 
        public Keys Key { get; private set; }
        public Operator Operator { get; set; }
        public KeyState KeyState { get; private set; }
    }
}