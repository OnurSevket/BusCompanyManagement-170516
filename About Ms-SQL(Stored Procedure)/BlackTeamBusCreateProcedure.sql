use BusManagementDb
go
--Address
begin try
drop procedure sp_GetAddressByID
end try
begin catch 
end catch
go
create procedure sp_GetAddressByID
  @id int
  as
  select ID,Name,City,District,EmployeeID from Address where ID=@id
  
go

begin try
drop procedure sp_GetAllAdress
end try
begin catch 
end catch
go
create procedure sp_GetAllAdress
  as
  select ID,Name,City,District,EmployeeID from Address
go

begin try
drop procedure sp_InsertAddress
end try
begin catch 
end catch
go
create procedure sp_InsertAddress
  @name nvarchar(50),
  @city int ,
  @district int,
  @employeeId int
  as
  begin
      insert into Address(Name,City,District,EmployeeID)values(@name,@city,@district,@employeeId)
  end
go

begin try
drop procedure sp_UpdateAddress
end try
begin catch 
end catch
go
create procedure sp_UpdateAddress
@name nvarchar(50),
@city int ,
@district int,
@employeeId int,
@id int
as
begin
   update Address set Name=@name,City=@city,District=@district,EmployeeID=@employeeId where ID=@id
end
go

begin try
drop procedure sp_DeleteAddress
end try
begin catch 
end catch
go
create procedure sp_DeleteAddress
@id int
as
begin
	delete from Address where ID=@id
end
--Authory
go
begin try
drop procedure sp_DeleteAuthory
end try
begin catch 
end catch
go
create proc sp_DeleteAuthory
@Id int
as
begin
delete from Authory where Authory.ID = @Id
end
go
begin try
drop procedure sp_GetAuthoryById
end try
begin catch 
end catch
go
 create proc sp_GetAuthoryById
  @Id int
  as
  begin
  select Authory.ID, Authory.AuthoryName from Authory where ID = @Id
  end
  go

begin try
drop procedure sp_GetAllAuthory
end try
begin catch 
end catch
go
 create proc sp_GetAllAuthory
 as
 begin
 select Authory.ID,AuthoryName  from Authory
 end
 go

begin try
drop procedure sp_AddAuthory
end try
begin catch 
end catch
go
 create proc sp_AddAuthory 
@authoryName nvarchar(50)
 as 
 begin
 Insert Authory(AuthoryName) values (@authoryName)
 end
 go
 begin try
drop procedure sp_UpdateAuthory
end try
begin catch 
end catch
go
create proc sp_UpdateAuthory
 @authoryName nvarchar(50),
 @id int
 as 
 begin
 update Authory set AuthoryName = @authoryName where ID=@id;
 end
 go

 --BUs
 go
  begin try
drop procedure sp_GetAllBus
end try
begin catch 
end catch
go
  create proc sp_GetAllBus
as
begin
select bus.ID,Bus.Brand,Bus.BusTypeID,Bus.Model, Bus.Plate, Bus.Year from Bus
end
go

 begin try
drop procedure sp_DeleteBus
end try
begin catch 
end catch
go
create proc sp_DeleteBus
@Id int
as
begin
 delete from Bus where Bus.ID = @Id
end
go
 begin try
drop procedure sp_GetBusById
end try
begin catch 
end catch
go
 create proc sp_GetBusById
@Id int
as
begin
select Bus.ID,Bus.Brand, Bus.BusTypeID, Bus.Model, Bus.Plate, Bus.Year from Bus where ID = @Id
end
go

 begin try
drop procedure sp_GetBusById
end try
begin catch 
end catch
go
 create proc sp_GetBusById
 as
 begin
 select bus.ID,Bus.Brand,Bus.BusTypeID,Bus.Model, Bus.Plate, Bus.Year from Bus
 end

 go
  begin try
drop procedure sp_AddBus
end try
begin catch 
end catch
go
 create proc sp_AddBus    
 @brand nvarchar(50),
 @model nvarchar(50),
 @year datetime,
 @busType int,
 @plate nchar(10)
  as 
  begin
  Insert Bus(Brand,Model,Year,BusTypeID,Plate) values (@brand,@model,@year,@busType,@plate)
  end 
 go
 begin try
drop procedure sp_UpdateBus
end try
begin catch 
end catch
go
 create proc sp_UpdateBus
 @brand nvarchar(50),
 @model nvarchar(50),
 @year datetime,
 @busType int,
 @plate nchar(10),
 @id int
 as
 begin
 update Bus set Brand = @brand, Model=@model,Year = @year, BusTypeID = @busType, Plate = @plate where ID=@id
 end
go
 --BusEmployee
begin try
drop procedure sp_DeleteBusEmployee
end try
begin catch 
end catch
go
create proc sp_DeleteBusEmployee
@Id int
as
begin
delete from BusEmployee where BusEmployee.ID = @Id
end
go
begin try
drop procedure sp_GetBusEmployee
end try
begin catch 
end catch

go
 create proc sp_GetBusEmployee
