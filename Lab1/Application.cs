using BLL;
using DAL;
using PL;
using System.Text.RegularExpressions;

namespace Lab1
{
    internal class Application
    {
        private readonly CommandsList _commandsList;

        public Application()
        {
            var dataStorage = new DataStorage();
            var dataPresenter = new DataPresenter(dataStorage);
            var dataManipulator = new DataManipulator(dataStorage);
            var createEntity = new CreateEntity(dataStorage);
            _commandsList = new CommandsList(dataPresenter, dataManipulator, createEntity);
        }

        public void Start()
        {
            string input;
            _commandsList.Help();
            do
            {
                input = ConsoleMenu.ReadItem().ToLower();
                input = Regex.Replace(input, @"\s+", "");

                switch (input)
                {
                    case "/help":
                        _commandsList.Help();
                        break;
                    case "/show":
                        _commandsList.Show();
                        break;
                    case "/addstudent":
                        _commandsList.AddStudent();
                        break;
                    case "/addmcdonaldsworker":
                    case "/addmdworker":
                        _commandsList.AddMcDonaldsWorker();
                        break;
                    case "/addmanager":
                        _commandsList.AddManager();
                        break;
                    case "/special":
                        _commandsList.Special();
                        break;
                    case "/search":
                        _commandsList.Search();
                        break;
                    case "/clear":
                        _commandsList.Clear();
                        break;
                    case "/save":
                        _commandsList.Save();
                        break;
                    case "/restore":
                        _commandsList.Restore();
                        break;
                    case "/changepath":
                        _commandsList.ChangePath();
                        break;
                    case "/end":
                        break;
                    default:
                        ConsoleMenu.WriteItem("Команда введена невірно! Спробуйте ще раз");
                        break;
                }
            } while (input != "/end");

            ConsoleMenu.WriteItem("Програма завершила роботу. Натисніть любу клавішу для виходу.");
        }
    }
}