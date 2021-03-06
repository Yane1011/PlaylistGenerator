﻿using PG.Services.DTOs;

namespace PG.Web.Models.Mappers
{
    public static class UserMapper
    {
        public static UserViewModel ToViewModel(this UserDTO userDTO)
        {
            return new UserViewModel()
            {
                Id = userDTO.Id,
                Name = userDTO.UserName,
                Token = userDTO.Token
            };
        }

        public static UserDTO ToDTO(this UserViewModel userViewModel)
        {
            return new UserDTO()
            {
                Id = userViewModel.Id,
                UserName = userViewModel.Name,
                Token = userViewModel.Token
            };
        }
    }
}
