using InputManagerLib.Conditions.MouseObjects;
using Microsoft.Xna.Framework.Input;

namespace InputManagerLib.Conditions.Mouse
{
    public class MouseButtonCondition : IMouseCondition
    {
        private const MouseConditionType _mouseConditionType = MouseConditionType.Button;
        private const InputConditionType _inputConditionType = InputConditionType.Mouse;

        public MouseButtonCondition()
        {
            
        }

        public MouseButtonCondition(string name, MouseButton mouseButton, Operator inputOperator,
            ButtonState buttonState)
        {
            Name = name;
            MouseButton = mouseButton;
            Operator = inputOperator;
            ButtonState = buttonState;
        }
        public string Name { get; set; }
        public InputConditionType InputConditionType { get { return _inputConditionType; } set { } }
        public MouseConditionType MouseConditionType { get { return _mouseConditionType;} set { } }
        public MouseButton MouseButton { get; private set; }
        public Operator Operator { get; set; }
        public ButtonState ButtonState { get; private set; }

    }
}