# 🅿️ Parking Lot – Low Level Design (LLD)

This project demonstrates the **Low Level Design (LLD)** of a **Parking Lot System** implemented in **C# (.NET)**.  
The focus is on **clean object-oriented design**, **SOLID principles**, and **interview-level clarity**, not production complexity.

---

## 📌 Problem Statement

Design a parking lot system that:
- Supports multiple floors
- Handles different vehicle types
- Allows vehicles to park and unpark
- Generates parking tickets
- Calculates parking fees

The design should be **extensible**, **readable**, and **easy to explain in interviews**.

---

## ✅ Functional Requirements

- Park a vehicle
- Unpark a vehicle
- Generate a parking ticket
- Calculate parking fees based on duration
- Support multiple vehicle types (Bike, Car, Truck)
- Support multiple parking floors

---

## ❌ Non-Functional Requirements (Assumptions)

- Single parking lot
- Medium scale
- No concurrency handling
- In-memory data only (no database)
- No UI or Web API

---

## 🧠 Core Entities

- **Vehicle** – Represents a vehicle entering the parking lot
- **ParkingSpot** – Represents a parking space
- **ParkingFloor** – Groups parking spots
- **Ticket** – Tracks parking duration and status
- **ParkingLot** – Central coordinator
- **PaymentService** – Calculates parking fees

---

## 🧩 Design Patterns Used

- **Singleton Pattern**
  - Ensures only one instance of `ParkingLot`

- **Strategy Pattern**
  - Allows flexible parking spot selection logic

---

## 🧱 SOLID Principles Applied

- **Single Responsibility Principle (SRP)**  
  Each class has a single responsibility

- **Open/Closed Principle (OCP)**  
  New parking strategies or vehicle types can be added without modifying core logic

- **Dependency Inversion Principle (DIP)**  
  Parking behavior depends on abstractions, not concrete implementations

---

## 📁 Project Structure

parking-lot/
│
├── README.md
├── src/
│ └── ParkingLot/
│ ├── Program.cs
│ │
│ ├── Domain/
│ │ ├── Enums/
│ │ ├── Entities/
│ │ └── Interfaces/
│ │
│ ├── Strategies/
│ └── Services/