@Id int
as
begin
select BusEmployee.ID, BusEmployee.CreateDate,BusEmployee.BusID,BusEmployee.EmployeeID,BusEmployee.RouteMapID from BusEmployee where ID = @Id
end
go
begin try
drop procedure sp_GetAllBusEmployee
end try
begin catch 
end catch
go
 create proc sp_GetAllBusEmployee
 as
 begin
 select *from BusEmployee
 end
 go

 begin try
drop procedure sp_AddBusEmployee
end try
begin catch 
end catch
 go
 create proc sp_AddBusEmployee 
@busId int,
@employeeId int,
@createDate datetime,
@routeMapId int
 as 
 begin
 Insert into BusEmployee(BusID,EmployeeID,CreateDate,RouteMapID) values (@busId,@employeeId,@createDate,@routeMapId) 
 end

 go
 begin try
drop procedure sp_UpdateBusEmployee
end try
begin catch 
end catch
go
create proc sp_UpdateBusEmployee
@busId int,
@employeeId int,
@createDate datetime,
@routeMapID int,
@Id int
as 
begin
update BusEmployee set BusID=@busId,EmployeeID=@employeeId,CreateDate = @createDate,RouteMapID=@routeMapID where BusEmployee.ID = @Id 
end

go
--BusProperty
begin try
drop procedure sp_DeleteBusProperty
end try
begin catch 
end catch
go
create proc sp_DeleteBusProperty
@Id int
as
begin
delete from BusProperty where BusProperty.ID = @Id
end
go

begin try
drop procedure sp_GetBusPropertyById
end try
begin catch 
end catch
go
create proc sp_GetBusPropertyById
@Id int
as
begin
select BusProperty.ID,BusProperty.Name from BusProperty where ID = @Id
end
go
begin try
drop procedure sp_GetAllBusProperty
end try
begin catch 
end catch
go
create proc sp_GetAllBusProperty
as
 begin
 select *from BusProperty
 end
go
begin try
drop procedure sp_AddBusProperty
end try
begin catch 
end catch
go 
 create proc sp_AddBusProperty   

  @name nvarchar(50)
as 
begin
Insert BusProperty(Name) values (@name)  
end


go
begin try
drop procedure sp_UpdateBusProperty
end try
begin catch 
end catch
go
   create proc sp_UpdateBusProperty 
@name nvarchar(50),
@Id int
 as 
 begin
 update BusProperty  set BusProperty.Name = @name where BusProperty .ID = @Id 
 end
 go
 --BusSeat
 begin try
drop procedure sp_DeleteBusSeat
end try
begin catch 
end catch 
 go
  create proc sp_DeleteBusSeat
@Id int
as
begin
delete from BusSeat where BusSeat.ID = @Id
end
go

 begin try
drop procedure sp_GetBusSeat
end try
begin catch 
end catch 
go
create proc sp_GetBusSeat
 @Id int
 as
 begin
 select * from BusSeat where ID = @Id
 end

 go

  begin try
drop procedure sp_GetAllBusSeat
end try
begin catch 
end catch 
go
  create proc sp_GetAllBusSeat
 as
 begin
 select * from BusSeat
 end
 go

 begin try
drop procedure sp_AddBusSeat
end try
begin catch 
end catch
 go
 create proc sp_AddBusSeat
  @busId int,
  @BusTypeId int,
  @seatNumber int,
  @isWindow bit
as 
begin
Insert BusSeat(BusID,BusTypeID,SeatNumber,IsWindow) values (@busId,@BusTypeId,@seatNumber,@isWindow) 
end

go
begin try
drop procedure sp_UpdateBusSeat
end try
begin catch 
end catch
go
 create proc sp_UpdateBusSeat
 @busId int,
 @busTypeId int,
 @seatNumber int,
 @isWidow bit,
 @Id int
     as 
     begin
     update BusSeat set BusID=@busId,BusTypeID=@busTypeId,IsWindow = @isWidow, SeatNumber=@seatNumber where BusSeat.ID = @Id 
     end
go

--BusType
begin try
drop procedure sp_GetAllBusType
end try
begin catch 
end catch
go
 create proc sp_GetAllBusType
 as
begin
select * from BusType
end
go

begin try
drop procedure sp_DeleteBusType
end try
begin catch 
end catch
go
create proc sp_DeleteBusType
 @Id int
 as
 begin
 delete from BusType where BusType.ID = @Id
 end
 go


begin try
drop procedure sp_DeleteBusProperyBusTypeById
end try
begin catch 
end catch
go
create procedure sp_DeleteBusProperyBusTypeById
@busTypeID int
as
begin
	delete from BusPropertyBusType where BusTypeID=@busTypeID 
end
go
begin try
drop procedure sp_GetBusTypeById
end try
begin catch 
end catch
go
create proc sp_GetBusTypeById
 @Id int
 as
 begin
 select * from BusType where ID = @Id
 end
 go
