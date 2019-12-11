## WebApiRH

###Инструкция по развертыванию сервера .NET Core 2.1:
1.  Если не установлено IDE Visual Studio Community 2015-2019: 
    * скачиваем – https://visualstudio.microsoft.com/ru/vs/?rr=https%3A%2F%2Fwww.google.com%2F;
2.  При установке выбираем опции: 
    * ASP.NET и разработка веб-приложений;
    * Хранение и обработка данных;
    * Кроссплатформенная разработка .NET Core.
3. Клонируйте проект по ссылке в нужную папку: 
```bash
md WebApiRH
cd WebApiRH
$ git clone https://github.com/HarryP7/WebApiRH-JWT-REST_.NET-CORE_2.1.git
```

-----------------------
### Создание нового проекта .NET CORE 2.1
3. Создаем проект в Visual Studio 2019: 
    * Выбираем - Веб-Приложение ASP.NET Core;
    * Выбираем шаблон API –  ASP.NET Core 2.1 + Добавить систему управления версиями; 
    * Нажимаем кнопку - "Создать".
4. Добавляем папку Models -> добавляем в нее все наши модели и AppDbContext;
5. Устанавливаем контекст в классе Startup.cs;
6. Затем для создания базы данных из наших моделей, перейдем к окну Package Manager Console и выполним в нем последовательно две команды:
```bash
Add-Migration Initial 
Update-Database
```
Может потребоваться выполнить еще 2 команды, если произойдет ошибка перед 1й командой:
```bash
PM> Install-Package Microsoft.EntityFrameworkCore -Version 2.1.11
PM> Install-Package Microsoft.EntityFrameworkCore.Tools -Version 2.1.11
```