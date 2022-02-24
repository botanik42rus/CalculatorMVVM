using System;

namespace CalculatorMVVM
{
    /// <summary>
    /// Класс, реализующий функции вычисления
    /// </summary>
    class Model
    {
        /// <summary>
        /// Переменная левого операнда
        /// </summary>
        public string LeftOperand { get; set; }

        /// <summary>
        /// Переменная правого операнда
        /// </summary>
        public string RightOperand { get; set; }

        /// <summary>
        /// Переменная типа операции
        /// </summary>
        public string Operation { get; set; }

        /// <summary>
        /// Переменная результата выполненной операции
        /// </summary>
        public string ResultOperation { get; set; }

        public Model()
        {
            LeftOperand = RightOperand = Operation = ResultOperation = string.Empty;
        }

        /// <summary>
        /// Метод производящий вычисления сложения или вычитания
        /// </summary>
        public void Calculate()
        {
            switch (Operation)
            {
                case "+":
                    ResultOperation = (Double.Parse(LeftOperand) + Double.Parse(RightOperand)).ToString();
                    break;
                case "-":
                    ResultOperation = (Double.Parse(LeftOperand) - Double.Parse(RightOperand)).ToString();
                    break;
            }
        }
    }
}