begin try
drop procedure sp_AddBusType
end try
begin catch 
end catch
go
create proc sp_AddBusType 
@name nvarchar(50),
@backDoorIndex int,
@seatCount int
as 
begin
Insert BusType(BackDoorIndex,Name,SeatCount) values (@backDoorIndex,@name,@seatCount) 
SELECT SCOPE_IDENTITY()
end

go
begin try
drop procedure sp_AddBusProperyBusType
end try
begin catch 
end catch
go
create procedure sp_AddBusProperyBusType
 @busPropertyID int,
 @busTypeID int
 as
 begin 
 	insert into BusPropertyBusType(BusTypeID,BusPropertyID) values(@busTypeID,@busPropertyID)
 end
 go
 

 begin try
drop procedure sp_GetBusProperyBusTypeByID
end try
begin catch 
end catch
go
create procedure sp_GetBusProperyBusTypeByID
 @busTypeID int
 as
 begin 
 	select BusTypeID,BusPropertyID from  BusPropertyBusType  where BusTypeID=@busTypeID
 end
 

 go
begin try
drop procedure sp_UpdateBusType
end try
begin catch 
end catch
go
 create proc sp_UpdateBusType
 @name nvarchar(50) ,
 @Id int,
 @seatCount int,
 @backDoorIndex int
     as 
     begin
     update BusType set BackDoorIndex = @backDoorIndex, Name=@name, SeatCount = @seatCount where BusType.ID = @Id 
     end
go

begin try
drop procedure sp_DeleteBusProperyBusTypeById
end try
begin catch 
end catch
go
 create procedure sp_DeleteBusProperyBusTypeById
@busTypeID int
as
begin
	delete from BusPropertyBusType where BusTypeID=@busTypeID 
end
go

begin try
drop procedure sp_DeleteBusProperyBusTypeById
end try
begin catch 
end catch
go
create procedure sp_DeleteBusProperyBusTypeById
@busPropertyID int,
@busTypeID int
as
begin 
	insert into BusPropertyBusType(BusTypeID,BusPropertyID) values(@busTypeID,@busPropertyID)
end
go
------------------------------------------City------------------------------------------------------------
begin try
drop procedure sp_GetCityByID
end try
begin catch 
end catch
go
create procedure sp_GetCityByID
@id int
as
select ID,Name from City where ID=@id
go


begin try
drop procedure sp_GetAllCity
end try
begin catch 
end catch
go
create procedure sp_GetAllCity
 as
 select ID,Name from City
 go

begin try
drop procedure sp_InsertCity
end try
begin catch 
end catch
go
create procedure sp_InsertCity
@name nvarchar(50)
as
begin
    insert into City(Name)values(@name)
end
go
begin try
drop procedure sp_UpdateCity
end try
begin catch 
end catch

go
create procedure sp_UpdateCity
@name nvarchar(50),
@id int
as
begin
   update City set Name=@name where ID=@id
end
go
go
begin try
drop procedure sp_DeleteCity
end try
begin catch 
end catch
go
create procedure sp_DeleteCity
@id int
as
begin
	delete from City where ID=@id
end
---- District------------

go
begin try
drop procedure sp_GetDistrictByID
end try
begin catch 
end catch
go
create procedure sp_GetDistrictByID
@id int
as
select ID,Name,CityID from District where ID=@id
go


go
begin try
drop procedure sp_GetAllDistrict
end try
begin catch 
end catch
go
create procedure sp_GetAllDistrict
as
select ID,Name,CityID from District
go




go
begin try
drop procedure sp_InsertDistrict
end try
begin catch 
end catch
go
create procedure sp_InsertDistrict
 @name nvarchar(50),
 @cityId int 
 as
 begin
     insert into District(Name,CityID)values(@name,@cityId)
 end
 go




 go
begin try
drop procedure sp_UpdateDistrict
end try
begin catch 
end catch
go
create procedure sp_UpdateDistrict
@name nvarchar(50),
@cityID int ,
@id int
as
begin
   update District set Name=@name,CityID=@cityID where ID=@id
end
go



go
begin try
drop procedure sp_DeleteDistrict
end try
begin catch 
end catch
go
create procedure sp_DeleteDistrict
@id int
as
begin
 delete from District where ID=@id
end
go



----------------------------------Employee------------------------------------------------


go
begin try
drop procedure sp_GetEmployeeByID
end try
begin catch 
end catch
go
create procedure sp_GetEmployeeByID
         @id int
         as
         select ID,SocialNumber,FirstName,LastName,Gender,DateOfBirth,StartWorkDate,FinishWorkDate,CreatedEmployeeID,RoleID,Telephone,Email
          from Employee where ID=@id
go




go
begin try
drop procedure sp_GetAllEmployee
end try
begin catch 
end catch
go
create procedure sp_GetAllEmployee
               as
               select ID,SocialNumber,FirstName,LastName,Gender,DateOfBirth,StartWorkDate,FinishWorkDate,CreatedEmployeeID,RoleID,Telephone,Email
                from Employee
go



