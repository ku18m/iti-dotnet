using Newtonsoft.Json;
using Exceptions;

namespace ErrorsLog
{
    public static class Logger
    {
        private static string _path = @"D:\ITI\Repos\iti-dotnet\labs\C#\C# Advanced\lab_1\errors.json";

        private static List<SerializableException> _errors = Load();

        private static void Save()
        {
            string json = JsonConvert.SerializeObject(_errors);
            File.WriteAllText(_path, json);
        }

        public static List<SerializableException> Load()
        {
            if (File.Exists(_path))
            {
                string json = File.ReadAllText(_path);
                Console.WriteLine(json, "FileContent");

                return JsonConvert.DeserializeObject<List<SerializableException>>(json) ?? new List<SerializableException>();
            }
            else
            {
                Console.WriteLine("File Not exist");
                return new List<SerializableException>();
            }
        }

        public static void Log(SerializableException error)
        {
            _errors.Add(error);
            Save();
        }

        public static void Log(string message)
        {
            _errors.Add(new SerializableException(new BaseException(message)));
            Save();
        }

        public static void Log(Exception error)
        {
            _errors.Add(new SerializableException(new BaseException(error.Message)));
            Save();
        }

        public static List<SerializableException> GetErrors()
        {
            return _errors;
        }

        public static string GetErrorsAsString()
        {
            string json = JsonConvert.SerializeObject(_errors);
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
