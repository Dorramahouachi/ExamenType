﻿using Data.Infrastructure;
using Domaine;
using MyFinance.Data.Infrastructure;
using Services.Interfaces;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : Service<User>, IUserService
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        public UserService()
           : base(ut)
        {



        }
    }
}