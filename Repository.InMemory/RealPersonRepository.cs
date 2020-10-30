﻿using Entities;
using Fakes;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.InMemory
{
    public class RealPersonRepository : IPersonRepository
    {
        private static List<Person> people;

        static RealPersonRepository()
        {
            PersonBuilder fk = new PersonBuilder("nl");
            fk.UseSeed(123);
            people = fk.Generate(50);
        }

        public bool Delete(int id)
        {
            Person tmp = people.FirstOrDefault(p => p.Id == id);
            if (tmp == null)
            {
                return false;
            }

            people.Remove(tmp);
            return true;
        }

        public IQueryable<Person> Get()
        {
            return people.AsQueryable();
        }

        public void Insert(Person person)
        {
            int maxId = people.Max(p => p.Id);
            person.Id = ++maxId;
            people.Add(person);
        }

        public bool Save()
        {
            return true;
        }

        public bool Update(Person person)
        {
            Person tmp = people.FirstOrDefault(p => p.Id == person.Id);
            if (tmp == null)
            {
                return false;
            }

            tmp.FirstName = person.FirstName;
            tmp.LastName = person.LastName;
            tmp.Age = person.Age;

            return true;
        }
    }
}
