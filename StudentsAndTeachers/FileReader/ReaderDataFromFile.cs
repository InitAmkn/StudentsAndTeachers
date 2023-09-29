
using System.IO;
using System.Reflection.PortableExecutable;

namespace StudentsAndTeachers.FileReader
{
    public class ReaderDataFromFile
    {
        public string GetData(string path)
        {
            //string text ="";
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Exception: " + e.Message);
            }
           
        }
        
    }

}
