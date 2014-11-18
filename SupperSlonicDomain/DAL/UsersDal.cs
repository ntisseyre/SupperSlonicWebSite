﻿using SupperSlonicDomain.Models.Account;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SupperSlonicDomain.DAL
{
    class UsersDal : IUsersDal
    {
        public UserDb GetUser(SqlTransaction transaction, int userId)
        {
            using (var cmd = new SqlCommand("[dbo].[spGetUserById]", transaction.Connection, transaction))
            {
                cmd.Parameters.AddWithValue("userId", userId);
                cmd.CommandType = CommandType.StoredProcedure;

                return GetSingleUser(cmd);
            }
        }

        public UserDb GetUser(SqlTransaction transaction, string email)
        {
            using (var cmd = new SqlCommand("[dbo].[spGetUserByEmail]", transaction.Connection, transaction))
            {
                cmd.Parameters.AddWithValue("email", email);
                cmd.CommandType = CommandType.StoredProcedure;

                return GetSingleUser(cmd);
            }
        }

        public UserDb GetUser(SqlTransaction transaction, ExternalLoginProvider loginProvider, string providerKey)
        {
            using (var cmd = new SqlCommand("[dbo].[spGetExternalUser]", transaction.Connection, transaction))
            {
                cmd.Parameters.AddWithValue("providerId", loginProvider);
                cmd.Parameters.AddWithValue("providerKey", providerKey);
                cmd.CommandType = CommandType.StoredProcedure;

                return GetSingleUser(cmd);
            }
        }

        public byte[] GetAvatar(SqlTransaction transaction, int userId)
        {
            using (var cmd = new SqlCommand("[dbo].[spGetUserAvatar]", transaction.Connection, transaction))
            {
                cmd.Parameters.AddWithValue("userId", userId);
                cmd.CommandType = CommandType.StoredProcedure;

                return Helper.GetObjectOrNull<byte[]>(cmd.ExecuteScalar());
            }
        }

        public UserDb CreateUser(SqlTransaction transaction, UserRegistration userRegistration)
        {
            using (var cmd = new SqlCommand("[dbo].[spCreateUser]", transaction.Connection, transaction))
            {
                var createdDate = DateTime.Now;
                var verifyEmailCode = Guid.NewGuid();

                cmd.Parameters.AddWithValue("email", userRegistration.Email);
                cmd.Parameters.AddWithValue("password", Helper.ToSqlNullable(userRegistration.Password));
                cmd.Parameters.AddWithValue("fullName", Helper.ToSqlNullable(userRegistration.FullName));
                cmd.Parameters.AddWithValue("createdDate", createdDate);
                cmd.Parameters.AddWithValue("updatedDate", createdDate);
                cmd.Parameters.AddWithValue("verifyEmailCode", verifyEmailCode);
                cmd.CommandType = CommandType.StoredProcedure;

                return GetSingleUser(cmd);
            }
        }

        public void CreateUserExtLoginInfo(SqlTransaction transaction, int userId, ExternalLoginInfo externalLoginInfo)
        {
            using (var cmd = new SqlCommand("[dbo].[spCreateUserExtLogin]", transaction.Connection, transaction))
            {
                cmd.Parameters.AddWithValue("userId", userId);
                cmd.Parameters.AddWithValue("providerId", externalLoginInfo.ProviderType);
                cmd.Parameters.AddWithValue("providerKey", externalLoginInfo.ProviderKey);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
            }
        }

        public void CreateUserAvatar(SqlTransaction transaction, int userId, byte[] avatar)
        {
            using (var cmd = new SqlCommand("[dbo].[spCreateUserAvatar]", transaction.Connection, transaction))
            {
                cmd.Parameters.AddWithValue("userId", userId);
                cmd.Parameters.AddWithValue("avatar", avatar);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
            }
        }

        public UserDb UpdateUser(SqlTransaction transaction, UserDb user)
        {
            using (var cmd = new SqlCommand("[dbo].[spUpdateUser]", transaction.Connection, transaction))
            {
                var updatedDate = DateTime.Now;

                cmd.Parameters.AddWithValue("userId", user.Id);
                cmd.Parameters.AddWithValue("password", Helper.ToSqlNullable(user.Password));
                cmd.Parameters.AddWithValue("fullName", Helper.ToSqlNullable(user.FullName));
                cmd.Parameters.AddWithValue("updatedDate", updatedDate);
                cmd.Parameters.AddWithValue("verifyEmailCode", Helper.ToSqlNullable(user.VerifyEmailCode));
                cmd.CommandType = CommandType.StoredProcedure;

                return GetSingleUser(cmd);
            }
        }

        public void UpdateUserAvatar(SqlTransaction transaction, int userId, byte[] avatar)
        {
            using (var cmd = new SqlCommand("[dbo].[spUpdateUserAvatar]", transaction.Connection, transaction))
            {
                cmd.Parameters.AddWithValue("userId", userId);
                cmd.Parameters.AddWithValue("avatar", avatar);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteUserWithDependencies(SqlTransaction transaction, int userId)
        {
            using (var cmd = new SqlCommand("[dbo].[spDeleteUserWithDependencies]", transaction.Connection, transaction))
            {
                cmd.Parameters.AddWithValue("userId", userId);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
            }
        }

        private static UserDb GetSingleUser(SqlCommand cmd)
        {
            using (var sqlDataReader = cmd.ExecuteReader())
            {
                var users = MapUsersFromDb(sqlDataReader);
                return users.SingleOrDefault();
            }
        }

        private static IList<UserDb> MapUsersFromDb(SqlDataReader sqlDataReader)
        {
            IList<UserDb> result = new List<UserDb>();

            while (sqlDataReader.Read())
            {
                int userId = (int)sqlDataReader["Id"];
                Guid? verifyEmailCode = sqlDataReader.GetValueOrNull<Guid>("VerifyEmailCode");

                var user = new UserDb()
                {
                    Id = userId,
                    Email = (string)sqlDataReader["Email"],
                    Password = sqlDataReader.GetObjectOrNull<string>("Password"),
                    FullName = sqlDataReader.GetObjectOrNull<string>("FullName"),
                    CreatedDate = (DateTime)sqlDataReader["CreatedDate"],
                    TimeStamp = (DateTime)sqlDataReader["UpdatedDate"],
                    VerifyEmailCode = verifyEmailCode,
                    IsVerified = !verifyEmailCode.HasValue
                };

                result.Add(user);
            }

            return result;
        }
    }
}