go
begin try
drop procedure sp_InsertEmployee
end try
begin catch 
end catch
go
create procedure sp_InsertEmployee
            @socialNumber nchar(11),
            @firstName nvarchar(50),
            @lastName nvarchar(50),
            @gender bit,
            @dateofbirth date,
            @startWorkDate datetime ,
            @finishWorkDate datetime,
            @createdEmployeeID int,
            @roleID int,
            @telephone nvarchar(20),
            @email nvarchar(50)
            as
            begin
                insert into Employee
              (SocialNumber,FirstName,LastName,Gender,DateOfBirth,StartWorkDate,FinishWorkDate,CreatedEmployeeID,RoleID,Telephone,Email)
              values
              (@socialNumber,@firstName,@lastName,@gender,@dateofbirth,@startWorkDate,@finishWorkDate,@createdEmployeeID,@roleID,@telephone,@email)
             SELECT SCOPE_IDENTITY()
             end
go




go
begin try
drop procedure sp_AddBranchEmployee
end try
begin catch 
end catch
go
create procedure sp_AddBranchEmployee
                   @officeID int,
                   @employeeID int
                   as
                   begin
                      insert into BranchEmployee(EmployeeID,OfficeID)values(@employeeID,@officeID)
                   end
go





go
begin try
drop procedure sp_UpdateEmployee
end try
begin catch 
end catch
go
create procedure sp_UpdateEmployee
              @socialNumber nchar(11),
              @firstName nvarchar(50),
              @lastName nvarchar(50),
              @gender bit,
              @dateofbirth date,
              @startWorkDate datetime ,
              @finishWorkDate datetime,
              @createdEmployeeID int,
              @roleID int,
              @telephone nvarchar(20),
              @email nvarchar(50),
              @id int
              as
              begin
                  Update Employee
                 set SocialNumber=@socialNumber,FirstName=@firstName,LastName=@lastName,Gender=@gender,
                 DateOfBirth=@dateofbirth,StartWorkDate=@startWorkDate,FinishWorkDate=@finishWorkDate,
                 CreatedEmployeeID=@createdEmployeeID,RoleID=@roleID,Telephone=@telephone,Email=@email
                 where ID=@id
              end
go




go
begin try
drop procedure sp_DeleteBranchEmployeeByID
end try
begin catch 
end catch
go
create procedure sp_DeleteBranchEmployeeByID
                   @employeeID int
                   as
                   begin
                      delete from BranchEmployee where EmployeeID=@employeeID
                   end
go






go
begin try
drop procedure sp_AddBranchEmployee
end try
begin catch 
end catch
go
 create procedure sp_AddBranchEmployee
                   @officeID int,
                   @employeeID int
                   as
                   begin
                      insert into BranchEmployee(EmployeeID,OfficeID)values(@employeeID,@officeID)
                   end
go






go
begin try
drop procedure sp_DeleteEmployee
end try
begin catch 
end catch
go
 create procedure sp_DeleteEmployee
               @id int
               as
               begin
                  delete from Employee where ID=@id
               end
go






go
begin try
drop procedure sp_DeleteBranchEmployeeByID
end try
begin catch 
end catch
go
create procedure sp_DeleteBranchEmployeeByID
                   @employeeID int
                   as
                   begin
                      delete from BranchEmployee where EmployeeID=@employeeID
                   end
go






---------------------------------------LOGÝN--------------------------------------------------------------

go
begin try
drop procedure sp_GetLoginByID
end try
begin catch 
end catch
go
create procedure sp_GetLoginByID
                @id int
                as
                select ID,Name,Password from Login where ID=@id
go







go
begin try
drop procedure sp_GetAllLogin
end try
begin catch 
end catch
go
create procedure sp_GetAllLogin
                as
                select ID,Name,Password from Login
go



go
begin try
drop procedure sp_InsertLogin
end try
begin catch 
end catch
go
create procedure sp_InsertLogin
@ID int,
 @name nvarchar(50),
 @password nvarchar(50)
 as
 begin
     insert into Login(ID,Name,Password)values(@ID,@name,@password)
 end
go
go
begin try
drop procedure sp_InsertLoginPassenger
end try
begin catch 
end catch
go
create procedure sp_InsertLoginPassenger
   @ID int,
   @name nvarchar(50),
   @password nvarchar(50)
   as
   begin
       insert into LoginPassenger(ID,Name,Password)values(@ID,@name,@password)
   end



go
begin try
drop procedure sp_UpdateLogin
end try
begin catch 
end catch
go
create procedure sp_UpdateLogin
               @name nvarchar(50),
               @password nvarchar(50),
               @id int
               as
               begin
                  update Login set Name=@name,Password=@password where ID=@id
               end
go




go
begin try
drop procedure sp_DeleteLogin
end try
begin catch 
end catch
go
create procedure sp_DeleteLogin
              @id int
              as
              begin
               delete from Login where ID=@id
              end
go



---------------------------------------------------------


---#########  WorkDAl iþlemleri
-----  WorkHourDAl get(int)
begin try
drop Proc sp_GetWorkHourByID
end try
Begin Catch
End Catch
go
 create proc sp_GetWorkHourByID
     @id int
     as
     select ID,Name,StartHour,EndHour,EmployeeID from WorkHour where ID=@id   
	 go   
