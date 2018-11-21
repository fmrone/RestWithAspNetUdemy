using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aula01.Controllers
{
    [Produces("application/json")]
    [Route("api/Calculator")]
    public class CalculatorController : Controller
    {
        // GET: api/calculator/sum/5/5
        [HttpGet("sum/{firstNumber}/{secondNumber}", Name = "Sum")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);

                return Ok(sum.ToString());
            }

            return BadRequest("Invalid input");
        }

        // GET: api/calculator/subtraction/5/5
        [HttpGet("subtraction/{firstNumber}/{secondNumber}", Name = "Subtraction")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);

                return Ok(sub.ToString());
            }

            return BadRequest("Invalid input");
        }

        // GET: api/calculator/multiplication/5/5
        [HttpGet("multiplication/{firstNumber}/{secondNumber}", Name = "Multiplication")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var multiplication = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);

                return Ok(multiplication.ToString());
            }

            return BadRequest("Invalid input");
        }

        // GET: api/calculator/division/5/5
        [HttpGet("division/{firstNumber}/{secondNumber}", Name = "Division")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var division = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);

                return Ok(division.ToString());
            }

            return BadRequest("Invalid input");
        }

        // GET: api/calculator/mean/5/5
        [HttpGet("mean/{firstNumber}/{secondNumber}", Name = "Mean")]
        public IActionResult Mean(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var mean = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber) / 2;

                return Ok(mean.ToString());
            }

            return BadRequest("Invalid input");
        }

        // GET: api/calculator/square-root/5
        [HttpGet("square-root/{number}", Name = "SquareRoot")]
        public IActionResult SquareRoot(string number)
        {
            if (IsNumeric(number))
            {
                var squareRoot = Math.Sqrt((double)ConvertToDecimal(number));

                return Ok(squareRoot.ToString());
            }

            return BadRequest("Invalid input");
        }

        private decimal ConvertToDecimal(string number)
        {
            decimal decimalValue;

            if (decimal.TryParse(number, out decimalValue))
                return decimalValue;
            return 0;
        }

        private bool IsNumeric(string number)
        {
            double doubleValue;

            bool isNumeric = double.TryParse(number, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out doubleValue);

            return isNumeric;
        }
    }
}
