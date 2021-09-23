using System.Collections;
using System.Collections.Generic;
using WebApplication;


namespace WebApplication
{
    public interface ITodoData
    {
        IList<ToDo> GetTodos();
        void AddTodo(ToDo toDo);
        void RemoveTodo(int todoId);
        void Update(ToDo todo);
        ToDo Get(int id);
    }
}