-------

--WorkHourDAL List
go
begin try
drop Proc sp_GetAllWorkHour
end try
Begin Catch
End Catch
go

 create proc sp_GetAllWorkHour
         as
         select ID,Name,StartHour,EndHour,EmployeeID from WorkHour  
------------------

-----WorkHourDal Insert
go
begin try
drop Proc sp_AddWorkHour
end try
Begin Catch
End Catch
go
 create proc sp_AddWorkHour
      @name nvarchar(50),
      @startHour nchar(5),
      @endHour nchar(5),
      @employeeID int
      as
      begin
      Insert into WorkHour(Name,StartHour,EndHour,EmployeeID) values(@name,@startHour,@endHour,@employeeID)
      end    
	 -----------------------
	 
---------WorkHourDAL  Update
go
begin try
drop Proc sp_UpdateWorkHour
end try
Begin Catch
End Catch
go

  create proc sp_UpdateWorkHour
  @id int,
 @name nvarchar(50),
 @startHour nchar(5),
 @endHour nchar(5),
 @employeeID int
 as
 begin
 Update WorkHour set Name=@name,StartHour= @startHour,EndHour=@endHour,EmployeeID=@employeeID where ID=@id
 end

-------------

------WorkHourDAl Delete
go
begin try
drop Proc sp_DeleteWorkHour
end try
Begin Catch
End Catch
go
 create proc sp_DeleteWorkHour
 @id int
 as
 begin
 Delete from WorkHour where ID=@id
 end

---

---################ TravelDAl Ýþlemleri

----TravelDAl Get
go
begin try
drop Proc sp_GetTravelByID
end try
Begin Catch
End Catch
go

 create proc sp_GetTravelByID
 @id int
 as
 select TravelNumberName from Travel where ID=@id 


------

-----TravelDAL  List
go
begin try
drop Proc sp_GetAllTravel
end try
Begin Catch
End Catch
go
 create proc sp_GetAllTravel
    as
    select * from Travel  

------


-----TraveDAL Insert
go
begin try
drop Proc sp_AddTravel
end try
Begin Catch
End Catch
go
 create proc sp_AddTravel
 @travelNumberName nvarchar(50)
 as
 begin
 Insert into Travel(TravelNumberName) values(@travelNumberName)
 end 

------


-----TravelDAL Update
go
begin try
drop Proc sp_UpdateTravel
end try
Begin Catch
End Catch
go
 create proc sp_UpdateTravel
 @travelNumberName nchar(8),
 @id int
 as
 begin
 Update Travel set  TravelNumberName=@travelNumberName where ID=@id
 end

---------

----TravelDAL Delete
go
begin try
drop Proc sp_DeleteTravel
end try
Begin Catch
End Catch
go
 create proc sp_DeleteTravel
 @id int
 as
 begin
 Delete from Travel where ID=@id
 end

---



----------------#############  TicketDAL Ýþlemleri

------TicketDAL  Get
go
begin try
drop Proc sp_GetTicketByID
end try
Begin Catch
End Catch
go
 create proc sp_GetTicketByID
  @id int
  as
  select ID,PassengerID,RouteMapID,TravelID,EmployeeID,BusSeatID,CreateTicketDate,PaymentID from Ticket where ID=@id                       
------------ 

------TicketDAL List
go
begin try
drop Proc sp_GetAllTicket
end try
Begin Catch
End Catch
go
 create proc sp_GetAllTicket
   as
   select ID,PassengerID,RouteMapID,TravelID,EmployeeID,BusSeatID,CreateTicketDate,PaymentID from Ticket                        
------------

------TicketDAL Insert
go
begin try
drop Proc sp_AddTicket
end try
Begin Catch
End Catch
go
 create proc sp_AddTicket
    @passengerId int,
    @routeMapId int,
    @travelId int,
    @employeeId int,
    @busSeatId int,
    @createTicketDate datetime,
    @paymentId int
    as
    begin
    Insert into Ticket(PassengerID,RouteMapID,TravelID,EmployeeID,BusSeatID,CreateTicketDate,PaymentID) values(@passengerId,@routeMapId,@travelId,@employeeId,@busSeatId,@createTicketDate,@paymentId)
    end  
------------ 

------TicketDAL  Update
go
begin try
drop Proc sp_UpdateTicket
end try
Begin Catch
End Catch
go
create proc sp_UpdateTicket
  @id int,
  @passengerId int,
  @routeMapId int,
  @travelId int,
  @employeeId int,
  @busSeatId int,
  @createTicketDate datetime,
  @paymentId int
  as
  begin
  Update Ticket set  PassengerID=@passengerId,RouteMapID=@routeMapId,TravelID=@travelId,EmployeeID=@employeeId,BusSeatID=@busSeatId,CreateTicketDate=@createTicketDate,PaymentID=@paymentId where ID=@id
  end

------------

