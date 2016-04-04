select * from AspNetRoles;
select * from AspNetUserRoles;
select * from AspNetUsers;

insert into AspNetRoles (Id, Name) values(1,'admin')
insert into AspNetRoles (Id,Name) values(2,'user')

insert into AspNetUserRoles (UserId,RoleId) values ('a96e9cda-3595-47c0-b412-6f93a33c246f',1);
insert into AspNetUserRoles (UserId,RoleId) values ('65e9b1c6-fe4b-4d96-82b7-f7f9bd7a5d67',1);
insert into AspNetUserRoles (UserId,RoleId) values ('354eb186-48a3-4420-bdec-d46bdcb6c6fd',2);
insert into AspNetUserRoles (UserId,RoleId) values ('1c2d0447-26c9-44ca-b9ed-b8bc0c92ee77',2);

