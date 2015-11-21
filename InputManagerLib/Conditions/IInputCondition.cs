namespace InputManagerLib.Conditions
{
    public interface IInputCondition
    {
        string Name { get; set; }
        Operator Operator { get; set; }
        InputConditionType InputConditionType { get; set; }
    }
}