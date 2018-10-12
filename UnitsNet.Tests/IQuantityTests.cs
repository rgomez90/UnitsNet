using System;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{
   public class IQuantityTests
    {
        private static Pressure pressureSrc = new Pressure(1, PressureUnit.Bar);
        private static Pressure pressureToAdd = new Pressure(1, PressureUnit.Bar);

        [Fact]
        public static void AddingNewPressureReturnsCorrectValue()
        {
            IQuantity<Pressure> p = pressureSrc;
            var result = p.Add(pressureToAdd);
            Assert.Equal(2, result.Bars);
        }

        [Fact]
        public static void MultiplyPressureByScalarReturnsCorrectValue()
        {
            IQuantity<Pressure> p = pressureSrc;
            var result = p.Multiply(2);
            Assert.Equal(2, result.Bars);
        }

        [Fact]
        public static void DividePressureByPositiveValueReturnsCorrectValue()
        {
            IQuantity<Pressure> p = pressureSrc;
            var result = p.Divide(2);
            Assert.Equal(0.5, result.Bars);
        }

        [Fact]
        public static void DividePressureByZeroValueReturnsException()
        {
            IQuantity<Pressure> p = pressureSrc;
            Assert.Throws<ArgumentException>(()=>p.Divide(-0));
        }

        [Fact]
        public static void DividePressureByNegativeValueReturnsException()
        {
            IQuantity<Pressure> p = pressureSrc;
            Assert.Throws<ArgumentException>(()=>p.Divide(-2));
        }

        [Fact]
        public static void DividePressureByPressureReturnsCorrectFactor()
        {
            IQuantity<Temperature> p = new Temperature(20,TemperatureUnit.DegreeCelsius);
            IQuantity<Temperature> p2 = new Temperature(40,TemperatureUnit.DegreeCelsius);
            Assert.Equal(1d, p.Divide(p2));
        }
    }
}
