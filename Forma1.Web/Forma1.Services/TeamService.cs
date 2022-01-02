using System;
using System.Collections.Generic;
using System.Linq;
using Forma1.Data;
using Forma1.Data.Models;

namespace Forma1.Services
{
    /// <summary>
    /// Team Service
    /// </summary>
    public class TeamService : ITeamService
    {
        private Context _context;

        public TeamService(Context context)
        {
            _context = context;
        }

        ///<inheritdoc/>
        public void Add(Team team)
        {
            if (team is null)
            {
                throw new ArgumentNullException(nameof(Add));
            }

            _context.Teams.Add(team);
            _context.SaveChanges();
        }

        ///<inheritdoc/>
        public IEnumerable<Team> GetAll()
        {
            return _context.Teams.ToList();
        }

        ///<inheritdoc/>
        public Team GetById(int id)
        {
            var team = _context.Teams.Where(t => t.Id.Equals(id)).SingleOrDefault();
            return team;
        }

        ///<inheritdoc/>
        public void RemoveById(int id)
        {
            var team = GetById(id);
            _context.Teams.Remove(team);
            _context.SaveChanges();
        }

        ///<inheritdoc/>
        public void Update(Team team)
        {
            _context.Teams.Update(team);
            _context.SaveChanges();
        }
    }
}
