﻿using SupperSlonicDomain.Models.Account;
using System.Data.SqlClient;

namespace SupperSlonicDomain.DAL
{
    public interface IUsersDal
    {
        UserDb GetUser(SqlTransaction transaction, int userId);

        UserDb GetUser(SqlTransaction transaction, string email);

        UserDb GetUser(SqlTransaction transaction, ExternalLoginProvider loginProvider, string providerKey);

        byte[] GetAvatar(SqlTransaction transaction, int userId);

        UserDb CreateUser(SqlTransaction transaction, UserRegistration userRegistration);

        void CreateUserExtLoginInfo(SqlTransaction transaction, int userId, ExternalLoginInfo externalLoginInfo);

        void CreateUserAvatar(SqlTransaction transaction, int userId, byte[] avatar);

        UserDb UpdateUser(SqlTransaction transaction, UserDb user);

        void UpdateUserAvatar(SqlTransaction transaction, int userId, byte[] avatar);

        void DeleteUserWithDependencies(SqlTransaction transaction, int userId);
    }
}
