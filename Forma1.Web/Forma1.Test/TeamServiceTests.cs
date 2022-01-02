using Forma1.Data;
using Forma1.Data.Models;
using Forma1.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;

namespace Forma1.Test
{
    public class Tests
    {
        TeamService _teamService;

        int _testInt = 1;
        int _testYear = 2010;
        string _testString = "test";
        string _testString2 = "test2";

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            var context = new Context(options);
            _teamService = new TeamService(context);
        }

        [Test]
        public void AddTest()
        {
            _teamService.Add(new Team()
            { 
                Name = _testString,
                NumberOfWonWorldChampionship = _testInt,
                YearOfFoundation = _testYear,
                PaidEntryFee = true 
            });

            var team = _teamService.GetById(1);

            Assert.AreEqual(team.Name, _testString);
            Assert.AreEqual(team.NumberOfWonWorldChampionship, _testInt);
            Assert.AreEqual(team.YearOfFoundation, _testYear);
        }

        [Test]
        public void GetAllTest()
        {
            _teamService.Add(new Team()
            {
                Name = _testString,
                NumberOfWonWorldChampionship = _testInt,
                YearOfFoundation = _testYear,
                PaidEntryFee = true
            });

            _teamService.Add(new Team()
            {
                Name = _testString,
                NumberOfWonWorldChampionship = _testInt,
                YearOfFoundation = _testYear,
                PaidEntryFee = true
            });

            var teams = _teamService.GetAll();

            Assert.AreEqual(teams.Count(), 2);
            
        }

        [Test]
        public void RemoveTest()
        {
            _teamService.Add(new Team()
            {
                Name = _testString,
                NumberOfWonWorldChampionship = _testInt,
                YearOfFoundation = _testYear,
                PaidEntryFee = true
            });

            _teamService.RemoveById(1);

            var team = _teamService.GetById(1);

            Assert.IsNull(team);
        }

        [Test]
        public void UpdateTest()
        {
            var team = new Team()
            {
                Name = _testString,
                NumberOfWonWorldChampionship = _testInt,
                YearOfFoundation = _testYear,
                PaidEntryFee = true
            };

            _teamService.Add(team);

            team.Name = _testString2;

            _teamService.Update(team);

            _teamService.Update(team);

            var team2 = _teamService.GetById(1);

            Assert.AreEqual(team2.Name, _testString2);
        }

    }
}