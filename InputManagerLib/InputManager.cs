using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using GameInputLibrary;
using InputManagerLib.Conditions;
using InputManagerLib.Conditions.GamePad;
using InputManagerLib.Conditions.GamePadObjects;
using InputManagerLib.Conditions.Keyboard;
using InputManagerLib.Conditions.Mouse;
using InputManagerLib.Conditions.MouseObjects;
using Microsoft.Xna.Framework;

namespace InputManagerLib
{
    public class InputManager
    {
        private Dictionary<string, IInputCondition> _inputConditions;
        public InputManager()
        {
            _inputConditions = new Dictionary<string, IInputCondition>();
        }
        #region Add Conditions

        public bool AddCondition(IInputCondition condition)
        {
            if (_inputConditions.ContainsKey(condition.Name)) return false;
            _inputConditions.Add(condition.Name, condition);
            return true;
        }
        #endregion
        #region Remove Conditions

        public bool RemoveCondition(string name)
        {
            return _inputConditions.Remove(name);
        }
        #endregion
        #region Clear Conditions

        public void ClearConditions()
        {
            _inputConditions.Clear();
            _inputConditions = new Dictionary<string, IInputCondition>();
        }
        #endregion
        #region Evaluate Conditions
        #region GamePad
        public bool? EvaluateGamePadButtonCondition(string conditionName, InputResponse response)
        {
            if (!_inputConditions.ContainsKey(conditionName)) return false;
            GamePadButtonCondition condition = (GamePadButtonCondition) _inputConditions[conditionName];
            if (condition == null) return false;
            GamePadState state;
            switch (condition.Player)
            {
                case PlayerIndex.One:
                    state = response.GamePadStates[1];
                    return EvaluateGamePadButtonCondition(condition, state);
                case PlayerIndex.Two:
                    state = response.GamePadStates[2];
                    return EvaluateGamePadButtonCondition(condition, state);
                case PlayerIndex.Three:
                    state = response.GamePadStates[3];
                    return EvaluateGamePadButtonCondition(condition, state);
                case PlayerIndex.Four:
                    state = response.GamePadStates[4];
                    return EvaluateGamePadButtonCondition(condition, state);
            }
            return null;
        }

        public bool? EvaluateGamePadThumbStickCondition(string conditionName, InputResponse response)
        {
            if (!_inputConditions.ContainsKey(conditionName)) return false;
            GamePadThumbStickCondition condition = (GamePadThumbStickCondition)_inputConditions[conditionName];
            if (condition == null) return false;
            GamePadState state;
            switch (condition.Player)
            {
                case PlayerIndex.One:
                    state = response.GamePadStates[1];
                    return EvaluateGamePadThumbStickCondition(condition, state);
                case PlayerIndex.Two:
                    state = response.GamePadStates[2];
                    return EvaluateGamePadThumbStickCondition(condition, state);
                case PlayerIndex.Three:
                    state = response.GamePadStates[3];
                    return EvaluateGamePadThumbStickCondition(condition, state);
                case PlayerIndex.Four:
                    state = response.GamePadStates[4];
                    return EvaluateGamePadThumbStickCondition(condition, state);
            }
            return null;
        }

        public bool? EvaluateGamePadTriggerCondition(string conditionName, InputResponse response)
        {
            if (!_inputConditions.ContainsKey(conditionName)) return false;
            GamePadTriggerCondition condition = (GamePadTriggerCondition) _inputConditions[conditionName];
            if (condition == null) return false;
            GamePadState state;
            switch (condition.Player)
            {
                case PlayerIndex.One:
                    state = response.GamePadStates[1];
                    return EvaluateGamePadTriggerCondition(condition, state);
                case PlayerIndex.Two:
                    state = response.GamePadStates[2];
                    return EvaluateGamePadTriggerCondition(condition, state);
                case PlayerIndex.Three:
                    state = response.GamePadStates[3];
                    return EvaluateGamePadTriggerCondition(condition, state);
                case PlayerIndex.Four:
                    state = response.GamePadStates[4];
                    return EvaluateGamePadTriggerCondition(condition, state);
            }
            return null;
        }
        #endregion
        #region Mouse
        public bool? EvaluateMouseButtonCondition(string conditionName, MouseState state)
        {
            if (!_inputConditions.ContainsKey(conditionName)) return false;
            MouseButtonCondition condition = (MouseButtonCondition) _inputConditions[conditionName];
            return EvaluateMouseButtonCondition(condition, state);
        }

