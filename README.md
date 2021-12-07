# Témalaboratórium

## Elindítás

A kód futtatásához vagy Visual Studio vagy Visial Studio Code-ra lesz szükség, amit [itt](https://visualstudio.microsoft.com/free-developer-offers/) lehet letölteni.

A fórráskód letöltése és kicsomagolása után nyissuk meg a `TodoApi.sln` fájlt, amit utánna a `Shift`+`5` billentyűkombinációval futtathatunk.
Futtatás után a [http://localhost:5000/api/columns](http://localhost:5000/api/columns) oldal nyílik meg.

## Az API ról

Az API elsősorban a [TodoApp](https://github.com/nudleee/react-todo-app) backend-eként szolgál. 

### Végpontok

`GET /api/columns` visszatér az Oszlopokkal és a benne található Teendőkkel

`GET /api/columns/{id}` visszatér az Oszlop tartalmával 

`GET /api/todos` visszatér az összes Teendővel

`GET /api/todos/{id}` visszatér egy Teendővel

`POST /api/todos` létrehoz egy új Teendőt

`PUT /api/todos/{id}` módosít egy Teendőt

`DELETE /api/columns/{id}` eltávolít egy Teendőt

### Szerkezet

Az API a követi a Repository Pattern-t ezért a benne található Modellek (Column, Todo) mindegyikéhez tartozik egy Resository.
Ezeken a Repository-kon keresztül tudjuk elérni az adataot Controllerek-ből. 
Az API Controller-eihez  tartozó Unit teszteket a [TodoApiTest](https://github.com/nudleee/todo-api/tree/master/TodoApiTest)-nél találjuk.