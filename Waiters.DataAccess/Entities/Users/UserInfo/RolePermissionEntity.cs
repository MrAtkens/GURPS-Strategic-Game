﻿namespace DefaultTemplate.DataAccess.Entities.Users.UserInfo;

public class RolePermissionEntity
{
    public Guid RoleId { get; set; }
    public RoleEntity Role { get; set; }

    public string PermissionId { get; set; }
    public PermissionEntity Permission { get;set; }
}