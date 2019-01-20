using dyp.contracts;
using dyp.data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace dyp.adapter
{
    public class PersonRepository : IPersonRepository
    {
        private const string FOLDER = "persons";
        private const string FILENAME = "persons.json";

        private readonly string _file_path;
        private readonly string _db_path;

        public PersonRepository(string db_path)
        {
            _db_path = db_path;
            _file_path = Path.Combine(_db_path, FOLDER, FILENAME);
            Initialize_person_file();
        }

        private void Initialize_person_file()
        {
            if (!File.Exists(_file_path) || File.ReadAllText(_file_path) == string.Empty)
            {
                Directory.CreateDirectory(Path.Combine(_db_path, FOLDER));
                File.WriteAllText(_file_path, "[]");
            }
        }

        public IEnumerable<Person> Load()
        {
             var file_text = File.ReadAllText(_file_path);
             return JsonConvert.DeserializeObject<IEnumerable<Person>>(file_text);
        }

        public IEnumerable<Person> Load(IEnumerable<Guid> ids)
        {
            var persons = Load();
            return persons.Where(person => ids.Contains(person.Id));
        }

        public void Save(IEnumerable<Person> persons)
        {
            var file_text = JsonConvert.SerializeObject(persons);
            File.WriteAllText(_file_path, file_text);
        }
    }
}
