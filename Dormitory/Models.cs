using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace Dormitory
{
	/// <summary>
	/// Житель
	/// </summary>
	[Table(Name = "Residents")]
	public class Resident
	{
		/// <summary>
		/// Идентификатор жителя
		/// </summary>
		[Column(IsPrimaryKey = true, IsDbGenerated = true)]
		public int ResidentId { get; set; }
		/// <summary>
		/// Имя
		/// </summary>
		[Column]
		public string Name { get; set; }
		/// <summary>
		/// Фамилия
		/// </summary>
		[Column]
		public string Surname { get; set; }
		/// <summary>
		/// Отчество
		/// </summary>
		[Column]
		public string Patronymic { get; set; }
		/// <summary>
		/// Телефонный номер
		/// </summary>
		[Column]
		public string PhoneNumber { get; set; }
		/// <summary>
		/// День рождения
		/// </summary>
		[Column]
		public DateTime? Birthday { get; set; }
		/// <summary>
		/// Заметка
		/// </summary>
		[Column]
		public string Note { get; set; }
		/// <summary>
		/// Идентификатор паспорта
		/// </summary>
		[Column]
		public int? PassportId { get; set; }
		/// <summary>
		/// Идентификатор организации
		/// </summary>
		[Column]
		public int? OrganizationId { get; set; }
		/// <summary>
		/// Ссылка на паспорт
		/// </summary>
		private EntityRef<Passport> _Passport;
		/// <summary>
		/// Паспорт
		/// </summary>
		[Association(Storage = "_Passport", ThisKey = "PassportId", OtherKey = "PassportId", IsForeignKey = true)]
		public Passport Passport {
			get { return this._Passport.Entity; }
			set { this._Passport.Entity = value; }
		}
		/// <summary>
		/// Ссылка на организацию
		/// </summary>
		private EntityRef<Organization> _Organization;
		/// <summary>
		/// Организация
		/// </summary>
		[Association(Storage = "_Organization", ThisKey = "OrganizationId", OtherKey = "OrganizationId", IsForeignKey = true)]
		public Organization Organization {
			get { return this._Organization.Entity; }
			set { this._Organization.Entity = value; }
		}
		/// <summary>
		/// Ссылка на проживание
		/// </summary>
		private EntitySet<ResidentRooms> _ResidentRooms = new EntitySet<ResidentRooms>();
		/// <summary>
		/// Проживание
		/// </summary>
		[Association(Storage = "_ResidentRooms", ThisKey = "ResidentId", OtherKey = "ResidentId")]
		public EntitySet<ResidentRooms> ResidentRooms {
			get { return this._ResidentRooms; }
			set { this._ResidentRooms.Assign(value); }
		}
		/// <summary>
		/// Копирование объекта
		/// </summary>
		/// <returns>Копия объекта</returns>
		public Resident ShallowCopy()
		{
			return new Resident
			{
				Name = Name,
				Surname = Surname,
				Patronymic = Patronymic,
				PhoneNumber = PhoneNumber,
				Birthday = Birthday,
				Note = Note,
				PassportId = PassportId,
				OrganizationId = OrganizationId,
				Passport = Passport,
				Organization = Organization,
				ResidentRooms = ResidentRooms
			};
		}
	}

	/// <summary>
	/// Ораганизация
	/// </summary>
	[Table(Name = "Organizations")]
	public class Organization
	{
		/// <summary>
		/// Идентификатор организации
		/// </summary>
		[Column(IsPrimaryKey = true, IsDbGenerated = true)]
		public int OrganizationId { get; set; }
		/// <summary>
		/// Название
		/// </summary>
		[Column]
		public string Name { get; set; }
		/// <summary>
		/// Адрес
		/// </summary>
		[Column]
		public string Address { get; set; }
		/// <summary>
		/// Ссылка на жителей
		/// </summary>
		private EntitySet<Resident> _Residents = new EntitySet<Resident>();
		/// <summary>
		/// Жители организации
		/// </summary>
		[Association(Storage = "_Residents", ThisKey = "OrganizationId", OtherKey = "OrganizationId")]
		public EntitySet<Resident> Residents {
			get { return this._Residents; }
			set { this._Residents.Assign(value); }
		}

		/// <summary>
		/// Копирование объекта
		/// </summary>
		/// <returns>Копия объекта</returns>
		public Organization ShallowCopy()
		{
			return new Organization
			{
				OrganizationId = OrganizationId,
				Name = Name,
				Address = Address,
				Residents = Residents
			};
		}
	}

	/// <summary>
	/// Паспорт
	/// </summary>
	[Table(Name = "Passports")]
	public class Passport
	{
		/// <summary>
		/// Идентификатор паспорта
		/// </summary>
		[Column(IsPrimaryKey = true, IsDbGenerated = true)]
		public int PassportId { get; set; }
		/// <summary>
		/// Номер
		/// </summary>
		[Column]
		public string Number { get; set; }
		/// <summary>
		/// Серия
		/// </summary>
		[Column]
		public string Series { get; set; }
		/// <summary>
		/// Прописка
		/// </summary>
		[Column]
		public string Registration { get; set; }
		/// <summary>
		/// Дата выдачи
		/// </summary>
		[Column]
		public DateTime? DateOfIssue { get; set; }
		/// <summary>
		/// Орган выдачи
		/// </summary>
		[Column]
		public string Authority { get; set; }
		/// <summary>
		/// Ссылка на жителя
		/// </summary>
		private EntityRef<Resident> _Resident;
		/// <summary>
		/// Житель
		/// </summary>
		[Association(Storage = "_Resident", ThisKey = "PassportId", OtherKey = "PassportId")]
		public Resident Resident {
			get { return this._Resident.Entity; }
			set { this._Resident.Entity = value; }
		}
		/// <summary>
		/// Копирование паспорта
		/// </summary>
		/// <returns>Копия паспорта</returns>
		public Passport ShallowCopy()
		{
			return (Passport)this.MemberwiseClone();
		}
	}
	
	/// <summary>
	/// Секция
	/// </summary>
	[Table(Name = "Sections")]
	public class Section
	{
		/// <summary>
		/// Номер секции
		/// </summary>
		[Column(IsPrimaryKey = true)]
		public int Number { get; set; }
		/// <summary>
		/// Количество комнат
		/// </summary>
		[Column]
		public int NumberOfRooms { get; set; }
		/// <summary>
		/// Количество мест
		/// </summary>
		[Column]
		public int Seats { get; set; }
		/// <summary>
		/// Количество пустых мест
		/// </summary>
		[Column]
		public int EmptySeats { get; set; }
		/// <summary>
		/// Ссылка на комнаты
		/// </summary>
		private EntitySet<Room> _Rooms = new EntitySet<Room>();
		/// <summary>
		/// Комнаты
		/// </summary>
		[Association(Storage = "_Rooms", ThisKey = "Number", OtherKey = "SectionNumber")]
		public EntitySet<Room> Rooms {
			get { return this._Rooms; }
			set { this._Rooms.Assign(value); }
		}
	}
	
	/// <summary>
	/// Комната
	/// </summary>
	[Table(Name = "Rooms")]
	public class Room
	{
		/// <summary>
		/// Идентификатор комнаты
		/// </summary>
		[Column(IsPrimaryKey = true, IsDbGenerated = true)]
		public int RoomId { get; set; }
		/// <summary>
		/// Номер
		/// </summary>
		[Column]
		public int Number { get; set; }
		/// <summary>
		/// Мест
		/// </summary>
		[Column]
		public int Seats { get; set; }
		/// <summary>
		/// Номер секции
		/// </summary>
		[Column]
		public int? SectionNumber { get; set; }
		/// <summary>
		/// Ссылка на секцию
		/// </summary>
		private EntityRef<Section> _Section;
		/// <summary>
		/// Секция
		/// </summary>
		[Association(Storage = "_Section", ThisKey = "SectionNumber", OtherKey = "Number")]
		public Section Section {
			get { return this._Section.Entity; }
			set { this._Section.Entity = value; }
		}
		/// <summary>
		/// Ссылка на жителей комнаты
		/// </summary>
		private EntitySet<RoomResidents> _RoomResidents = new EntitySet<RoomResidents>();
		/// <summary>
		/// Жители комнаты
		/// </summary>
		[Association(Storage = "_RoomResidents", ThisKey = "RoomId", OtherKey = "RoomId")]
		public EntitySet<RoomResidents> RoomResidents {
			get { return this._RoomResidents; }
			set { this._RoomResidents.Assign(value); }
		}
	}
	
	/// <summary>
	/// Жители комнаты
	/// </summary>
	[Table(Name = "RoomResidents")]
	public class RoomResidents
	{
		/// <summary>
		/// Идентификатор комнаты
		/// </summary>
		[Column(IsPrimaryKey = true)]
		public int RoomId { get; set; }
		/// <summary>
		/// Идентификатор жителя
		/// </summary>
		[Column(IsPrimaryKey = true)]
		public int ResidentId { get; set; }
	}
	
	/// <summary>
	/// Комнаты жителя
	/// </summary>
	[Table(Name = "ResidentRooms")]
	public class ResidentRooms
	{
		/// <summary>
		/// Идентификатор комнат жителя
		/// </summary>
		[Column(IsPrimaryKey = true, IsDbGenerated = true)]
		public int ResidentRoomsId { get; set; }
		/// <summary>
		/// Идентификатор жителя
		/// </summary>
		[Column]
		public int ResidentId { get; set; }
		/// <summary>
		/// Идентификатор комнаты
		/// </summary>
		[Column]
		public int RoomId { get; set; }
		/// <summary>
		/// Оплата наличными
		/// </summary>
		[Column]
		public bool CashPayment { get; set; }
		/// <summary>
		/// Постельное
		/// </summary>
		[Column]
		public bool BedClothes { get; set; }
		/// <summary>
		/// Дата заселения
		/// </summary>
		[Column]
		public DateTime SettlementDate { get; set; }
		/// <summary>
		/// Дата выселения
		/// </summary>
		[Column]
		public DateTime? DateOfEviction { get; set; }
		/// <summary>
		/// Ссылка на жителя
		/// </summary>
		private EntityRef<Resident> _Resident;
		/// <summary>
		/// Житель
		/// </summary>
		[Association(Storage = "_Resident", ThisKey = "ResidentId", OtherKey = "ResidentId")]
		public Resident Resident {
			get { return this._Resident.Entity; }
			set { this._Resident.Entity = value; }
		}
		/// <summary>
		/// Ссылка на комнату
		/// </summary>
		private EntityRef<Room> _Room;
		/// <summary>
		/// Комната
		/// </summary>
		[Association(Storage = "_Room", ThisKey = "RoomId", OtherKey = "RoomId")]
		public Room Room {
			get { return this._Room.Entity; }
			set { this._Room.Entity = value; }
		}
	}
	
	/// <summary>
	/// Вещь на прокат
	/// </summary>
	[Table(Name = "RentThings")]
	public class RentThing
	{
		/// <summary>
		/// Идентификатор вещи на прокат
		/// </summary>
		[Column(IsPrimaryKey = true, IsDbGenerated = true)]
		public int RentThingId { get; set; }
		/// <summary>
		/// Название
		/// </summary>
		[Column]
		public string Name { get; set; }
	}
	
	/// <summary>
	/// Проживание
	/// </summary>
	[Table(Name = "ResidentRoomsRentThings")]
	public class ResidentRoomsRentThing
	{
		/// <summary>
		/// Идентификатор проживания
		/// </summary>
		[Column(IsPrimaryKey = true, IsDbGenerated = true)]
		public int ResidentRoomsRentThingsId { get; set; }
		/// <summary>
		/// Идентификатор комнат жителя
		/// </summary>
		[Column(IsPrimaryKey = true)]
		public int ResidentRoomsId { get; set; }
		/// <summary>
		/// Идентификатор вещи на прокат
		/// </summary>
		[Column(IsPrimaryKey = true)]
		public int RentThingId { get; set; }
		/// <summary>
		/// Дата начала проката
		/// </summary>
		[Column(IsPrimaryKey = true)]
		public DateTime StartRentDate { get; set; }
		/// <summary>
		/// Дата конца проката
		/// </summary>
		[Column]
		public DateTime EndRentDate { get; set; }
		/// <summary>
		/// Ссылка на комнаты жителя
		/// </summary>
		private EntityRef<ResidentRooms> _ResidentRooms;
		/// <summary>
		/// Комнаты жителя
		/// </summary>
		[Association(Storage = "_ResidentRooms", ThisKey = "ResidentRoomsId", OtherKey = "ResidentRoomsId")]
		public ResidentRooms ResidentRooms {
			get { return this._ResidentRooms.Entity; }
			set { this._ResidentRooms.Entity = value; }
		}
		/// <summary>
		/// Ссылка на вещь для проката
		/// </summary>
		private EntityRef<RentThing> _RentThing;
		/// <summary>
		/// Вещь для проката
		/// </summary>
		[Association(Storage = "_RentThing", ThisKey = "RentThingId", OtherKey = "RentThingId")]
		public RentThing RentThing {
			get { return this._RentThing.Entity; }
			set { this._RentThing.Entity = value; }
		}
	}
	
	/// <summary>
	/// Запись действий пользователей
	/// </summary>
	[Table(Name = "HistoryRecords")]
	public class HistoryRecord
	{
		/// <summary>
		/// Идентификатор записи действия пользователя
		/// </summary>
		[Column(IsPrimaryKey = true, IsDbGenerated = true)]
		public int HistoryRecordId { get; set; }
		/// <summary>
		/// Имя пользователя
		/// </summary>
		[Column]
		public string UserName { get; set; }
		/// <summary>
		/// Действие
		/// </summary>
		[Column]
		public string Action { get; set; }
		/// <summary>
		/// Дата действия
		/// </summary>
		[Column]
		public DateTime DateOfAction { get; set; }
	}
	
	/// <summary>
	/// Элемент выпадающего списка
	/// </summary>
	public class ComboBoxItem
	{
		/// <summary>
		/// Отображаемое значение
		/// </summary>
		public string DisplayValue { get; set; }
		/// <summary>
		/// Скрытое значение
		/// </summary>
		public object HiddenValue { get; set; }
		/// <summary>
		/// Конструктор элемента выпадающего списка
		/// </summary>
		/// <param name="displayValue">Отображаемое значение</param>
		/// <param name="hiddenValue">Скрытое значение</param>
		public ComboBoxItem(string displayValue, object hiddenValue)
		{
			this.DisplayValue = displayValue;
			this.HiddenValue = hiddenValue;
		}
		
		public override string ToString()
		{
			return DisplayValue;
		}
	}
}

