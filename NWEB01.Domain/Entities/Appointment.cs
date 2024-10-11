﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWEB01.Domain.Entities
{
	public class Appointment
	{
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }
		public User Patient { get; set; }
		public User Doctor { get; set; }
       
    }
}
