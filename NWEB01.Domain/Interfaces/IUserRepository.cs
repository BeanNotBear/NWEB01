﻿using NWEB01.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWEB01.Domain.Interfaces
{
	// IBaseRepository<Object, Id>
	public interface IUserRepository : IBaseRepository<User, Guid>
	{
	}
}
