# Polyglots 🌍🎙️

**Polyglots** is a real-time voice and text chat platform designed for language exchange.

The core purpose of this application is to showcase how **SignalR** can be pushed to its strengths by managing not only textual synchronization but also live binary audio streaming and broadcasting across low-latency language rooms.

---

## 🚀 Key Features & Architectural Focus

* **Real-time Voice Rooms:** Low-latency audio streaming using Web Audio API to capture microphone inputs, chunking the data, and broadcasting raw binary packets via SignalR Hubs to all connected peers in a room.
* **Instant Text Chat:** Simultaneous chat synchronization using strongly-typed SignalR hubs.
* **Clean Architecture & DDD:** Strict decoupling of layers (`Domain`, `Application`, `Infrastructure.Persistence`, and `Presentation.WebApp`) to ensure maintainability, testability, and a clear separation of business logic from infrastructure details.
* **Modern .NET Ecosystem:** Powered by **.NET 10** and leveraging the latest ecosystem improvements.

---

## 🛠️ Technical Stack & Infrastructure

### Backend & Real-time
* **Language/Runtime:** C# | .NET 10
* **Real-time Transport:** ASP.NET Core SignalR (WebSockets fallback to Long Polling)
* **Database:** PostgreSQL 18.4

### DevOps & Portability (Production-Grade Deployment)
Even as a personal portfolio project, **Polyglots** bypasses manual server configuration by implementing an automated, infrastructure-as-code deployment pipeline:

* **Containerization:** Multi-stage `Dockerfile` optimized for caching NuGet restores, significantly speeding up build times.
* **CI/CD Pipeline:** Fully automated workflow via **GitHub Actions** that triggers on every push to `main`. It builds, tests, and pushes the production image to **GitHub Packages (GHCR)**.
* **Automated CD via SSH:** The pipeline connects securely to a Linux VPS via SSH keys, triggers a zero-downtime container pull, and updates the application layout dynamically.
* **Environment Isolation:** * **Local Development:** Hybrid layout running native .NET 10 against an isolated PostgreSQL container for maximum debugging speed.
* **Production (VPS):** Fully dockerized multi-container network isolation using `docker-compose.production.yaml`.

---

## 📐 Architecture Overview

The solution adheres to **Domain-Driven Design (DDD)** concepts:

1. **Polyglots.Domain:** Enterprise wide business rules, entities, and core value objects. Zero external dependencies.
2. **Polyglots.Application:** Application-specific business rules, DTOs, CQRS handlers, and interface definitions.
3. **Polyglots.Infrastructure.Persistence:** Implementation of data access, Entity Framework Core configurations, and PostgreSQL repositories.
4. **Polyglots.Presentation.WebApp:** Blazor/ASP.NET Core Web App hosting the SignalR Hubs, UI components, and the web entry point.

---
