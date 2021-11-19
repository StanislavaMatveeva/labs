using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Management;
using System.Globalization;

namespace FileOperations
{
    public class InitialAge : IInitialAgesFiler
    {

        public string FileName { get; set; }
        
        public void CheckFile()
        {
            if (FileName == null)
                throw new Exception("Name of file with initial ages is empty");
            if (!File.Exists(FileName))
            {
                var createFile = new string[] { "New", "File" };
                File.WriteAllLines(FileName, createFile);
            }
            else if (new FileInfo(FileName).Extension != ".csv")
                throw new Exception("Wrong format of file");
            else
            {
                int memory = 0;
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
                ManagementObjectCollection results = searcher.Get();
                foreach (ManagementObject result in results)
                {
                    var obj = result["FreePhysicalMemory"];
                    memory += Convert.ToInt32(obj);
                    obj = result["FreeVirtualMemory"];
                    memory += Convert.ToInt32(obj);
                }
                if (new FileInfo(FileName).Length > memory)
                    throw new Exception("This file is too big");
            }
            try { var check = File.ReadAllLines(FileName); var str = check[0]; }
            catch { throw new Exception("This file is empty"); }
        }

        public int[] GetAgesFromInitialAgeFile(string[] data)
        {
            if (data == null)
                throw new Exception("This file is empty");
            var agesArray = new int[data.Length - 1];
            bool check;
            for (int i = 1; i < data.Length; i++)
            {
                var str = DeleteProbels(data[i]);
                var currValue = str.Split(',');
                check = int.TryParse(currValue[0], out agesArray[i - 1]);
                if (check == false)
                    throw new Exception("Invalid data in colomn of ages");
            }
            return agesArray;
        }

        public double[] GetAmount(string[] data)
        {
            if (data == null)
                throw new Exception("This file is empty");
            var amountArray = new double[data.Length - 1];
            for (int i = 1; i < data.Length; i++)
            {
                var str = DeleteProbels(data[i]);
                var currValue = str.Split(',');
                try { amountArray[i - 1] = double.Parse(currValue[1], new NumberFormatInfo { NumberDecimalSeparator = "." }); }
                catch { throw new Exception("Invalid data in colomn of amount per 1000"); }
            }
            return amountArray;
        }

        public string DeleteProbels(string s)
        {
            if (s == "")
                throw new Exception("This string is empty");
            else
            {
                var newString = s.Trim(' ');
                while (newString.Contains(" "))
                    newString = newString.Replace(" ", "");
                return newString;
            }
        }
        
        public string[] GetDataFromFile()
        {
            if (FileName == null)
                throw new Exception("Name of file with initial ages is empty");
            var data = File.ReadAllLines(FileName);
            CheckHeaders(data);
            return data;
        }
        
        public void CheckHeaders(string[] data)
        {
            string check;
            try { check = data[0]; }
            catch { throw new Exception("This file is empty"); }
            if (!check.Contains("Возраст, Количество_на_1000"))
                throw new Exception("This file doesn't contains necessary headers");
        }
    }
}