        public bool? EvaluateMousePositionCondition(string conditionName, MouseState state)
        {
            if (!_inputConditions.ContainsKey(conditionName)) return false;
            MousePositionCondition condition =(MousePositionCondition) _inputConditions[conditionName];
            return EvaluateMousePositionCondition(condition, state);
        }
        #endregion
        #region Keyboard

        public bool? EvaluateKeyboardCondition(string conditionName, KeyboardState state)
        {
            if (!_inputConditions.ContainsKey(conditionName)) return false;
            KeyboardCondition condition = (KeyboardCondition) _inputConditions[conditionName];
            return EvaluateKeyboardCondition(condition, state);
        }
        #endregion
        #endregion
        #region Helper Methods for Condition Evaluation
        #region GamePad
        private static bool? EvaluateGamePadButtonCondition(GamePadButtonCondition condition, GamePadState state)
        {
            switch (condition.Operator)
            {
                case Operator.Equal:
                    switch (condition.ButtonState)
                    {
                        case ButtonState.Pressed:
                            return state.IsButtonDown(condition.Button);
                        case ButtonState.Released:
                            return state.IsButtonUp(condition.Button);
                    }
                    break;
                case Operator.NotEqual:
                    switch (condition.ButtonState)
                    {
                        case ButtonState.Pressed:
                            return !state.IsButtonDown(condition.Button);
                        case ButtonState.Released:
                            return !state.IsButtonUp(condition.Button);
                    }
                    break;
            }

            return null;
        }

        private static bool? EvaluateGamePadThumbStickCondition(GamePadThumbStickCondition condition, GamePadState state)
        {
            switch (condition.Operator)
            {
                case Operator.Equal:
                    switch (condition.ThumbStick)
                    {
                        case ThumbStick.Left:
                            switch (condition.CoordsType)
                            {
                                case Coords.X:
                                    return state.ThumbSticks.Left.X == condition.CompareValue;
                                case Coords.Y:
                                    return state.ThumbSticks.Left.Y == condition.CompareValue;
                            }
                            break;
                        case ThumbStick.Right:
                            switch (condition.CoordsType)
                            {
                                case Coords.X:
                                    return state.ThumbSticks.Right.X == condition.CompareValue;
                                case Coords.Y:
                                    return state.ThumbSticks.Right.Y == condition.CompareValue;
                            }
                            break;
                    }
                    break;
                case Operator.NotEqual:
                    switch (condition.ThumbStick)
                    {
                        case ThumbStick.Left:
                            switch (condition.CoordsType)
                            {
                                case Coords.X:
                                    return state.ThumbSticks.Left.X != condition.CompareValue;
                                case Coords.Y:
                                    return state.ThumbSticks.Left.Y != condition.CompareValue;
                            }
                            break;
                        case ThumbStick.Right:
                            switch (condition.CoordsType)
                            {
                                case Coords.X:
                                    return state.ThumbSticks.Right.X != condition.CompareValue;
                                case Coords.Y:
                                    return state.ThumbSticks.Right.Y != condition.CompareValue;
                            }
                            break;
                    }
                    break;
                case Operator.GreaterThan:
                    switch (condition.ThumbStick)
                    {
                        case ThumbStick.Left:
                            switch (condition.CoordsType)
                            {
                                case Coords.X:
                                    return state.ThumbSticks.Left.X > condition.CompareValue;
                                case Coords.Y:
                                    return state.ThumbSticks.Left.Y > condition.CompareValue;
                            }
                            break;
                        case ThumbStick.Right:
                            switch (condition.CoordsType)
                            {
                                case Coords.X:
                                    return state.ThumbSticks.Right.X > condition.CompareValue;
                                case Coords.Y:
                                    return state.ThumbSticks.Right.Y > condition.CompareValue;
                            }
                            break;
                    }
                    break;
                case Operator.GreaterThanOrEqualTo:
                    switch (condition.ThumbStick)
                    {
                        case ThumbStick.Left:
                            switch (condition.CoordsType)
                            {
                                case Coords.X:
                                    return state.ThumbSticks.Left.X >= condition.CompareValue;
                                case Coords.Y:
                                    return state.ThumbSticks.Left.Y >= condition.CompareValue;
                            }
                            break;
                        case ThumbStick.Right:
                            switch (condition.CoordsType)
                            {
                                case Coords.X:
                                    return state.ThumbSticks.Right.X >= condition.CompareValue;
                                case Coords.Y:
                                    return state.ThumbSticks.Right.Y >= condition.CompareValue;
                            }
                            break;
                    }
                    break;
                case Operator.LessThan:
                    switch (condition.ThumbStick)
                    {
                        case ThumbStick.Left:
                            switch (condition.CoordsType)
                            {
                                case Coords.X:
                                    return state.ThumbSticks.Left.X < condition.CompareValue;
                                case Coords.Y:
                                    return state.ThumbSticks.Left.Y < condition.CompareValue;
                            }
                            break;
                        case ThumbStick.Right:
                            switch (condition.CoordsType)
                            {
                                case Coords.X:
                                    return state.ThumbSticks.Right.X < condition.CompareValue;
                                case Coords.Y:
                                    return state.ThumbSticks.Right.Y < condition.CompareValue;
                            }
                            break;
                    }
                    break;
                case Operator.LessThanOrEqualTo:
                    switch (condition.ThumbStick)
                    {
                        case ThumbStick.Left:
                            switch (condition.CoordsType)
                            {
                                case Coords.X:
                                    return state.ThumbSticks.Left.X <= condition.CompareValue;
                                case Coords.Y:
                                    return state.ThumbSticks.Left.Y <= condition.CompareValue;
                            }
                            break;
                        case ThumbStick.Right:
                            switch (condition.CoordsType)
                            {
                                case Coords.X:
                                    return state.ThumbSticks.Right.X <= condition.CompareValue;
                                case Coords.Y:
                                    return state.ThumbSticks.Right.Y <= condition.CompareValue;
                            }
                            break;
                    }
                    break;
            }

            return null;
        }

