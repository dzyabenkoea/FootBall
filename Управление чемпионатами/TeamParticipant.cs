using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football
{
    public class TeamParticipant
    {
        int id;
        string name;
        bool participates;

        public TeamParticipant(int id, string name, bool participates)
        {
            this.Id = id;
            this.Name = name;
            this.Participates = participates;
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public bool Participates
        {
            get { return participates; }
            set { participates = value; }
        }
    }
}
