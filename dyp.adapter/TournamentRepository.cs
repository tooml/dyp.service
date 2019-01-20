using dyp.contracts;
using dyp.data;
using Newtonsoft.Json;
using System.IO;

namespace dyp.adapter
{
    public class TournamentRepository : ITournamentRepository
    {
        private const string FOLDER = "turnier";

        private readonly string _file_path;
        private readonly string _db_path;

        public TournamentRepository(string db_path)
        {
            _db_path = db_path;
            _file_path = Path.Combine(_db_path, FOLDER);
            Initialize_turnier_file();
        }

        private void Initialize_turnier_file()
        {
            if (!File.Exists(_file_path))
                Directory.CreateDirectory(Path.Combine(_db_path, FOLDER));
        }

        public void Save(Tournament tournament)
        {
            var file_name = Get_file_name(tournament);
            var full_path = Path.Combine(_file_path, file_name);

            var file_text = JsonConvert.SerializeObject(tournament);
            File.WriteAllText(full_path, file_text);
        }

        private string Get_file_name(Tournament tournament)
        {
            return string.Concat("turnier_", tournament.Id, ".json");
        }
    }
}