------TicketDAL  Delete
go
begin try
drop Proc sp_DeleteTicket
end try
Begin Catch
End Catch
go
 create proc sp_DeleteTicket
 @id int
 as
 begin
 Delete from Ticket where ID=@id
 end
------------


-------------------------################     RouteMap iþlemleri

-------RouteMap Get
go
begin try
drop Proc sp_GetRouteMapByID
end try
Begin Catch
End Catch
go
 create proc sp_GetRouteMapByID
 @id int
 as
 select ID,TravelID,Departure,Arrival,StartDate,EndDate,Price,BeforeRouteID from RouteMap where ID=@id                       
-------------

-------RouteMap List
go
begin try
drop Proc sp_GetAllRouteMap
end try
Begin Catch
End Catch
go
create proc sp_GetAllRouteMap
 as
 select ID,TravelID,Departure,Arrival,StartDate,EndDate,Price,BeforeRouteID from RouteMap                       
-------------

-------RouteMap Insert 
go
begin try
drop Proc sp_AddRouteMap
end try
Begin Catch
End Catch
go
create proc sp_AddRouteMap
   @travelId int,
   @departure int,
   @arrival int,
   @startDate datetime,
   @endDate datetime,
   @price decimal,
   @beforeRouteId int
   as
   begin
   Insert into RouteMap(TravelID,Departure,Arrival,StartDate,EndDate,Price,BeforeRouteID) values(@travelId,@departure,@arrival,@startDate,@endDate,@price,@beforeRouteId)
   end  
-------------

-------RouteMap Update
go
begin try
drop Proc sp_UpdateRouteMap
end try
Begin Catch
End Catch
go
create proc sp_UpdateRouteMap
 @id int,
 @travelId int,
 @departure int,
 @arrival int,
 @startDate datetime,
 @endDate datetime,
 @price decimal,
 @beforeRouteId int
 as
 begin
 Update RouteMap set TravelID=@travelId,Departure=@departure,Arrival=@arrival,StartDate=@startDate,EndDate=@endDate,Price=@price,BeforeRouteID=@beforeRouteId where ID=@id
 end

-------------

-------RouteMap Delete
go
begin try
drop Proc sp_DeleteRouteMap
end try
Begin Catch
End Catch
go
create proc sp_DeleteRouteMap
 @id int
 as
 begin
 Delete from RouteMap where ID=@id
 end  
-------------

-------------------------################     RoleData iþlemleri

-------RoleData Get
go
begin try
drop Proc sp_GetRole
end try
Begin Catch
End Catch
go
create proc sp_GetRole
 @Id int
 as
 begin
 select ID, RoleName from Role where ID = @Id
 end  
-------------

-------RoleData List
go
begin try
drop Proc sp_GetRoleList
end try
Begin Catch
End Catch
go
create proc sp_GetRoleList

  as
  begin
  select ID, RoleName from Role 
  end   
-------------

-------RoleData Insert 
go
begin try
drop Proc sp_AddRoleInsert
end try
Begin Catch
End Catch
go
create proc sp_AddRoleInsert    --Insert Bus
    @roleName nvarchar(50) 
  as 
  begin
  Insert Role(RoleName) values (@roleName) 
  SELECT SCOPE_IDENTITY()
  end 
-------------
go
-------RoleData Update
begin try
drop Proc sp_UpdateRole
end try
Begin Catch
End Catch
go
create proc sp_UpdateRole
  @roleName nvarchar(50),
  @Id int
as 
begin
update Role set RoleName = @roleName where Role.ID = @Id 
end
go
-------------

-------RoleData Delete
begin try
drop Proc sp_DeleteRoleAuthoryById
end try
Begin Catch
End Catch
go
create procedure sp_DeleteRoleAuthoryById
 @roleID int
 as
 begin
 	delete from RoleAuthory where RoleId=@roleID 
 end
 go

 begin try
drop Proc sp_DeleteRole
end try
Begin Catch
End Catch
go
 create proc sp_DeleteRole
   @Id int
   as
   begin
   delete from Role where Role.ID = @Id
   end
   go
 go

 go

  begin try
 drop procedure sp_GetRoleAuthoryByID
 end try
 begin catch 
 end catch
 go
 create procedure sp_GetRoleAuthoryByID
  @roleID int
  as
  begin 
      select RoleID,AuthorID from  RoleAuthory  where RoleID=@roleID
  end
  go
------------- 

-------------------------################     RoadExpense iþlemleri

-------RoadExpense Get
go
begin try
drop Proc sp_GetRoadExpenseByID
end try
Begin Catch
End Catch
go
create proc sp_GetRoadExpenseByID
 @id int
 as
 select ID,ExpenseName,BusID,TotalPrice from RoadExpense where ID=@id                        
-------------

-------RoadExpense List
go
begin try
drop Proc sp_GetAllRoadExpense
end try
Begin Catch
End Catch
go 
create proc sp_GetAllRoadExpense
  as
  select ID,ExpenseName,BusID,TotalPrice from RoadExpense  
-------------