        private static bool? EvaluateGamePadTriggerCondition(GamePadTriggerCondition condition, GamePadState state)
        {
            switch (condition.Operator)
            {
                case Operator.Equal:
                    switch (condition.Trigger)
                    {
                        case Trigger.Left:
                            return state.Triggers.Left == condition.CompareValue;
                        case Trigger.Right:
                            return state.Triggers.Right == condition.CompareValue;
                    }
                    break;
                case Operator.NotEqual:
                    switch (condition.Trigger)
                    {
                        case Trigger.Left:
                            return state.Triggers.Left != condition.CompareValue;
                        case Trigger.Right:
                            return state.Triggers.Right != condition.CompareValue;
                    }
                    break;
                case Operator.GreaterThan:
                    switch (condition.Trigger)
                    {
                        case Trigger.Left:
                            return state.Triggers.Left > condition.CompareValue;
                        case Trigger.Right:
                            return state.Triggers.Right > condition.CompareValue;
                    }
                    break;
                case Operator.GreaterThanOrEqualTo:
                    switch (condition.Trigger)
                    {
                        case Trigger.Left:
                            return state.Triggers.Left >= condition.CompareValue;
                        case Trigger.Right:
                            return state.Triggers.Right >= condition.CompareValue;
                    }
                    switch (condition.Trigger)
                    {
                        case Trigger.Left:
                            return state.Triggers.Left >= condition.CompareValue;
                        case Trigger.Right:
                            return state.Triggers.Right >= condition.CompareValue;
                    }
                    break;
                case Operator.LessThan:
                    switch (condition.Trigger)
                    {
                        case Trigger.Left:
                            return state.Triggers.Left < condition.CompareValue;
                        case Trigger.Right:
                            return state.Triggers.Right < condition.CompareValue;
                    }
                    break;
                case Operator.LessThanOrEqualTo:
                    switch (condition.Trigger)
                    {
                        case Trigger.Left:
                            return state.Triggers.Left <= condition.CompareValue;
                        case Trigger.Right:
                            return state.Triggers.Right <= condition.CompareValue;
                    }
                    break;
            }
            return null;
        }
        #endregion
        #region Mouse
        private static bool? EvaluateMouseButtonCondition(MouseButtonCondition condition, MouseState state)
        {
            switch (condition.Operator)
            {
                case Operator.Equal:
                    switch (condition.MouseButton)
                    {
                        case MouseButton.Left:
                            switch (condition.ButtonState)
                            {
                                case ButtonState.Pressed:
                                    return state.LeftButton == ButtonState.Pressed;
                                case ButtonState.Released:
                                    return state.LeftButton == ButtonState.Released;
                            }
                            break;
                        case MouseButton.Right:
                            switch (condition.ButtonState)
                            {
                                case ButtonState.Pressed:
                                    return state.RightButton == ButtonState.Pressed;
                                case ButtonState.Released:
                                    return state.RightButton == ButtonState.Released;
                            }
                            break;
                    }
                    break;
                case Operator.NotEqual:
                    switch (condition.MouseButton)
                    {
                        case MouseButton.Left:
                            switch (condition.ButtonState)
                            {
                                case ButtonState.Pressed:
                                    return state.LeftButton != ButtonState.Pressed;
                                case ButtonState.Released:
                                    return state.LeftButton != ButtonState.Released;
                            }
                            break;
                        case MouseButton.Right:
                            switch (condition.ButtonState)
                            {
                                case ButtonState.Pressed:
                                    return state.RightButton != ButtonState.Pressed;
                                case ButtonState.Released:
                                    return state.RightButton != ButtonState.Released;
                            }
                            break;
                    }
                    break;
            }
            return null;
        }

