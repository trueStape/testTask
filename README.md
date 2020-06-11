![alt text](https://downloader.disk.yandex.ru/preview/3b2b9bfaccb53cc762c4c6b29b6ddb809a44fe6f45876bdd129013654d7375e2/5ee26761/k2IpFPeYQbNVSJ3LHJ6-DjHTx2-hejbTtzPqT-xcxcmmGoN7Qgs3YOgdVknCzA1Dad2-pRROcuT9FS3M5szzFg==?uid=0&filename=Example.png&disposition=inline&hash=&limit=0&content_type=image%2Fpng&tknv=v2&owner_uid=336768120&size=2048x2048)
# One of my test task
This repository contains an embedded web application that interacts with the MS SQL database
# Getting Started

### 1.Edit WebAPI config
Settings are located in appsettings.json.

* In file [appsettings.json](https://github.com/trueStape/testTask/blob/master/TestTaskForScience/appsettings.json) file, change the connection to the Server DataBase(variable "Server=").
```
For example : "TestTaskDb": "Server=DESKTOP-0000000;Database=TestTask;Trusted_Connection=True;MultipleActiveResultSets=true"
```

* In the wwwroot folder, modify the Site.js. file.You need to add the web path to the path variable.
```
For example : var path = "https://localhost:0000";
```
### 2.Code-first database migration
In Pacet Magager console generate database ```add-migration InitialMigration``` then ```update-database```

### 3.Run project

# Built With
* ASP.NET Core 3.0 WebAPI
* MS SQL

# Authors
* Yegor Oshlakov - [trueStape](https://github.com/trueStape)
