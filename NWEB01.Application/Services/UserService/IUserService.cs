using NWEB01.Application.DTOs;
using NWEB01.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWEB01.Application.Services.UserService
{
    public interface IUserService
	{
		public Task<PaginationList<UserDTO>> GetUsers(UserSpeParam userSpeParam);
	}
}
