using BLL;
using IOStream;

namespace PL
{
    public class CommandsList
    {
        private readonly DataPresenter _dataPresenter;
        private readonly DataManipulator _dataManipulator;
        private readonly EntityCreator _entityCreator;

        public CommandsList(DataPresenter dataPresenter, DataManipulator dataManipulator, EntityCreator entityCreator)
        {
            _dataPresenter = dataPresenter;
            _dataManipulator = dataManipulator;
            _entityCreator = entityCreator;
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
            var data = _dataPresenter.GetFullInfo();

            if (data == string.Empty)
            {
                ConsoleMenu.WriteItem("Список порожній.\n");
                return;
            }

            ConsoleMenu.WriteItem(data);
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

            _entityCreator.Create(EntitiesType.Student, parameters);

            ConsoleMenu.WriteItem("Студента додано.");
        }

        public void AddMcDonaldsWorker()
        {
            var firstName = InputData.Name("ім'я");
            var lastName = InputData.Name("прізвище");
            var salary = InputData.Salary();
            var diploma = InputData.Diploma();

            object[] parameters = { diploma, salary, firstName, lastName };

            _entityCreator.Create(EntitiesType.McDonaldsWorker, parameters);

            ConsoleMenu.WriteItem("Працівника макдональдсу додано.");
        }

        public void AddManager()
        {
            var firstName = InputData.Name("ім'я");
            var lastName = InputData.Name("прізвище");
            var salary = InputData.Salary();
            var countOfSubordinates = InputData.CountOfSubordinates();

            object[] parameters = { countOfSubordinates, salary, firstName, lastName };

            _entityCreator.Create(EntitiesType.Manager, parameters);

            ConsoleMenu.WriteItem("Менеджера додано.");
        }

        public void Special()
        {
            var matches = string.Empty;
            var count = 0;

            SpecialSearcher.Start(ref matches, ref count);

            if (matches == string.Empty)
            {
                ConsoleMenu.WriteItem("\nЗбігів не знайдено.\n");
                return;
            }

            ConsoleMenu.WriteItem($"\nКількість студентів 3-го курсу, які проживають в Україні - {count}.");
            ConsoleMenu.WriteItem("Їх дані:\n");
            ConsoleMenu.WriteItem(matches);
        }

        public void Search()
        {
            var firstName = ConsoleMenu.ReadItem("Введіть ім'я шуканої людини:");
            var lastName = ConsoleMenu.ReadItem("Введіть прізвище шуканої людини:");

            var matches = _dataPresenter.GetConcretePersonInfo(firstName, lastName);

            if (matches == string.Empty)
            {
                ConsoleMenu.WriteItem("\nЗбігів не знайдено.\n");
                return;
            }

            ConsoleMenu.WriteItem("\nРезультат пошуку:");
            ConsoleMenu.WriteItem(matches);
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

            ConsoleMenu.WriteItem("Шлях до файлу успішно змінено.\n");
        }
    }
}