-------RoadExpense Insert 
go
begin try
drop Proc sp_InsertRoadExpense
end try
Begin Catch
End Catch
go
create proc sp_InsertRoadExpense
 @expenseName nvarchar(50),
 @busId int,
 @totalPrice decimal
 as
 begin
 Insert into RoadExpense(ExpenseName,BusID,TotalPrice) values(@expenseName,@busId,@totalPrice)
 end   
-------------

-------RoadExpense Update
go
begin try
drop Proc sp_UpdateRoadExpense
end try
Begin Catch
End Catch
go
create proc sp_UpdateRoadExpense
 @id int,
 @expenseName nvarchar(50),
 @busId int,
 @totalPrice decimal
 as
 begin
 Update RoadExpense set ExpenseName=@expenseName,BusID=@busId,TotalPrice=@totalPrice where ID=@id
 end
-------------

-------RoadExpense Delete
go
begin try
drop Proc sp_DeleteRoadExpense
end try
Begin Catch
End Catch
go
 create proc sp_DeleteRoadExpense
  @id int
  as
  begin
  Delete from RoadExpense where ID=@id
  end
------------- 
	
	
-------------------------################     PaymentType iþlemleri

-------PaymentType Get
go
begin try
drop Proc sp_GetPaymentTypeByID
end try
Begin Catch
End Catch
go
 create proc sp_GetPaymentTypeByID
 @id int
 as
 select ID,PaymentyTypeName from PaymentType where ID=@id 
-------------

-------PaymentType List
go
begin try
drop Proc sp_GetAllRoadExpense
end try
Begin Catch
End Catch
go
create proc sp_GetAllRoadExpense
  as
  select ID,ExpenseName,BusID,TotalPrice from RoadExpense  
-------------

-------PaymentType Insert 
go
begin try
drop Proc sp_InsertPaymentType
end try
Begin Catch
End Catch
go
 create proc sp_InsertPaymentType
 @paymentTypeName nvarchar(50)
 as
 begin
 Insert into PaymentType(PaymentyTypeName) values(@paymentTypeName)
 end  
-------------

-------PaymentType Update
go
begin try
drop Proc sp_UpdatePaymentType
end try
Begin Catch
End Catch
go
create proc sp_UpdatePaymentType
  @id int,
  @paymentTypeName nvarchar(50)
  as
  begin
  Update PaymentType set PaymentyTypeName=@paymentTypeName where ID=@id
  end     
-------------

-------PaymentType Delete
go
begin try
drop Proc sp_DeletePaymentType
end try
Begin Catch
End Catch
go
create proc sp_DeletePaymentType
  @id int
  as
  begin
  Delete from PaymentType where ID=@id
  end
-------------  


-------------------------################     Payment iþlemleri

-------Payment Get
go
begin try
drop Proc sp_GetPaymentByID
end try
Begin Catch
End Catch
go
 create proc sp_GetPaymentByID
 @id int
 as
 select ID,TotalPrice,PaymentTypeID,CreatePaymentDate from Payment where ID=@id
-------------

-------Payment List
go
begin try
drop Proc sp_GetAllPayment
end try
Begin Catch
End Catch
go
go
 create proc sp_GetAllPayment
 as
 select ID,TotalPrice,PaymentTypeID,CreatePaymentDate from Payment  
-------------

-------Payment Insert 
go
begin try
drop Proc sp_InsertPayment
end try
Begin Catch
End Catch
go
 create proc sp_InsertPayment
 @totalPrice decimal,
 @paymentTypeID int,
 @createPaymentDate datetime
 as
 begin
 Insert into Payment(TotalPrice,PaymentTypeID,CreatePaymentDate) values(@totalPrice,@paymentTypeID,@createPaymentDate)
 end  
                    
-------------

-------Payment Update
go
begin try
drop Proc sp_UpdatePayment
end try
Begin Catch
End Catch
go
 create proc sp_UpdatePayment
 @id int,
 @totalPrice decimal,
 @paymentTypeID int,
 @createPaymentDate datetime
 as
 begin
 Update Payment set TotalPrice=@totalPrice,PaymentTypeID=@paymentTypeID,CreatePaymentDate=@createPaymentDate where ID=@id
 end
-------------

-------Payment Delete
go
begin try
drop Proc sp_DeletePayment
end try
Begin Catch
End Catch
go
create proc sp_DeletePayment
   @id int
   as
   begin
   Delete from Payment where ID=@id
   end
-------------   


 
-------------------------################     Passenger iþlemleri

-------Passenger Get
go
begin try
drop Proc sp_GetPassengerByID
end try
Begin Catch
End Catch
go
create proc sp_GetPassengerByID
 @id int
 as
 select ID,SocialNumber,FirstName,LastName,Gender,Telephone,Email from Passenger where ID=@id                      
-------------

-------Passenger List
go
begin try
drop Proc sp_GetAllPassenger
end try
Begin Catch
End Catch
go
create proc sp_GetAllPassenger
 as
 select ID,SocialNumber,FirstName,LastName,Gender,Telephone,Email from Passenger                      
  
-------------

