

namespace CalculatorMVVM
{
    class ViewModel : BaseViewModel
    {
        #region Properties
        /// <summary>
        /// Объект класса модели
        /// </summary>
        Model calculation;

        /// <summary>
        /// Флаг, указывающий на наличие необходимости выполнить ещё одну операцию
        /// </summary>
        private bool DoNextOperation = false;

        /// <summary>
        /// Свойство для отображения вычислений
        /// </summary>
        public string MathDisplay
        {
            get
            {
                return mathDisplay;
            }
            set
            {
                mathDisplay = value;
                OnPropertyChanged("MathDisplay");
            }
        }
        private string mathDisplay;
        #endregion

        #region Constructor
        public ViewModel()
        {
            calculation = new Model();
            mathDisplay = "0";
        }
        #endregion

        #region Commands
        /// <summary>
        /// Комманда для работы числовых кнопок и кнопок очистки поля ввода
        /// </summary>
        public DelegateCommand ButtonNumberPressCommand
        {
            get
            {
                return buttonNumberPressCommand ?? (buttonNumberPressCommand = new DelegateCommand(obj =>
                {
                    switch ((string)obj)
                    {
                        case "Clear":
                            MathDisplay = "0";
                            break;
                        case "Del":
                            MathDisplay = mathDisplay.Length > 1 ? mathDisplay.Substring(0, mathDisplay.Length - 1) : "0";
                            break;
                        case ",":
                            if (!mathDisplay.Contains(","))
                            {
                                MathDisplay += ",";
                                DoNextOperation = false;
                            }
                            break;
                        default:
                            MathDisplay = (mathDisplay == "0" || DoNextOperation) ? MathDisplay = (string)obj : MathDisplay += (string)obj;
                            DoNextOperation = false;
                            break;
                    }
                }));
            }
        }
        private DelegateCommand buttonNumberPressCommand;


        /// <summary>
        /// Комманда для работы кнопок, связанных с вычислениями
        /// </summary>
        public DelegateCommand OperationPressCommand
        {
            get
            {
                return operationPressCommand ?? (operationPressCommand = new DelegateCommand(obj =>
                {

                    if (calculation.LeftOperand == string.Empty || calculation.Operation == "=")
                    {
                        calculation.LeftOperand = mathDisplay;
                        calculation.Operation = (string)obj;
                        MathDisplay = "0";
                    }
                    else
                    {
                        calculation.RightOperand = mathDisplay;
                        calculation.Calculate();

                        MathDisplay = calculation.ResultOperation;
                        calculation.LeftOperand = mathDisplay;
                        calculation.Operation = (string)obj;
                        DoNextOperation = true;
                    }
                }));
            }
        }
        private DelegateCommand operationPressCommand;
        #endregion
    }
}
