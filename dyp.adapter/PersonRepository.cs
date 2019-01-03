using dyp.data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace dyp.adapter
{
    public class PersonRepository
    {
        private readonly string _db_path;
        private const string FOLDER = "persons";
        private const string FILENAME = "persons.json";

        private readonly string _path;

        public PersonRepository(string db_path)
        {
            _db_path = db_path;
            _path = Path.Combine(_db_path, FOLDER, FILENAME);

            if (!Directory.Exists(_path))
                Directory.CreateDirectory(Path.Combine(_db_path, FOLDER));
        }

        public IEnumerable<Person> Load()
        {
            if (File.Exists(_path))
            {
                var file_text = File.ReadAllText(_path);
                return JsonConvert.DeserializeObject<IEnumerable<Person>>(file_text);
            }
            else
                return new List<Person>();
        }

        public void Save(IEnumerable<Person> persons)
        {
            var file_text = JsonConvert.SerializeObject(persons);
            File.WriteAllText(_path, file_text);
        }
    }
}