-------Passenger Insert 
go
begin try
drop Proc sp_InsertPassenger
end try
Begin Catch
End Catch
go
create proc sp_InsertPassenger
  @socialNumber nvarchar(50),
  @firstName nvarchar(50),
  @lastName nvarchar(50),
  @gender bit,
  @telephone nvarchar(50),
  @email nvarchar(50)
  as
  begin
  Insert into Passenger(SocialNumber,FirstName,LastName,Gender,Telephone,Email) values(@socialNumber,@firstName,@lastName,@gender,@telephone,@email)
  SELECT SCOPE_IDENTITY()
  end   
-------------

-------Passenger Update
go
begin try
drop Proc sp_UpdatePassenger
end try
Begin Catch
End Catch
go
create proc sp_UpdatePassenger
  @id int,
  @socialNumber nvarchar(50),
  @firstName nvarchar(50),
  @lastName nvarchar(50),
  @gender bit,
  @telephone nvarchar(50),
  @email nvarchar(50)
  as
  begin
  Update Passenger set SocialNumber=@socialNumber,FirstName=@firstName,LastName=@lastName,Gender=@gender,Telephone=@telephone,Email=@email where ID=@id
  end
-------------

-------Passenger Delete
go
begin try
drop Proc sp_DeletePassenger
end try
Begin Catch
End Catch
go
 create proc sp_DeletePassenger
  @id int
  as
  begin
  Delete from Passenger where ID=@id
  end
-------------  




 
-------------------------################     Office iþlemleri

-------Office Get
go
begin try
drop Proc sp_GetOfficeByID
end try
Begin Catch
End Catch
go
 create procedure sp_GetOfficeByID
  @id int
  as
  select ID,OfficeName,DistinctID,IsCenterOffice from Office where ID=@id

-------------

-------Office List
go
begin try
drop Proc sp_GetAllOffice
end try
Begin Catch
End Catch
go
 create procedure sp_GetAllOffice
  as
  select ID,OfficeName,DistinctID,IsCenterOffice from Office
-------------

-------Office Insert 
go
begin try
drop Proc sp_InsertOffice
end try
Begin Catch
End Catch
go
 create proc sp_InsertOffice
   @officeName nvarchar(50),
   @districtId int,
   @isCenterOffice bit
   as
   begin
       insert into Office(OfficeName,DistinctID,IsCenterOffice) values(@officeName,@districtId,@isCenterOffice)
	   SELECT SCOPE_IDENTITY()
   end
-------------

-------Office Update
go
begin try
drop Proc sp_UpdateOffice
end try
Begin Catch
End Catch
go
create procedure sp_UpdateOffice
 @officeName nvarchar(50),
 @districtId int,
 @isCenterOffice bit,
 @id int
  as
  begin
     update Office set OfficeName=@officeName,DistinctID=@districtId,IsCenterOffice=@isCenterOffice where ID=@id
  end
-------------

-------Office Delete
go
begin try
drop Proc sp_DeleteOffice
end try
Begin Catch
End Catch
go
 create procedure sp_DeleteOffice
  @id int
  as
  begin 
    delete from Office where ID=@id
  end
------------- 
 go
 begin try
 drop procedure sp_GetEmployeeInOfficeByID
 end try
 begin catch 
 end catch
 go
 create procedure sp_GetEmployeeInOfficeByID
  @officeID int
  as
  begin 
      select OfficeID,EmployeeID from  BranchEmployee  where OfficeID=@officeID
  end
  go

 
 begin try
 drop procedure sp_AddBranchEmployee
 end try
 begin catch 
 end catch
  go
  create procedure sp_AddBranchEmployee
   @officeID int,
   @employeeID int
   as
   begin 
     insert into BranchEmployee(OfficeID,EmployeeID) values (@officeID,@employeeID)
   end
go

 begin try
 drop procedure sp_DeleteBranchEmployeeById
 end try
 begin catch 
 end catch
  go
create procedure sp_DeleteBranchEmployeeById
@officeID int
as
begin
	delete from BranchEmployee where OfficeID=@officeID 
end
go
 begin try
 drop procedure sp_DeleteBranchEmployeeById
 end try
 begin catch 
 end catch
go
create procedure sp_DeleteBranchEmployeeById
@officeID int
as
begin
	delete from BranchEmployee where OfficeID=@officeID 
end
		 
		 
go



create proc sp_PassangerLogin
@name nvarchar(50),
@password nvarchar(50)
as
select
go
-----------------------------------------------------------------
		 
		 
go
begin try
drop Proc sp_PassangerLogin
end try
Begin Catch
End Catch
go
create proc sp_PassangerLogin
@name nvarchar(50),
@password nvarchar(50)
as
select
ID
from
LoginPassenger where Name='@name' and Password='@password'
go

go
begin try
drop Proc sp_EmployeeLogin
end try
Begin Catch
End Catch
go
create proc sp_EmployeeLogin
@name nvarchar(50),
@password nvarchar(50)
as
select
ID
from
Login where Name='@name' and Password='@password'
go		 
		 
		 
		 
		 
		 
		 
		 
		 
		 
		 
