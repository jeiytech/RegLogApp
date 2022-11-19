using System;
using System.Collections.Generic;
using System.Text;

namespace RegLogApp.Tables
{
    internal class RegUserTable
    {

        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public string UserPhoneNumber { get; set; }

        public string UserPassword { get; set; }
    }
}
