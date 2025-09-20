using System;
using UnityEngine;

namespace NamPhuThuy.IsThirteen
{
    public class IsThirteen
    {
        private float _value;
        private bool _isRoughly;
        private float _tolerance = 0.5f;

        private IsThirteen(float value)
        {
            _value = value;
        }

        public static IsThirteen Is(float number)
        {
            return new IsThirteen(number);
        }

        // Basic thirteen check
        public bool Thirteen()
        {
            if (_isRoughly)
                return Mathf.Abs(_value - 13f) <= _tolerance;
            
            return Mathf.Approximately(_value, 13f);
        }

        // Roughly modifier
        public IsThirteen Roughly
        {
            get
            {
                _isRoughly = true;
                return this;
            }
        }

        // Within distance check
        public IsThirteenWithin Within(float distance)
        {
            return new IsThirteenWithin(_value, distance);
        }

        // Math operations
        public IsThirteen Plus(float addend)
        {
            _value += addend;
            return this;
        }

        public IsThirteen Minus(float subtrahend)
        {
            _value -= subtrahend;
            return this;
        }

        public IsThirteen Times(float multiplier)
        {
            _value *= multiplier;
            return this;
        }

        public IsThirteen DivideBy(float divisor)
        {
            if (Mathf.Approximately(divisor, 0f))
                throw new DivideByZeroException("Cannot divide by zero");
            
            _value /= divisor;
            return this;
        }

        // Special year check (age would be 13 in 2024)
        public bool YearOfBirth()
        {
            int currentYear = DateTime.Now.Year;
            int age = currentYear - (int)_value;
            return age == 13;
        }

        // Static convenience method
        public static bool IsThirteenNumber(float number)
        {
            return Mathf.Approximately(number, 13f);
        }
    }

    public class IsThirteenWithin
    {
        private float _value;
        private float _distance;

        public IsThirteenWithin(float value, float distance)
        {
            _value = value;
            _distance = distance;
        }

        public IsThirteenOf Of => new IsThirteenOf(_value, _distance);
    }

    public class IsThirteenOf
    {
        private float _value;
        private float _distance;

        public IsThirteenOf(float value, float distance)
        {
            _value = value;
            _distance = distance;
        }

        public bool Thirteen()
        {
            return Mathf.Abs(_value - 13f) <= _distance;
        }
    }

    // Extension methods for cleaner syntax
    public static class IsThirteenExtensions
    {
        public static IsThirteen Is(this int number)
        {
            return IsThirteen.Is(number);
        }

        public static IsThirteen Is(this float number)
        {
            return IsThirteen.Is(number);
        }
    }
}