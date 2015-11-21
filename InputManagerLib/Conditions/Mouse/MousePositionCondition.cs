namespace InputManagerLib.Conditions.Mouse
{
    public class MousePositionCondition : IMouseCondition
    {
        private const InputConditionType _inputConditionType = InputConditionType.Mouse;
        private const MouseConditionType _mouseConditionType = MouseConditionType.Position;
        public MousePositionCondition()
        {
            
        }

        public MousePositionCondition(string name, Coords coordType, Operator inputOperator,
            int compareValue)
        {
            Name = name;
            CoordType = coordType;
            Operator = inputOperator;
            CompareValue = compareValue;
        }
        public string Name { get; set; }
        public InputConditionType InputConditionType { get { return _inputConditionType; } set { } }
        public MouseConditionType MouseConditionType { get { return _mouseConditionType; } set { } }
        public Coords CoordType { get; private set; }
        public Operator Operator { get; set; }
        public int CompareValue { get; private set; }
        
        
    }
}