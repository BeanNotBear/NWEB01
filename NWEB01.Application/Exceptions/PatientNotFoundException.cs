﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWEB01.Application.Exceptions
{
	public class PatientNotFoundException : NotFoundException
	{
		public PatientNotFoundException(string? message) : base(message)
		{
		}
	}
}
