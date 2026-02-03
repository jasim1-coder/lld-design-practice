# 🛗 Elevator System – Low Level Design (LLD)

This project demonstrates a **Low Level Design (LLD)** implementation of a **multi-elevator system** using **C# (.NET)**.

The goal of this design is to model the **core behavior and responsibilities** of an elevator system in a way that is **clear, extensible, and interview-ready**, without over-engineering.

---

## 🎯 Objective

- Practice Low Level Design concepts
- Identify and model core entities
- Apply object-oriented principles and design patterns
- Simulate elevator behavior using a console application
- Build an interview-friendly design that is easy to explain

---

## 🧩 Core Features Implemented

- Multiple elevators in a single building
- Elevator request handling
- Step-by-step movement simulation
- Direction tracking (Up / Down / Idle)
- Door state management (Open / Closed)
- Strategy pattern for elevator selection
- Console-based simulation for visibility

---

## 🏗️ Core Entities

| Entity | Responsibility |
|------|----------------|
| `Elevator` | Represents a physical elevator and its state |
| `Request` | Represents a floor request |
| `Door` | Manages door state |
| `ElevatorController` | Orchestrates elevator movement and request handling |
| `IElevatorSelectionStrategy` | Defines elevator selection logic |

---

## 🧠 Design Decisions

### 1. Single Request Queue
Each elevator maintains a **single request queue** to keep the design simple and predictable.

Direction is derived dynamically based on the current target floor.

> Direction-based queues (Up/Down) are a valid enhancement but intentionally omitted to keep the design interview-friendly.

---

### 2. Strategy Pattern for Selection
Elevator assignment logic is abstracted using the **Strategy pattern**.

This allows:
- Easy replacement of selection logic
- Clean separation of responsibilities

The current implementation uses a **simple nearest-elevator strategy**.

---

### 3. Door Handling
- Doors open when the elevator reaches a target floor
- Doors close before the elevator starts moving again

This ensures basic safety rules without adding unnecessary complexity.

---

### 4. Console-Based Simulation
The system runs in discrete **time steps** to make elevator behavior observable and easy to debug.

Each step prints:
- Current floor
- Direction
- Door state

---

## ⚠️ Simplifications (Intentional)

This implementation focuses on **clarity over completeness**.

The following real-world concerns are intentionally **not implemented**, but can be added later:

- Fairness / starvation prevention
- Direction-based batching
- Load or weight sensors
- Emergency handling
- Real-time concurrency

These enhancements can be introduced by extending the **selection strategy** or controller logic.

---

## ▶️ How to Run

1. Open the solution in Visual Studio
2. Run the project
3. Observe elevator movement and state transitions in the console output

---

## 📌 Sample Output

