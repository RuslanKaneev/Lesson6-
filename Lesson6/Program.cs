using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
/* Написать консольное приложение Task Manager, которое выводит на экран запущенные процессы и позволяет завершить указанный процесс. 
 * Предусмотреть возможность завершения процессов с помощью указания его ID или имени процесса. 
 * В качестве примера можно использовать консольные утилиты Windows tasklist и taskkill.*/

namespace Lesson6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Process[] process = Process.GetProcesses();
            //метод, чтобы завершить процесс
            void TaskManagerKill(Process taskManagerKill)
            {
                taskManagerKill.Kill();
                Console.WriteLine($"Процесс {taskManagerKill} завершен");
            }

            //выводим список процессов
            for (int i = 0; i < process.Length; i++)
            {
                Process taskManager = process[i];
                Console.WriteLine($"{taskManager.ProcessName}\t\t {taskManager.Id}\t\t {taskManager.SessionId}\t\t {taskManager.SessionId}\t\t  {taskManager.PagedMemorySize64}");

            }

            Console.WriteLine("Введите имя процесса, которое хотите завершить или введите 0, чтобы ввести ID процесса");
            string taskKill = Console.ReadLine();
            //завершаем процесс, когда пользователь ввел его id
            if (taskKill == "0")
            {
                Console.WriteLine("Введите  ID процесса, которое хотите завершить");
                int taskKillId = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < process.Length; i++)
                {
                    Process taskManagerKill = process[i];
                    if (taskManagerKill.Id == taskKillId)
                    {
                        TaskManagerKill(process[i]);
                    }
                }
            }
            //завершаем процесс, когда пользователь ввел его название
            else
            {
                for (int i = 0; i < process.Length; i++)
                {
                    Process taskManagerKill = process[i];

                    if (taskManagerKill.ProcessName == taskKill)

                    {
                        TaskManagerKill(process[i]);
                    }

                }
            }
            Console.ReadKey();
        }
        

    }
 }


