using Forma1.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forma1.Services
{
    interface ITeamService
    {
        void Add(Team team);
        void RemoveById(int id);
        void Update(Team team);

        Team GetById(int id);
        IEnumerable<Team> GetAll();
    }
}
