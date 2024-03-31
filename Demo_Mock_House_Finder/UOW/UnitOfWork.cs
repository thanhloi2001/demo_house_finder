using Demo_Mock_House_Finder.Data;
using Demo_Mock_House_Finder.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Demo_Mock_House_Finder.Model;
using System;

namespace Demo_Mock_House_Finder.UOW
{
    //Generic UnitOfWork Class
    //Implementing the IUnitOfWork and IDisposable Interfaces
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        //The following varibale will hold DbContext Instance
        public ApplicationDbContext Context = null;

        //The following Object is going to hold the Transaction Object
        private IDbContextTransaction? _objTran = null;

        public AddressRepository Addresses { get; private set; }
        public CampusRepository Campuses { get; private set; }
        public CommuneRepository Communes { get; private set; }
        public DistrictRepository Districts { get; private set; }   
        public HouseImageRepository HouseImages { get; private set; }
        public HouseRepository Houses { get; private set; }
        public RateRepository Rates { get; private set; }
        public ReportRepository Reports { get; private set; }
        public RoomHistoryRepository RoomHistories { get; private set; }
        public RoomImageRepository RoomImages { get; private set; }
        public RoomRepository Rooms { get; private set; }
        public RoomTypeRepository RoomsType { get; private set; }
        public StatusRepository Statuses { get; private set; }
        public UserRepository Users { get; private set; }
        public UserRoleRepository UserRoles { get; private set; }
        public VillageRepository Villages { get; private set; }

        
        public UnitOfWork(ApplicationDbContext _Context)
        {
            Context = _Context;
            Addresses = new AddressRepository(Context);
            Campuses = new CampusRepository(Context);
            Communes = new CommuneRepository(Context);
            Districts = new DistrictRepository(Context);
            HouseImages = new HouseImageRepository(Context);
            Houses = new HouseRepository(Context);
            Rates = new RateRepository(Context);
            Reports = new ReportRepository(Context);
            RoomHistories = new RoomHistoryRepository(Context);
            RoomImages = new RoomImageRepository(Context);
            Rooms = new RoomRepository(Context);
            RoomsType = new RoomTypeRepository(Context);
            Statuses = new StatusRepository(Context);
            Users = new UserRepository(Context);
            UserRoles = new UserRoleRepository(Context);
            Villages = new VillageRepository(Context);
        }


        
        //The CreateTransaction() method will create a database Transaction so that we can do database operations
        //by applying do everything and do nothing principle
        public void CreateTransaction()
        {
            //It will Begin the transaction on the underlying store connection
            _objTran = Context.Database.BeginTransaction();
        }

        //If all the Transactions are completed successfully then we need to call this Commit() 
        //method to Save the changes permanently in the database
        public void Commit()
        {
            //Commits the underlying store transaction
            _objTran?.Commit();
        }

        //If at least one of the Transaction is Failed then we need to call this Rollback() 
        //method to Rollback the database changes to its previous state
        public void Rollback()
        {
            //Rolls back the underlying store transaction
            _objTran?.Rollback();
            //The Dispose Method will clean up this transaction object and ensures Entity Framework
            //is no longer using that transaction.
            _objTran?.Dispose();
        }


        //The Save() Method Implement DbContext Class SaveChanges method 
        //So whenever we do a transaction we need to call this Save() method 
        //so that it will make the changes in the database permanently
        public async Task Save()
        {
            try
            {
                //Calling DbContext Class SaveChanges method 
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        //Disposing of the Context Object
        public void Dispose()
        {
            Context.Dispose();  
        }
    }
}
