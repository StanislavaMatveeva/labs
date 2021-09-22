using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Counter
{
	public enum Result
	{
		DIVISION_ERROR = 1,
		GETTING_SQUARE_ERROR = 2,
		NO_ERROR = 3,
		VALUE_ERROR = 4
	};

	public class Counter
	{
		public Counter()
		{}

		Stack<string> result = new Stack<string>();
		public Result error = new Result();
		public double memoryValue = 0;
		public double res = 0;
		double secondValue = 0;
		double firstValue = 0;

		public Result Calculate(ref string rec, string op)
		{
			string symb = "";
			error = Result.NO_ERROR;
			if (result.Count() >= 2)
			{
				result.Push(rec);
				try
				{
					firstValue = Convert.ToDouble(result.Pop());
				}
				catch
				{
					return Result.VALUE_ERROR;
				}
				symb = result.Pop();
				try
				{
					secondValue = Convert.ToDouble(result.Pop());
				}
				catch
				{
					return Result.VALUE_ERROR;
				}
				switch (symb)
				{
					case "+":
						res = secondValue + firstValue;
						error = Result.NO_ERROR;
						break;
					case "-":
						res = secondValue - firstValue;
						error = Result.NO_ERROR;
						break;
					case "*":
						res = secondValue * firstValue;
						error = Result.NO_ERROR;
						break;
					case ":":
						error = Division();
						break;
					case "%":
						res = firstValue / 100;
						error = Result.NO_ERROR;
						break;
					case "sq":
						error = Square();
						break;
				}
				rec = res.ToString();
				result.Clear();
			}
			result.Push(rec);
			result.Push(op);
			rec = "";
			return error;
		}

		public Result Division()
		{
			if (firstValue != 0)
			{
				res = secondValue / firstValue;
				return Result.NO_ERROR;
			}
			else
				return Result.DIVISION_ERROR;
		}

		public Result GettingProc()
		{
			res = firstValue / 100;
			return Result.NO_ERROR;
		}
		public Result Square()
        {
			if (secondValue >= 0)
			{
				res = Math.Sqrt(secondValue);
				return Result.NO_ERROR;
			}
			else
				return Result.GETTING_SQUARE_ERROR;
		}

		public Result DeleteSymbol(ref string rec)
        {
			double value = 0;
            try
            {
				value = Convert.ToDouble(rec);
            }
            catch
            {
				return Result.VALUE_ERROR;
            }
			int newValue = (int)value / 10;
			result.Clear();
			result.Push(newValue.ToString());
			rec = newValue.ToString();
			return Result.NO_ERROR;
        }

		public void ClearValue(ref string rec)
        {
			result.Clear();
			rec = "";
        }

		public void ClearMemory()
        {
			memoryValue = 0;
        }

		public Result MemoryPlus(string rec)
        {
			error = Result.NO_ERROR;
            try
            {
				memoryValue += Convert.ToDouble(rec);
            }
			catch
            {
				return Result.VALUE_ERROR;
            }
			return error;
        }

		public Result MemoryMinus(string rec)
        {
			error = Result.NO_ERROR;
			try
			{
				memoryValue -= Convert.ToDouble(rec);
			}
			catch
			{
				return Result.VALUE_ERROR;
			}
			return error;
		}
	}
}


