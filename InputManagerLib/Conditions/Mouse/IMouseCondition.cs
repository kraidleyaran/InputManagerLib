namespace InputManagerLib.Conditions.Mouse
{
    public interface IMouseCondition: IInputCondition
    {
        MouseConditionType MouseConditionType { get; set; }
    }
}