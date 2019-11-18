using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dormitory
{
	/// <summary>
	/// Отвечает за запись действий пользователей
	/// </summary>
	public static class HistoryRecordsController
	{
		public static SqlConnection sqlConnection { get; set; }
		public static DataContext db { get; set; }
		public static string UserName { get; set; }

		static HistoryRecordsController()
		{
			SqlConnectionStringBuilder sConnB = new SqlConnectionStringBuilder()
			{
				DataSource = Properties.Settings.Default.userServerName,
				InitialCatalog = Properties.Settings.Default.userServerDatabase,
				IntegratedSecurity = true
			};
			sqlConnection = new SqlConnection(sConnB.ConnectionString);
			db = new DataContext(HistoryRecordsController.sqlConnection);
		}
		/// <summary>
		/// Изменяет строку подключения
		/// </summary>
		/// <param name="ConnectionString">Новая строка подключения</param>
		public static void ChangeSqlConnection(string ConnectionString)
		{
			HistoryRecordsController.sqlConnection.ConnectionString = ConnectionString;
			db = new DataContext(HistoryRecordsController.sqlConnection);
		}
		/// <summary>
		/// Изменяет имя текущего пользователя
		/// </summary>
		/// <param name="UserName">Имя пользователя</param>
		public static void ChangeUser(string UserName)
		{
			HistoryRecordsController.UserName = UserName;
		}
		/// <summary>
		/// Запись о попытках входа в систему
		/// </summary>
		/// <param name="isSuccessfull">Если true, то успешный вход, иначе ошибка</param>
		public static void WriteAboutSystemEnter(bool isSuccessfull)
		{
			try
			{
				string action = isSuccessfull ? "Успешный вход в систему" : "Ошибка входа в систему";

				HistoryRecord historyRecord = new HistoryRecord
				{
					UserName = HistoryRecordsController.UserName,
					Action = action,
					DateOfAction = DateTime.Now
				};
				db.GetTable<HistoryRecord>().InsertOnSubmit(historyRecord);
				db.SubmitChanges();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка ведения истории!\n" + ex.Message);
			}
		}
		/// <summary>
		/// Запись о выходе из системы
		/// </summary>
		public static void WriteAboutSystemExit()
		{
			try
			{
				HistoryRecord historyRecord = new HistoryRecord
				{
					UserName = HistoryRecordsController.UserName,
					Action = "Выход из системы",
					DateOfAction = DateTime.Now
				};
				db.GetTable<HistoryRecord>().InsertOnSubmit(historyRecord);
				db.SubmitChanges();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка ведения истории!\n" + ex.Message);
			}
		}
		/// <summary>
		/// Запись о заселении/выселении жителя
		/// </summary>
		/// <param name="residentRooms">Проживание жителя</param>
		/// <param name="isSettle">Если true, то заселение, иначе выселение</param>
		public static void WriteAboutSettlement(ResidentRooms residentRooms, bool isSettle)
		{
			string action = isSettle ? "Заселил жителя: " : "Выселил жителя: ";
			string residentFullName = residentRooms.Resident.Surname + " " +
				residentRooms.Resident.Name + " " + residentRooms.Resident.Patronymic;
			action += "\"" + residentFullName + "\". ";
			action += "Секция: " + residentRooms.Room.SectionNumber + ". Комната: " + residentRooms.Room.Number + ". ";
			action += isSettle ? "Дата заселения: " + residentRooms.SettlementDate + "."
				: "Дата выселения: " + residentRooms.DateOfEviction + ".";
			try
			{
				HistoryRecord historyRecord = new HistoryRecord
				{
					UserName = HistoryRecordsController.UserName,
					Action = action,
					DateOfAction = DateTime.Now
				};
				db.GetTable<HistoryRecord>().InsertOnSubmit(historyRecord);
				db.SubmitChanges();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка ведения истории!\n" + ex.Message);
			}
		}
		/// <summary>
		/// Запись о изменении жителя
		/// </summary>
		/// <param name="oldResident">Старая запись жителя</param>
		/// <param name="newResident">Новая запись жителя</param>
		public static void WriteAboutEditResident(Resident oldResident, Resident newResident)
		{
			try
			{
				string action = "Изменил жителя. ";
				string oldResidentFullName = oldResident.Surname + " " +
					oldResident.Name + " " + oldResident.Patronymic;
				string newResidentFullName = newResident.Surname + " " +
					newResident.Name + " " + newResident.Patronymic;
				if (oldResidentFullName != newResidentFullName)
				{
					action += oldResidentFullName + "->" + newResidentFullName + ". ";
				}
				else
				{
					action += oldResidentFullName + ". ";
				}

				if (oldResident.Organization.Name != newResident.Organization.Name)
				{
					action += "Организация: " + oldResident.Organization.Name + "->" + newResident.Organization.Name + ". ";
				}
				//else
				//{
				//	action += "Организация: " + oldResident.Organization.Name + ". ";
				//}

				if (oldResident.PhoneNumber != newResident.PhoneNumber)
				{
					action += "Телефонный номер: " + (string.IsNullOrEmpty(oldResident.PhoneNumber) ? "Нет" : oldResident.PhoneNumber) + "->" +
						(string.IsNullOrEmpty(newResident.PhoneNumber) ? "Нет" : newResident.PhoneNumber) + ". ";
				}
				//else
				//{
				//	action += "Телефонный номер: " + oldResident.PhoneNumber + ". ";
				//}

				if (oldResident.Birthday != newResident.Birthday)
				{

					string oldDate = "Нет", newDate = "Нет";

					if (oldResident.Birthday.HasValue)
					{
						oldDate = oldResident.Birthday.Value.Day.ToString() + "." +
							oldResident.Birthday.Value.Month.ToString() + "." +
							oldResident.Birthday.Value.Year.ToString();
					}
					if (newResident.Birthday.HasValue)
					{
						newDate = newResident.Birthday.Value.Day.ToString() + "." +
							newResident.Birthday.Value.Month.ToString() + "." +
							newResident.Birthday.Value.Year.ToString();
					}
					action += "День рождения: " + oldDate + "->" + newDate + ". ";
				}
				//else
				//{
				//	action += "День рождения: " + oldResident.Birthday.Value.Day.ToString() + "." +
				//		oldResident.Birthday.Value.Month.ToString() + "." + oldResident.Birthday.Value.Year.ToString() + ". ";
				//}

				if (oldResident.Note != newResident.Note)
				{
					action += "Пометка: " + (string.IsNullOrEmpty(oldResident.Note) ? "Нет" : oldResident.Note) + "->" +
						(string.IsNullOrEmpty(newResident.Note) ? "Нет" : newResident.Note) + ". ";
				}
				//else
				//{
				//	action += "Пометка: " + oldResident.Note + ". ";
				//}

				Passport oldPassport = oldResident.Passport;
				Passport newPassport = newResident.Passport;

				string oldPassportName = oldPassport.Series + oldPassport.Number;
				string newPassportName = newPassport.Series + newPassport.Number;

				if (oldPassportName != newPassportName)
				{
					action += "Паспортные данные: " + oldPassportName + "->" + newPassportName + ". ";
				}
				//else
				//{
				//	action += "Паспортные данные: " + oldPassportName + ". ";
				//}

				if (oldPassport.Registration != newPassport.Registration)
				{
					action += "Прописка: " + oldPassport.Registration + "->" + newPassport.Registration + ". ";
				}
				//else
				//{
				//	action += "Прописка: " + oldPassport.Registration + ". ";
				//}

				if (oldPassport.DateOfIssue != newPassport.DateOfIssue)
				{
					action += "Дата выдачи: " + oldPassport.DateOfIssue.Value.Day.ToString() + "." +
						oldPassport.DateOfIssue.Value.Month.ToString() + "." + oldPassport.DateOfIssue.Value.Year.ToString() + "->" +
						newPassport.DateOfIssue.Value.Day.ToString() + "." + newPassport.DateOfIssue.Value.Month.ToString() + "." +
						newPassport.DateOfIssue.Value.Year.ToString() + ". ";
				}
				//else
				//{
				//	action += "Дата выдачи: " + oldPassport.DateOfIssue.Value.Day.ToString() + "." +
				//		oldPassport.DateOfIssue.Value.Month.ToString() + "." + oldPassport.DateOfIssue.Value.Year.ToString() + ". ";
				//}

				if (oldPassport.Authority != newPassport.Authority)
				{
					action += "Орган выдачи: " + oldPassport.Authority + "->" + newPassport.Authority + ". ";
				}
				//else
				//{
				//	action += "Орган выдачи: " + oldPassport.Authority + ". ";
				//}

				HistoryRecord historyRecord = new HistoryRecord
				{
					UserName = HistoryRecordsController.UserName,
					Action = action,
					DateOfAction = DateTime.Now
				};
				db.GetTable<HistoryRecord>().InsertOnSubmit(historyRecord);
				db.SubmitChanges();

				ClearHistory(92);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка ведения истории!\n" + ex.Message);
			}
		}
		/// <summary>
		/// Запись о добавлении или удалении жителя
		/// </summary>
		/// <param name="resident">Житель</param>
		/// <param name="isAdd">Если true, то добавление, иначе удаление</param>
		public static void WriteAboutAddDeleteResident(Resident resident, bool isAdd)
		{
			try
			{
				string action = isAdd ? "Добавил жителя: " : "Удалил жителя: ";
				string residentFullName = resident.Surname + " " +
					resident.Name + " " + resident.Patronymic;
				action += "\"" + residentFullName + "\". ";
				action += "Организация " + resident.Organization.Name + ". ";
				action += "Телефонный номер: " + resident.PhoneNumber + " . День рождения: " +
					resident.Birthday.Value.Day.ToString() + "." + resident.Birthday.Value.Month.ToString() +
					"." + resident.Birthday.Value.Year.ToString() + ". ";
				action += "Пометка: " + resident.Note + ". ";
				Passport passport = resident.Passport;
				action += "Паспортные данные: " + passport.Series + passport.Number + ". ";
				action += "Прописка: " + passport.Registration + ". ";
				action += "Дата выдачи: " + passport.DateOfIssue.Value.Day.ToString() + "." +
					passport.DateOfIssue.Value.Month.ToString() + "." + passport.DateOfIssue.Value.Year.ToString() +
					" .Орган выдачи: " + passport.Authority;

				HistoryRecord historyRecord = new HistoryRecord
				{
					UserName = HistoryRecordsController.UserName,
					Action = action,
					DateOfAction = DateTime.Now
				};
				db.GetTable<HistoryRecord>().InsertOnSubmit(historyRecord);
				db.SubmitChanges();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка ведения истории!\n" + ex.Message);
			}
		}

		/// <summary>
		/// Запись в файл журнала ошибок
		/// </summary>
		public static void ErrorLog(Exception ex)
		{

		}

		/// <summary>
		/// Очищает историю, оставляя данные, введённые за последние days дней
		/// </summary>
		/// <param name="days">Сколько дней оставить</param>
		private static void ClearHistory(int days)
		{
			try
			{
				DateTime dateTime = DateTime.Now.AddDays(-days);
				string sqlClear = "DELETE FROM HistoryRecords " +
					$"WHERE [DateOfAction] <= '{dateTime}' ";

				SqlCommand cmd = new SqlCommand(sqlClear, HistoryRecordsController.sqlConnection);
				HistoryRecordsController.sqlConnection.Open();
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка удаления. \n" + ex.Message);
			}
			finally
			{
				HistoryRecordsController.sqlConnection.Close();
			}
		}

		/// <summary>
		/// Записывает в файл исключения
		/// </summary>
		/// <param name="exception">Исключение</param>
		public static void WriteExceptionToLogFile(Exception exception, string description = null)
		{
			string folderPath = Properties.Settings.Default.exceptionsLogFolderPath;
			string fileName = "\\DormitoryExceptionsLogFile.txt";
			string writePath = folderPath + fileName;
			try
			{
				using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
				{
					sw.WriteLine(DateTime.Now + ": " + description + " Подробнее: "+ exception.Message);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка записи в файл записи исключений. \n" + ex.Message);
			}
		}
	}
}