        private static bool? EvaluateMousePositionCondition(MousePositionCondition condition, MouseState state)
        {
            switch (condition.Operator)
            {
                case Operator.Equal:
                    switch (condition.CoordType)
                    {
                        case Coords.X:
                            return state.X == condition.CompareValue;
                        case Coords.Y:
                            return state.Y == condition.CompareValue;
                    }
                    break;
                case Operator.NotEqual:
                    switch (condition.CoordType)
                    {
                        case Coords.X:
                            return state.X != condition.CompareValue;
                        case Coords.Y:
                            return state.Y != condition.CompareValue;
                    }
                    break;
                case Operator.GreaterThan:
                    switch (condition.CoordType)
                    {
                        case Coords.X:
                            return state.X > condition.CompareValue;
                        case Coords.Y:
                            return state.Y > condition.CompareValue;
                    }
                    break;
                case Operator.GreaterThanOrEqualTo:
                    switch (condition.CoordType)
                    {
                        case Coords.X:
                            return state.X >= condition.CompareValue;
                        case Coords.Y:
                            return state.Y >= condition.CompareValue;
                    }
                    break;
                case Operator.LessThan:
                    switch (condition.CoordType)
                    {
                        case Coords.X:
                            return state.X < condition.CompareValue;
                        case Coords.Y:
                            return state.Y < condition.CompareValue;
                    }
                    break;
                case Operator.LessThanOrEqualTo:
                    switch (condition.CoordType)
                    {
                        case Coords.X:
                            return state.X <= condition.CompareValue;
                        case Coords.Y:
                            return state.Y <= condition.CompareValue;
                    }
                    break;
            }
            return null;
        }
        #endregion
        #region Keyboard

        private static bool? EvaluateKeyboardCondition(KeyboardCondition condition, KeyboardState state)
        {
            switch (condition.Operator)
            {
                case Operator.Equal:
                    switch (condition.KeyState)
                    {
                        case KeyState.Down:
                            return state.IsKeyDown(condition.Key);
                        case KeyState.Up:
                            return state.IsKeyUp(condition.Key);
                    }
                    break;
                case Operator.NotEqual:
                    switch (condition.KeyState)
                    {
                        case KeyState.Down:
                            return !(state.IsKeyDown(condition.Key));
                        case KeyState.Up:
                            return !(state.IsKeyUp(condition.Key));
                    }
                    break;
            }

            return null;
        }
        #endregion
        #endregion
    }
}
