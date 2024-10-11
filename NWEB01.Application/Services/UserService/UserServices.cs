using AutoMapper;
using NWEB01.Application.DTOs;
using NWEB01.Domain.Entities;
using NWEB01.Domain.Interfaces;
using NWEB01.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWEB01.Application.Services.UserService
{
	public class UserServices : IUserService
	{

		private IUserRepository userRepository;
		private IMapper mapper;

		public UserServices(IUserRepository userRepository, IMapper mapper)
		{
			this.userRepository = userRepository;
			this.mapper = mapper;
		}

		public async Task<PaginationList<UserDTO>> GetUsers(UserSpeParam userSpeParam)
		{
			int skip = (userSpeParam.pageIndex - 1) * userSpeParam.pageSize;
			int take = userSpeParam.pageSize;

			var spec = new BaseSpecification<User>(x =>
				(string.IsNullOrEmpty(userSpeParam.Search) || x.Name.Contains(userSpeParam.Search)) &&
				(!userSpeParam.Role.HasValue || x.Role == userSpeParam.Role)
			);

			spec.ApplyPaging(take, skip);
			if(userSpeParam.IsDescending)
			{
				spec.AddOrderBy(x => x.Name);
			} else
			{
				spec.AddDescending(x => x.Name);
			}
			

			var userDomains = await userRepository.GetAll(spec);

			var result = mapper.Map<PaginationList<UserDTO>>(userDomains);
			return result;
		}
	}
}
