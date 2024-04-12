using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesExample
{
    internal class Program
    {
        // GenerateTestToDoTaskList - процедурка генерации списка дел для тестов
        static List<ToDoTask> GenerateTestToDoTaskList()
        {
            return new List<ToDoTask>
        {
            new ToDoTask("Помыть посуду", "Необходимо помыть посуду", 5, false),
            new ToDoTask("Сделать домашку", "Сделать всю домашку по программированию", 3, true),
            new ToDoTask("Погулять с собакой", "Прогулка на свежем воздухе", 4, false),
            new ToDoTask("Позвонить другу", "Позвонить другу или родственнику", 2, false),
            new ToDoTask("Сделать покупки", "Список продуктов на сегодняшний ужин", 3, true),
            new ToDoTask("Посмотреть фильм", "Выбрать фильм и насладиться просмотром", 4, false),
            new ToDoTask("Написать код фильтрующий по слову 'сделать'", "Написать новую программу", 5, true),
            new ToDoTask("Подготовить ужин", "Приготовить что-то вкусное", 4, false),
            new ToDoTask("Прочитать книгу", "Прочитать новую книгу", 3, true),
            new ToDoTask("Сделать зарядку", "Провести зарядку для здоровья", 2, false),
            new ToDoTask("Почистить дом", "Убраться по всему дому", 4, false),
            new ToDoTask("Запланировать путешествие", "Выбрать место для отдыха", 5, false),
            new ToDoTask("Проверить почту", "Проверить электронную почту", 2, true),
            new ToDoTask("Составить список задач", "Написать список дел на неделю", 3, false),
            new ToDoTask("Полить цветы", "Полить все комнатные растения", 1, false)
        };
        }

        static void WriteLineIEnumerable<T>(IEnumerable<T> values)
        {
            foreach (T item in values)
            {
                Console.WriteLine(item);
            }
        }

        // ЗАДАЧА: получить задачи на исполнение, которые создержат в заголовке строку "Сделать"

        // выполнение в императивном подходе
        static void ImperativeCase()
        {
            Console.WriteLine("ImperativeCase\n===================");
            List<ToDoTask> toDoTasks = GenerateTestToDoTaskList();
            //
            List<ToDoTask> filteredToDoTasks = new List<ToDoTask>();
            foreach (ToDoTask task in toDoTasks.OrderBy(task => task.Description.Length))
            {
                if (task.Title.ToLower().Contains("сделать"))
                {
                    filteredToDoTasks.Add(task.Clone() as ToDoTask);
                }
            }
            WriteLineIEnumerable(filteredToDoTasks);
        }

        // выполнение в декларативном подходе с использованием SQL-подобного синтаксиса LINQ
        static void DeclarativeSQLSameCase()
        {
            Console.WriteLine("\n\nDeclarativeSQLSameCase\n===================");
            List<ToDoTask> toDoTasks = GenerateTestToDoTaskList();
            //
            IEnumerable<ToDoTask> query = from task in toDoTasks
                                          where task.Title.ToLower().Contains("сделать")
                                          orderby task.Description.Length
                                          select task.Clone() as ToDoTask;
            WriteLineIEnumerable(query);
        }

        // выполнение в декларативном подходе с использованием методов LINQ
        static void DeclarativeMethodsCase()
        {
            Console.WriteLine("\n\nDeclarativeMethodsCase\n===================");
            List<ToDoTask> toDoTasks = GenerateTestToDoTaskList();
            //
            IEnumerable<ToDoTask> query = toDoTasks
                .OrderBy(task => task.Description.Length)
                .Where(task => task.Title.ToLower().Contains("сделать"))
                .Select(task => task.Clone() as ToDoTask);
            WriteLineIEnumerable(query);
        }

        static void PriorityGreatTwo()
        {
            Console.WriteLine("\n\nDeclarativeMethodsCase\n===================");
            List<ToDoTask> ToDoTask = GenerateTestToDoTaskList();

            IEnumerable<string> query = ToDoTask
                .OrderBy(task => task.Description.Length)
                .Where(task => !task.IsCompleted && task.Priority > 2)
                .Select(task => task.Description);
            WriteLineIEnumerable(query);
            Console.WriteLine();
        }


        static void Main(string[] args)
        {
            ImperativeCase();
            DeclarativeSQLSameCase();
            DeclarativeMethodsCase();
            PriorityGreatTwo();
        }
    }
}