using Newtonsoft.Json;
using Exceptions;

namespace ErrorsLog
{
    public static class Logger
    {
        private static string _path = @"D:\ITI\Repos\iti-dotnet\labs\C#\C# Advanced\lab_1\errors.json";

        private static List<BaseException> _errors = Load();

        private static void Save()
        {
            string json = JsonConvert.SerializeObject(_errors);
            File.WriteAllText(_path, json);
        }

        public static List<BaseException> Load()
        {
            if (File.Exists(_path))
            {
                string json = File.ReadAllText(_path);
                Console.WriteLine(json);
                return JsonConvert.DeserializeObject<List<BaseException>>(json);
            }
            else
            {
                Console.WriteLine("File Not exist");
                return new List<BaseException>();
            }
        }

        public static void Log(BaseException error)
        {
            _errors.Add(error);
            Save();
        }

        public static void Log(string message)
        {
            _errors.Add(new BaseException(message));
            Save();
        }

        public static void Log(Exception error)
        {
            _errors.Add(new BaseException(error.Message));
            Save();
        }

        public static List<BaseException> GetErrors()
        {
            return _errors;
        }

        public static string GetErrorsAsString()
        {
            string json = JsonConvert.SerializeObject(_errors, Formatting.Indented);
            return json;
        }

        public static string GetPath()
        {
            return _path;
        }

        public static void SetPath(string path)
        {
            _path = path;
        }
    }
}
