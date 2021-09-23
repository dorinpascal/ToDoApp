using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Lesson4.Models;

namespace Lesson4.Data
{
    public class ToDoJSONData : ITodoData
    {
        private string todoFile = "todos.json";
        private IList<ToDo> ToDos;

        public ToDoJSONData()
        {
            if (!File.Exists(todoFile))
            {
                Seed();
                WriteTodosToFile();
            }
            else
            {
                string content = File.ReadAllText(todoFile);
                ToDos = JsonSerializer.Deserialize<List<ToDo>>(content);
            }
        }


        public IList<ToDo> GetTodos()
        {
            List<ToDo> temp = new List<ToDo>(ToDos);
            return temp;
        }

        public void AddTodo(ToDo toDo)
        {
            int max = ToDos.Max(toDo => toDo.TodoId);
            toDo.TodoId = (++max);
            ToDos.Add(toDo);
            WriteTodosToFile();
        }

        private void WriteTodosToFile()
        {
            string todoJson = JsonSerializer.Serialize(ToDos);
            File.WriteAllText(todoFile, todoJson);
        }

        private void Seed()
        {
            ToDo[] ts =
            {
                new ToDo {UserId = 1, TodoId = 1, Title = "Do dishes", IsCompleted = false},
                new ToDo {UserId = 1, TodoId = 2, Title = "Walk the dog", IsCompleted = false},
                new ToDo{UserId = 2, TodoId = 3, Title = "Do DNP homework", IsCompleted = true},
                new ToDo {UserId = 3, TodoId = 4, Title = "Eat breakfast", IsCompleted = false},
                new ToDo{UserId = 4, TodoId = 5, Title = "Mow lawn", IsCompleted = true},
            };
            ToDos = ts.ToList();
        }

        public void RemoveTodo(int todoId)
        {
            //instead of if statemnt
            ToDo toRemove = ToDos.First(t => t.TodoId == todoId);
            ToDos.Remove(toRemove);
            WriteTodosToFile();
        }
    }
}