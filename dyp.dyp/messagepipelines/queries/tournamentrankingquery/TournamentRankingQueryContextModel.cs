﻿using dyp.messagehandling.pipeline.messagecontext;
using System.Collections.Generic;

namespace dyp.dyp.messagepipelines.queries.tournamentrankingquery
{
    public class TournamentRankingQueryContextModel : IMessageContext
    {
        public class Player
        {
            public string Id;
            public string Name;
        }

        public class Team
        {
            public string Player_one_id;
            public string Player_two_id;
            public int Sets;
        }

        public class Match
        {
            public string Id;
            public Team Home;
            public Team Away;
            public bool Drawn;
        }

        public class Options
        {
            public int Points;
            public int Points_drawn;
            public bool Drawn;
            public bool Walkover;
        }

        public List<Player> Players = new List<Player>();
        public List<Match> Matches = new List<Match>();
        public List<string> Walkover = new List<string>();
        public Options Tournament_options;
    }
}
