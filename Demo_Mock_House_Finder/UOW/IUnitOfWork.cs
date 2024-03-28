using Demo_Mock_House_Finder.Repository;
using Microsoft.EntityFrameworkCore;

namespace Demo_Mock_House_Finder.UOW
{
    public interface IUnitOfWork
    {
        AddressRepository Addresses { get; }
        CampusRepository Campuses { get; }
        CommuneRepository Communes { get; }
        DistrictRepository Districts { get; }
        HouseImageRepository HouseImages { get; }
        HouseRepository Houses { get; }
        RateRepository Rates { get; }
        ReportRepository Reports { get; }
        RoomHistoryRepository RoomHistories { get; }
        RoomImageRepository RoomImages { get; }
        RoomRepository Rooms { get; }
        RoomTypeRepository RoomsType { get; }
        StatusRepository Statuses { get; }
        UserRepository Users { get; }
        UserRoleRepository UserRoles { get; }
        VillageRepository Villages { get; }


        //Start the database Transaction
        void CreateTransaction();
        //Commit the database Transaction
        void Commit();
        //Rollback the database Transaction
        void Rollback();
        //DbContext Class SaveChanges method
        Task Save();
    }
}
