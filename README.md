# 🏙️ CivicAlerts

## Overview
**CivicAlerts** is an event-driven system for reporting and tracking city incidents — such as broken streetlights, road damage, pollution, or traffic issues.  
Citizens and city departments can report incidents, while other services (notifications, analytics, dashboards) react asynchronously through a message bus (**NATS**).  

This project demonstrates **CQRS**, **event-driven communication**, and **modular microservice architecture** using **C#**, **.NET**, and **NATS**.

---

## ⚙️ Functional Requirements

### 1. Report Incident
- Users can report new incidents via REST API:  
  `POST /api/incidents`
- Each incident includes:
  - `Title` *(string, required)*
  - `Description` *(string, optional)*
  - `Category` *(e.g., Lighting, Road Damage, Pollution)*
  - `Location` *(coordinates or address)*
  - `Reporter` *(user name or ID)*
- Once created, the service publishes an **`IncidentReported`** event to **NATS**.

---

### 2. Change Incident Status
- City staff can update an incident’s status (`Reported → In Progress → Resolved`).  
- Endpoint:  
  `PUT /api/incidents/{id}/status`
- Each update triggers an **`IncidentStatusChanged`** event published to **NATS**.

---

### 3. Notifications
- **NotificationService** subscribes to the following events:
  - `IncidentReported`
  - `IncidentStatusChanged`
- It can:
  - Log or simulate sending notifications (email/SMS)  
  - Track notification delivery  
- Communication is **event-driven only** — no direct REST calls between services.

---

### 4. Query (Read Model)
- **QueryService** subscribes to events and maintains a read-optimized database.
- Exposes REST endpoints:
  - `GET /api/incidents`
  - `GET /api/incidents/{id}`
- The read model may include:
  - Number of incidents per category  
  - Average response/resolution time  
  - Historical trends  

---

### 5. Reliability and Integration
- **NATS** ensures reliable, asynchronous communication between services.  
- If a service is temporarily unavailable, messages are re-delivered when it reconnects (JetStream can be added later).  
- Each service is independent and horizontally scalable.

---

### 6. Testability
- **IncidentService** is developed using a **test-first** approach (unit and integration tests).  
- **QueryService** and **NotificationService** are tested using simulated NATS events.  
- Frontend is optional and can be added later.

---

## 🧩 Non-Functional Requirements
- API documentation via **Swagger / OpenAPI**  
- Logging using **Serilog** or built-in .NET logging  
- **Docker** is used for running NATS and other dependencies  
- Architecture pattern: **CQRS + Event-Driven Microservices**  
- Code structure supports future extensions (analytics, dashboards, etc.)

---

## 🧱 Technologies
- **.NET 8 / ASP.NET Core**
- **C#**
- **NATS Messaging**
- **MSSQL (local)**
- **xUnit / NUnit** (for testing)
- **Docker** (for NATS)
- **Swagger** (for API documentation)

---

## 📦 Services Overview

| Service | Type | Description |
|----------|------|-------------|
| **IncidentService** | REST API | Handles incident creation and status updates, publishes events |
| **NotificationService** | Worker | Subscribes to events and sends notifications |
| **QueryService** | REST API | Builds and exposes a read model from events |
| **Common** | Library | Shared models, DTOs, and event definitions |

---

## 🚀 Next Steps
1. Initialize the solution and all projects (`IncidentService`, `NotificationService`, `QueryService`, `Common`)  
2. Configure **NATS** (via Docker)  
3. Implement event publishing/subscribing  
4. Add **unit tests** for each service  
5. Extend functionality gradually (analytics, dashboards, etc.)

---

🧠 **Goal:**  
Build a realistic, modular system that demonstrates **clean architecture, event-driven design, and testable service boundaries**, while serving a socially useful purpose.
