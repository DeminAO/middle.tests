﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using UserPermissionsTokenize.Domain.Entities;

namespace UserPermissionsTokenize.Domain;

public class TestDatabase(DbContextOptions<TestDatabase> options) : DbContext(options)
{
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<UserRole> UserRoles { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<RolePermission> RolePermissions { get; set; }
    public virtual DbSet<Permission> Permissions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        modelBuilder.ApplyConfiguration(new RolePermissionConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasOne(x => x.User).WithMany(x => x.UserRoles);
        builder.HasOne(x => x.Role).WithMany(x => x.UserRoles);
        builder.HasKey(x => new { x.RoleId, x.UserId });
    }
}
public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.HasOne(x => x.Role).WithMany(x => x.RolePermissions);
        builder.HasOne(x => x.Permission).WithMany(x => x.RolePermissions);
        builder.HasKey(x => new { x.RoleId, x.PermissionId });
    }
}