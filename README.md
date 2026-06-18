# Volunteer Management API

RESTful Web API לניהול מתנדבים, בנויה על .NET 10 עם ארכיטקטורת שכבות (N-Tier) ו-SQLite כבסיס נתונים.

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
- `MyVolunteer` — מחלקת המתנדב (Id, FirstName, LastName) עם Data Annotations
- `VolunteerDto` — אובייקט קלט מהמשתמש (תומך בשם מלא או שם פרטי + משפחה)
- `IVolunteerRepository` — ממשק CRUD

### Volunteer.Repository
- `DataContext` — DbContext של EF Core עם Seed data
- `VolunteerRepository` — מימוש הממשק מול SQLite

### Volunteer.Service
- `VolunteerService` — לוגיקה עסקית:
  - פיצול שם מלא לשם פרטי ומשפחה
  - הוספת `!` לשם המשפחה בשליפת רשימה
  - שמירת שם המשפחה הישן בסוגריים בעדכון

### Volunteer.Api
- `VolunteersController` — endpoints עם קודי HTTP מתאימים
- `Program.cs` — הגדרת DI ו-EF Core

---

## Endpoints

| Method | URL | תיאור | Response |
|--------|-----|-------|----------|
| GET | `/api/volunteers` | שליפת כל המתנדבים | 200 OK |
| GET | `/api/volunteers/{id}` | שליפת מתנדב לפי ID | 200 OK / 404 Not Found |
| POST | `/api/volunteers` | הוספת מתנדב | 201 Created |
| PUT | `/api/volunteers/{id}` | עדכון שם משפחה | 204 No Content / 404 Not Found |
| DELETE | `/api/volunteers/{id}` | מחיקת מתנדב | 204 No Content / 404 Not Found |

---

## דוגמאות קלט

### POST — הוספת מתנדב עם שם מלא
```json
{
  "fullName": "Chani Cohen"
}
```

### POST — הוספת מתנדב עם שם פרטי ומשפחה
```json
{
  "firstName": "Chani",
  "lastName": "Cohen"
}
```

### PUT — עדכון שם משפחה
```json
"Levi"
```
התוצאה: `LastName = "Levi (Cohen)"`

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

בסיס הנתונים (`volunteers.db`) ייווצר אוטומטית בהפעלה הראשונה עם 2 מתנדבים לדוגמה.

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

הפרויקט בנוי בארכיטקטורת N-Tier עם הפרדה מלאה בין שכבות:

```
Controller → Service → Repository → Database
```

- **Dependency Injection** מנהל את החיבורים בין השכבות
- **DTO** מפריד בין מודל הנתונים לקלט מהמשתמש
- **Interface** מאפשר החלפת ה-Repository בעתיד (לדוגמה: SQL Server)
