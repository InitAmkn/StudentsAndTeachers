using static System.Runtime.InteropServices.JavaScript.JSType;
using StudentsAndTeachers.Models;

namespace StudentsAndTeachers.FileReader
{
    public class Parser
    {
        public string[][] GetData(string data)
        {
            string[] dataArray = data
                                    .Replace("\t\t", "\t")
                                    .Replace("\t", ";")
                                    .Replace("\r", "")
                                    .Split("\n").ToArray();
           string[][] tableReturn = new string[dataArray.Length][];
            for (int i = 1; i < dataArray.Length; i++)
            {
                tableReturn[i] = dataArray[i].Split(";");

            }
            return tableReturn;
        }
    
       
    }
}
