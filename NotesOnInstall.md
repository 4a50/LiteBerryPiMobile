# Wire a Database in Xamarin

1. Install SQLite NuGet Package:

+ **sqlite-net-pcl**

1. Create a Database class in Services Folder
1. Create/Update interface for database access 'default = IDataStore'
1. Register the Database in 'App.Xaml.cs'
`DependencyService.Register<SQLiteDatabase>();
` <-- Or whatever your Database class is

1. In **SQLiteDatabase**, Create a *readonly* property for the database 
```readonly SQLiteAsyncConnection database;```

1. In **SQLiteDatabase**, Create a constructor with
the following entries:

```

string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Items.db3");
database = new SQLiteAsyncConnection(path);
database.CreateTableAsync<Item>().Wait();
```

1. Build Data Model in 'Models' folder
1. Implement all the methods in the Interface in the database class
1. Write the code blocks inside the newly implemented method.  
1. Bring in IDataStore dependency using a Data Model as a type
1. When making the invocations in the Code-behind or models, this is a way to perform an ASYNC task within a non-async method.

```
Task.Run(async () => await _vm.GetAllItems()).Wait();
```
