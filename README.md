# Dota2Service — Subscription Module  

Микросервис для управления подписками пользователей в системе Dota2Service.  
Позволяет создавать, проверять и управлять сроками подписки через REST API.  
## 🔥 Возможности  

- Создание подписки с указанием срока действия  
- Проверка активности подписки по токену  
- Автоматическая блокировка доступа после истечения срока  
- Интеграция с UserService для проверки прав администратора
- ## 🚀 Быстрый старт  

1. **Клонируйте репозиторий**  
   ```bash
   git clone https://github.com/yourname/Dota2Service.git
   cd Dota2Service/SubscriptionService
   dotnet run
---

#### **4. API Endpoints**  
Документация основных методов (можно в таблице).  

```markdown
## 📡 API Endpoints  

| Метод | Путь | Описание |  
|-------|------|----------|  
| `GET` | `/api/subscription` | Список всех подписок |  
| `POST` | `/api/subscription/create` | Создать подписку (требуется `AdminToken`) |  
| `POST` | `/api/subscription/check` | Проверить активность подписки |

## 📌 Примеры  

**Создание подписки**  
```bash
curl -X POST 'https://localhost:7295/api/subscription/create' \
  -H 'Content-Type: application/json' \
  -d '{
    "AdminToken": "your_admin_token",
    "IdUser": 1,
    "DaysSubscription": 30
  }'


---

#### **6. Технологии**  
Стек проекта.  

```markdown
## ⚙️ Технологии  

- ASP.NET Core 7  
- Entity Framework Core  
- SQL Server / PostgreSQL  
- Swagger для документации API  
