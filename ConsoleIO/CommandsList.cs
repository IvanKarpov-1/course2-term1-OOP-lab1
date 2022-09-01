﻿using BLL;
using IOStream;

namespace PL
{
    public class CommandsList
    {
        private readonly DataPresenter _dataPresenter;
        private readonly DataManipulator _dataManipulator;
        private readonly CreateEntity _createEntity;

        public CommandsList(DataPresenter dataPresenter,  DataManipulator dataManipulator, CreateEntity createEntity)
        {
            _dataPresenter = dataPresenter;
            _dataManipulator = dataManipulator;
            _createEntity = createEntity;
        }

        public void Help()
        {
            const string text = "Доступні команди:\n" +
                                "/help - показати всі доступні команди.\n" +
                                "/show - показати список всіх збережених осіб.\n" +
                                "/addstudent - додати студента.\n" +
                                "/addmcdonaldsworker (/addmdworker) - додавти працівника макдональдсу.\n" +
                                "/addmanager - додати менеджера.\n" +
                                "/special - знаходження кількості студентів 3-го курсу, що проживають в Україні. Вивід їх даних.\n" +
                                "/search - пошук людини (ей) за іменем та прізвищем.\n" +
                                "/clear - очистити консоль.\n" +
                                "/save - зберегти дані.\n" +
                                "/restore - відновити дані.\n" +
                                "/changepath - змінити шлях збереження даних.\n";

            ConsoleMenu.WriteItem(text);
        }

        public void Show()
        {
            ConsoleMenu.WriteItem(_dataPresenter.GetFullInfo());
        }

        public void AddStudent()
        {
            var firstName = InputData.Name("ім'я");
            var lastName = InputData.Name("прізвище");
            var course = InputData.Course();
            var studentId = InputData.StudentId();
            var gpa = InputData.Gpa();
            var country = InputData.Country();
            var numberOfScoreBook = InputData.NumberOfScoreBook();

            object[] parameters = { course, studentId, gpa, country, numberOfScoreBook, firstName, lastName };

            _createEntity.Create(EntitiesType.Student, parameters);

            ConsoleMenu.WriteItem("Студента додано.");
        }

        public void AddMcDonaldsWorker()
        {
            var firstName = InputData.Name("ім'я");
            var lastName = InputData.Name("прізвище");
            var salary = InputData.Salary();
            var diploma = InputData.Diploma();

            object[] parameters = { diploma, salary, firstName, lastName };

            _createEntity.Create(EntitiesType.McDonaldsWorker, parameters);

            ConsoleMenu.WriteItem("Працівника макдональдсу додано.");
        }

        public void AddManager()
        {
            var firstName = InputData.Name("ім'я");
            var lastName = InputData.Name("прізвище");
            var salary = InputData.Salary();
            var countOfSubordinates = InputData.CountOfSubordinates();

            object[] parameters = { countOfSubordinates, salary, firstName, lastName };

            _createEntity.Create(EntitiesType.Manager, parameters);

            ConsoleMenu.WriteItem("Менеджера додано.");
        }

        public void Special()
        {
            ConsoleMenu.WriteItem(SpecialSearcher.Start());
        }

        public void Search()
        {
            var firstName = ConsoleMenu.ReadItem("Введіть ім'я шуканої людини:");
            var lastName = ConsoleMenu.ReadItem("Введіть прізвище шуканої людини:");

            var result = _dataPresenter.GetConcretePersonInfo(firstName, lastName);

            if (result == string.Empty)
            {
                ConsoleMenu.WriteItem("\nЗбігів не знайдено.\n");
                return;
            }

            ConsoleMenu.WriteItem("\nРезультат пошуку:");
            ConsoleMenu.WriteItem(_dataPresenter.GetConcretePersonInfo(firstName, lastName) + "\n");
        }

        public void Clear()
        {
            ConsoleMenu.Clear();
        }

        public void Save()
        {
            _dataManipulator.Save();
            ConsoleMenu.WriteItem("Дані збережено.\n");
        }

        public void Restore()
        {
            _dataManipulator.Restore();
            ConsoleMenu.WriteItem("Дані відновлено.\n");
        }

        public void ChangePath()
        {
            var path = InputData.Path();
            var fileName = InputData.FileName();
            var fileExtension = InputData.FileExtension();

            var fullPath = path + fileName + fileExtension;

            PathContainer.SetPath(fullPath);
        }
    }
}