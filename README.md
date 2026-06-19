# Volunteer Management API

RESTful Web API לניהול מתנדבים, בנויה על .NET 10 עם ארכיטקטורת שכבות (N-Tier) ו-SQLite כבסיס נתונים.

---

## תרשים סכמטי — קשרים בין טבלאות

```
┌─────────────────────┐          ┌──────────────────────────┐
│        Role         │          │       MyVolunteer         │
├─────────────────────┤          ├──────────────────────────┤
│ Id (PK)             │1        *│ Id (PK)                   │
│ Name                │──────────│ FirstName                 │
└─────────────────────┘          │ LastName                  │
                                 │ RoleId (FK → Role.Id)     │
                                 └──────────────────────────┘

  Role ──< MyVolunteer   (One-to-Many)
  תפקיד אחד יכול להיות למספר מתנדבים
  מתנדב שייך לתפקיד אחד (או ללא תפקיד)
```

---

## מבנה הפרויקט

```
project_NET/
├── Volunteer.Entities/       # מודלים וממשקים
├── Volunteer.Repository/     # גישה לנתונים (EF Core + SQLite)
├── Volunteer.Service/        # לוגיקה עסקית
└── Volunteer.Api/            # Web API Controllers
```

### Volunteer.Entities
- `MyVolunteer` — מחלקת המתנדב (Id, FirstName, LastName, RoleId) עם Data Annotations
- `Role` — מחלקת התפקיד (Id, Name)
- `VolunteerDto` — אובייקט קלט מהמשתמש (תומך בשם מלא או שם פרטי + משפחה + RoleId)
- `IVolunteerRepository` — ממשק CRUD למתנדבים
- `IRoleRepository` — ממשק CRUD לתפקידים

### Volunteer.Repository
- `DataContext` — DbContext של EF Core עם Seed data
- `VolunteerRepository` — מימוש הממשק מול SQLite
- `RoleRepository` — מימוש ממשק תפקידים מול SQLite

### Volunteer.Service
- `VolunteerService` — לוגיקה עסקית:
  - פיצול שם מלא לשם פרטי ומשפחה
  - הוספת `!` לשם המשפחה בשליפת רשימה
  - שמירת שם המשפחה הישן בסוגריים בעדכון
- `RoleService` — ניהול תפקידים

### Volunteer.Api
- `VolunteersController` — endpoints מתנדבים עם קודי HTTP מתאימים
- `RolesController` — endpoints תפקידים עם קודי HTTP מתאימים
- `Program.cs` — הגדרת DI ו-EF Core

---

## Endpoints

### מתנדבים

| Method | URL | תיאור | Response |
|--------|-----|-------|----------|
| GET | `/api/volunteers` | שליפת כל המתנדבים | 200 OK |
| GET | `/api/volunteers/{id}` | שליפת מתנדב לפי ID | 200 OK / 404 Not Found |
| POST | `/api/volunteers` | הוספת מתנדב | 201 Created |
| PUT | `/api/volunteers/{id}` | עדכון שם משפחה | 204 No Content / 404 Not Found |
| DELETE | `/api/volunteers/{id}` | מחיקת מתנדב | 204 No Content / 404 Not Found |

### תפקידים

| Method | URL | תיאור | Response |
|--------|-----|-------|----------|
| GET | `/api/roles` | שליפת כל התפקידים | 200 OK |
| GET | `/api/roles/{id}` | שליפת תפקיד לפי ID | 200 OK / 404 Not Found |
| POST | `/api/roles` | הוספת תפקיד | 201 Created |
| DELETE | `/api/roles/{id}` | מחיקת תפקיד | 204 No Content / 404 Not Found |

---

## דוגמאות קלט

### POST /api/volunteers — עם שם מלא ותפקיד
```json
{
  "fullName": "Chani Cohen",
  "roleId": 1
}
```

### POST /api/volunteers — עם שם פרטי ומשפחה
```json
{
  "firstName": "Chani",
  "lastName": "Cohen",
  "roleId": 2
}
```

### PUT /api/volunteers/{id} — עדכון שם משפחה
```json
"Levi"
```
התוצאה: `LastName = "Levi (Cohen)"`

### POST /api/roles — הוספת תפקיד
```json
"Logistics"
```

---

## התקנה והפעלה

### דרישות מוקדמות
- [.NET 10 SDK](https://dotnet.microsoft.com/download)

### הפעלה

```bash
cd Volunteer.Api
dotnet restore
dotnet run
```

בסיס הנתונים (`volunteers.db`) ייווצר אוטומטית בהפעלה הראשונה עם נתוני Seed:
- 3 תפקידים: Driver, Medic, Coordinator
- 2 מתנדבים לדוגמה

ה-API יהיה זמין בכתובת: `https://localhost:7xxx/api/volunteers`

---

## טכנולוגיות

| טכנולוגיה | שימוש |
|-----------|-------|
| .NET 10 | פלטפורמה |
| ASP.NET Core | Web API |
| Entity Framework Core 9 | ORM |
| SQLite | בסיס נתונים |
| Data Annotations | ולידציה |

---

## ארכיטקטורה

```
Controller → Service → Repository → Database
```

- **Dependency Injection** מנהל את החיבורים בין השכבות
- **DTO** מפריד בין מודל הנתונים לקלט מהמשתמש
- **Interface** מאפשר החלפת ה-Repository בעתיד (לדוגמה: SQL Server)
