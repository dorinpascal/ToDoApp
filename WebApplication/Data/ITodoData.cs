using System.Collections;
using System.Collections.Generic;
using Lesson4.Models;

namespace Lesson4.Data
{
    public interface ITodoData
    {
        IList<ToDo> GetTodos();
        void AddTodo(ToDo toDo);
        void RemoveTodo(int todoId);
    }
}