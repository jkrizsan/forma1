using Forma1.Data.Models;
using System.Collections.Generic;

namespace Forma1.Services
{
    /// <summary>
    /// Interface of Team Service
    /// </summary>
    public interface ITeamService
    {
        /// <summary>
        /// Add a new Team
        /// </summary>
        /// <param name="team"></param>
        void Add(Team team);

        /// <summary>
        /// Remove Team by Id
        /// </summary>
        /// <param name="id"></param>
        void RemoveById(int id);

        /// <summary>
        /// Update a specific Team
        /// </summary>
        /// <param name="team"></param>
        void Update(Team team);

        /// <summary>
        /// Get Team nby Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Team GetById(int id);

        /// <summary>
        /// Return with all Teams
        /// </summary>
        /// <returns></returns>
        IEnumerable<Team> GetAll();
    }
}
