using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace Dormitory
{
	//public class Person
	//{
	//	// имя
	//	[Column]
	//	public string Name { get; set; }
	//	// фамилия
	//	[Column]
	//	public string Surname { get; set; }
	//	// отчество
	//	[Column]
	//	public string Patronymic { get; set; }
	//}

	// житель
	[Table(Name = "Residents")]
	public class Resident
	{
		//[Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Always)]
		[Column(IsPrimaryKey = true, IsDbGenerated = true)]
		public int ResidentId { get; set; }

		[Column]
		public string Name { get; set; }

		[Column]
		public string Surname { get; set; }

		[Column]
		public string Patronymic { get; set; }

		[Column]
		public string PhoneNumber { get; set; }

		[Column]
		public DateTime? Birthday { get; set; }

		[Column]
		public string Note { get; set; }

		[Column]
		public int? PassportId { get; set; }

		[Column]
		public int? OrganizationId { get; set; }

		private EntityRef<Passport> _Passport;
		[Association(Storage = "_Passport", ThisKey = "PassportId", OtherKey = "PassportId")]
		public Passport Passport {
			get { return this._Passport.Entity; }
			set { this._Passport.Entity = value; }
		}

		private EntityRef<Organization> _Organization;
		[Association(Storage = "_Organization", ThisKey = "OrganizationId", OtherKey = "OrganizationId")]
		public Organization Organization {
			get { return this._Organization.Entity; }
			set { this._Organization.Entity = value; }
		}

		private EntitySet<ResidentRooms> _ResidentRooms = new EntitySet<ResidentRooms>();
		[Association(Storage = "_ResidentRooms", ThisKey = "ResidentId", OtherKey = "ResidentId")]
		public EntitySet<ResidentRooms> ResidentRooms {
			get { return this._ResidentRooms; }
			set { this._ResidentRooms.Assign(value); }
		}
	}

	////public class User : Person
	////{
	////	public int UserId { get; set; }

	////	public string Login { get; set; }

	////	public string Password { get; set; }

	////	public string Role { get; set; }
	////}

	// организация
	[Table(Name = "Organizations")]
	public class Organization
	{
		[Column(IsPrimaryKey = true, IsDbGenerated = true)]
		public int OrganizationId { get; set; }

		[Column]
		public string Name { get; set; }

		[Column]
		public string Address { get; set; }

		[Column]
		public string Requisites { get; set; }

		private EntitySet<Resident> _Residents = new EntitySet<Resident>();
		[Association(Storage = "_Residents", OtherKey = "OrganizationId")]
		public EntitySet<Resident> Residents {
			get { return this._Residents; }
			set { this._Residents.Assign(value); }
		}
	}

	// паспорт
	[Table(Name = "Passports")]
	public class Passport
	{
		[Column(IsPrimaryKey = true, IsDbGenerated = true)]
		public int PassportId { get; set; }

		[Column]
		public string Number { get; set; }

		[Column]
		public string Series { get; set; }

		[Column]
		public string Registration { get; set; }

		[Column]
		public DateTime? DateOfIssue { get; set; }

		[Column]
		public string Authority { get; set; }

		private EntityRef<Resident> _Resident;
		[Association(Storage = "_Resident", OtherKey = "PassportId")]
		public Resident Resident {
			get { return this._Resident.Entity; }
			set { this._Resident.Entity = value; }
		}
	}

	//секция
	[Table(Name = "Sections")]
	public class Section
	{
		//[Column(IsPrimaryKey = true, IsDbGenerated = true)]
		//public int SectionId { get; set; }

		[Column(IsPrimaryKey = true)]
		public int Number { get; set; }

		[Column]
		public int NumberOfRooms { get; set; }

		[Column]
		public int Seats { get; set; }

		[Column]
		public int EmptySeats { get; set; }

		private EntitySet<Room> _Rooms = new EntitySet<Room>();
		[Association(Storage = "_Rooms", ThisKey = "Number", OtherKey = "SectionNumber")]
		public EntitySet<Room> Rooms {
			get { return this._Rooms; }
			set { this._Rooms.Assign(value); }
		}
	}

	// комната
	[Table(Name = "Rooms")]
	public class Room
	{
		[Column(IsPrimaryKey = true, IsDbGenerated = true)]
		public int RoomId { get; set; }

		[Column]
		public int Number { get; set; }

		[Column]
		public int Seats { get; set; }

		[Column]
		public int? SectionNumber { get; set; }

		private EntityRef<Section> _Section;
		[Association(Storage = "_Section", ThisKey = "SectionNumber", OtherKey = "Number")]
		public Section Section {
			get { return this._Section.Entity; }
			set { this._Section.Entity = value; }
		}

		//private EntitySet<Resident> _Residents = new EntitySet<Resident>();
		//[Association(Storage = "_Residents", OtherKey = "ResidentId")]
		//public EntitySet<Resident> Residents {
		//	get { return this._Residents; }
		//	set { this._Residents.Assign(value); }
		//}

		//private EntitySet<ResidentsRooms> _ResidentsRooms = new EntitySet<ResidentsRooms>();
		//[Association(Storage = "_ResidentsRooms", OtherKey = "ResidentsRoomsId")]
		//public EntitySet<ResidentsRooms> ResidentsRooms {
		//	get { return this._ResidentsRooms; }
		//	set { this._ResidentsRooms.Assign(value); }
		//}

		private EntitySet<RoomResidents> _RoomResidents = new EntitySet<RoomResidents>();
		[Association(Storage = "_RoomResidents", ThisKey = "RoomId", OtherKey = "RoomId")]
		public EntitySet<RoomResidents> RoomResidents {
			get { return this._RoomResidents; }
			set { this._RoomResidents.Assign(value); }
		}
	}

	[Table(Name = "RoomResidents")]
	public class RoomResidents
	{
		[Column(IsPrimaryKey = true)]
		public int RoomId { get; set; }

		[Column(IsPrimaryKey = true)]
		public int ResidentId { get; set; }
	}

	// проживание
	[Table(Name = "ResidentRooms")]
	public class ResidentRooms
	{
		[Column(IsPrimaryKey = true, IsDbGenerated = true)]
		public int ResidentRoomsId { get; set; }

		[Column]
		public int ResidentId { get; set; }

		[Column]
		public int RoomId { get; set; }

		[Column]
		public bool CashPayment { get; set; }

		[Column]
		public bool BedClothes { get; set; }

		[Column]
		public DateTime SettlementDate { get; set; }

		[Column]
		public DateTime? DateOfEviction { get; set; }

		private EntityRef<Resident> _Resident;
		[Association(Storage = "_Resident", ThisKey = "ResidentId", OtherKey = "ResidentId")]
		public Resident Resident {
			get { return this._Resident.Entity; }
			set { this._Resident.Entity = value; }
		}

		private EntityRef<Room> _Room;
		[Association(Storage = "_Room", ThisKey = "RoomId", OtherKey = "RoomId")]
		public Room Room {
			get { return this._Room.Entity; }
			set { this._Room.Entity = value; }
		}
	}

	// Вещи на прокат
	[Table(Name = "RentThings")]
	public class RentThing
	{
		[Column(IsPrimaryKey = true, IsDbGenerated = true)]
		public int RentThingId { get; set; }

		[Column]
		public string Name { get; set; }
	}

	// проживание
	[Table(Name = "ResidentRoomsRentThings")]
	public class ResidentRoomsRentThing
	{
		[Column(IsPrimaryKey = true)]
		public int ResidentRoomsId { get; set; }

		[Column(IsPrimaryKey = true)]
		public int RentThingId { get; set; }

		[Column(IsPrimaryKey = true)]
		public DateTime StartRentDate { get; set; }

		[Column]
		public DateTime EndRentDate { get; set; }

		private EntityRef<ResidentRooms> _ResidentRooms;
		[Association(Storage = "_ResidentRooms", ThisKey = "ResidentRoomsId", OtherKey = "ResidentRoomsId")]
		public ResidentRooms ResidentRooms {
			get { return this._ResidentRooms.Entity; }
			set { this._ResidentRooms.Entity = value; }
		}

		private EntityRef<RentThing> _RentThing;
		[Association(Storage = "_RentThing", ThisKey = "RentThingId", OtherKey = "RentThingId")]
		public RentThing RentThing {
			get { return this._RentThing.Entity; }
			set { this._RentThing.Entity = value; }
		}
	}

}
