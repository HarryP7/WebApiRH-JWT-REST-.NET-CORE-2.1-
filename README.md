## WebApi .NET CORE 2.1
## + JWT	[![Build Status](https://secure.travis-ci.org/auth0/node-jsonwebtoken.svg?branch=master)](http://travis-ci.org/auth0/node-jsonwebtoken) [![Dependency Status](https://david-dm.org/auth0/node-jsonwebtoken.svg)](https://david-dm.org/auth0/node-jsonwebtoken)
## + REST   [![Build status](https://ci.appveyor.com/api/projects/status/5vdwwducje0miayf?svg=true)](https://ci.appveyor.com/project/hallem/restsharp) [![Join the chat at https://gitter.im/RestSharp/RestSharp](https://badges.gitter.im/RestSharp/RestSharp.svg)](https://gitter.im/RestSharp/RestSharp?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
Взаимодействие жильцов в многоэтажном доме по вопросам ЖКХ

### Клиент React Native TypeScript
Находится здесь -> [ClientReactNativeTS](https://github.com/HarryP7/mobileClient_React-Native-TS-Project_RuleYourHome.git)

-----------------------
### Инструкция по развертыванию сервера .NET Core 2.1:
1.  Если не установлено IDE **Visual Studio Community 2015-2019**: 
    * скачиваем – https://visualstudio.microsoft.com/ru/vs/?rr=https%3A%2F%2Fwww.google.com%2F;
2.  При установке выбираем опции: 
    * ASP.NET и разработка веб-приложений;
    * Хранение и обработка данных;
    * Кроссплатформенная разработка .NET Core.
3. Клонируйте проект по ссылке в нужную папку, к примеру: 
```bash
$ md WebApiRH
$ cd WebApiRH
$ git clone https://github.com/HarryP7/WebApiRH-JWT-REST_.NET-CORE_2.1.git
```

-----------------------
### Создание нового проекта .NET CORE 2.1
1. Создаем проект в **Visual Studio 2019**: 
    * Выбираем - **Веб-Приложение ASP.NET Core**;
    * Выбираем **шаблон API** + **ASP.NET Core 2.1** + Добавить систему управления версиями; 
    * Нажимаем кнопку - "**Создать**".
2. Добавляем папку Models -> добавляем в нее все наши модели и AppDbContext;
3. Устанавливаем контекст в классе Startup.cs;
4. Затем для создания базы данных из наших моделей, перейдем к окну Package Manager Console и выполним в нем последовательно две команды:
```bash
PM> Add-Migration Initial 
PM> Update-Database
```
5. Может потребоваться выполнить еще 2 команды, если произойдет ошибка перед 1й командой:
```bash
PM> Install-Package Microsoft.EntityFrameworkCore -Version 2.1.11
PM> Install-Package Microsoft.EntityFrameworkCore.Tools -Version 2.1.11
```