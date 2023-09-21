using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace WebAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        //api/calculator/add?a=10&b=15
        [HttpGet("Calculator/add")]
        public int Add(int a , int b) { return a+b; }
        [HttpGet("/Sum")]
        public int Sum(int a, int b) { return a + b + 1000; }

        //api/calculator/Subtract? a = 100 & b = 15
        [HttpPost("/Subtract")]
        public int Subtract(int a, in int b) { return a - b; }
        //api/calculator/Multiply?a=100&b=15
        [HttpPut]
        public int Multiply(int a, in int b) { return a * b; }
        //api/calculator/Divide?a=100&b=15
        [HttpDelete]
        public decimal Divide(decimal a, decimal b) { return a / b; }

    }
}
