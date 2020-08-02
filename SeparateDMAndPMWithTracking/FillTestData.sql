use SepparateDMandPM_Db

insert into dbo.[Publisher] (Id, [Name]) values ('6679C0E9-1C2C-4F99-9EB1-ED892225176B', 'John')
insert into dbo.[Publisher] (Id, [Name]) values ('F3739160-86E1-4078-83C8-14092F56C9EC', 'Kelly')

insert into dbo.[SocialAccount] (Id, [Email], [AccountType]) values ('F02CAF57-A66C-4817-9285-708DB850137F', 'anthony@hotmail.com', 0)
insert into dbo.[SocialAccount] (Id, [Email], [AccountType]) values ('103796DD-BDED-4E4C-8620-3C324047055B', 'juile@microsoft.us', 1)
insert into dbo.[SocialAccount] (Id, [Email], [AccountType]) values ('C7D2BF7D-0541-4C46-AA82-6FF39601F4A5', 'greg@apple.uk', 0)

insert into dbo.[PublisherAccount] (PublisherId, SocialAccountId) values ('6679C0E9-1C2C-4F99-9EB1-ED892225176B', 'F02CAF57-A66C-4817-9285-708DB850137F')
insert into dbo.[PublisherAccount] (PublisherId, SocialAccountId) values ('6679C0E9-1C2C-4F99-9EB1-ED892225176B', '103796DD-BDED-4E4C-8620-3C324047055B')
insert into dbo.[PublisherAccount] (PublisherId, SocialAccountId) values ('F3739160-86E1-4078-83C8-14092F56C9EC', 'C7D2BF7D-0541-4C46-AA82-6FF39601F4A5')
