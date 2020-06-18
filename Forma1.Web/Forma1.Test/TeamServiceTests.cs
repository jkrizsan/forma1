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
        TeamService TeamService;
        int TestInt = 1;
        int TestYear = 2010;
        string TestString = "test";
        string TestString2 = "test2";

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<Context>()
                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                      .Options;
            var context = new Context(options);
            TeamService = new TeamService(context);
        }

        [Test]
        public void AddTest()
        {
            TeamService.Add(new Team()
            { 
                Name = TestString,
                NumberOfWonWorldChampionship = TestInt,
                YearOfFoundation = TestYear,
                PaidEntryFee = true 
            });

            var team = TeamService.GetById(1);

            Assert.AreEqual(team.Name, TestString);
            Assert.AreEqual(team.NumberOfWonWorldChampionship, TestInt);
            Assert.AreEqual(team.YearOfFoundation, TestYear);
        }

        [Test]
        public void GetAllTest()
        {
            TeamService.Add(new Team()
            {
                Name = TestString,
                NumberOfWonWorldChampionship = TestInt,
                YearOfFoundation = TestYear,
                PaidEntryFee = true
            });

            TeamService.Add(new Team()
            {
                Name = TestString,
                NumberOfWonWorldChampionship = TestInt,
                YearOfFoundation = TestYear,
                PaidEntryFee = true
            });

            var teams = TeamService.GetAll();

            Assert.AreEqual(teams.Count(), 2);
            
        }

        [Test]
        public void RemoveTest()
        {
            TeamService.Add(new Team()
            {
                Name = TestString,
                NumberOfWonWorldChampionship = TestInt,
                YearOfFoundation = TestYear,
                PaidEntryFee = true
            });

            TeamService.RemoveById(1);

            var team = TeamService.GetById(1);

            Assert.IsNull(team);
        }

        [Test]
        public void UpdateTest()
        {
            var team = new Team()
            {
                Name = TestString,
                NumberOfWonWorldChampionship = TestInt,
                YearOfFoundation = TestYear,
                PaidEntryFee = true
            };

            TeamService.Add(team);

            team.Name = TestString2;

            TeamService.Update(team);

            TeamService.Update(team);

            var team2 = TeamService.GetById(1);

            Assert.AreEqual(team2.Name, TestString2);
        }

    }
}