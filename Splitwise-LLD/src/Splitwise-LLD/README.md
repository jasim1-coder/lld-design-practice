# 💸 Splitwise – Low Level Design (LLD)

This project demonstrates a **Low Level Design (LLD)** implementation of a simplified **Splitwise-like expense sharing system** using **C# (.NET)**.

The goal is to model shared expense tracking in a clean, extensible, and interview-ready manner while keeping the design simple and focused on core business logic.

---

## 🎯 Objective

- Practice Low Level Design principles
- Model real-world shared expense behavior
- Apply the Strategy Pattern for split calculation
- Maintain accurate balance tracking between users
- Keep the system extensible and easy to reason about

---

## 🧩 Functional Requirements Implemented

- Add users
- Add expenses
- Support multiple split types:
  - Equal Split
  - Exact Split
  - Percentage Split
- Track who owes whom
- Print balances

---

## 🏗️ Core Design

### 🔹 Domain Entities

| Entity | Responsibility |
|--------|---------------|
| `User` | Represents a participant in the system |
| `Expense` | Represents a shared expense |
| `Split` | Represents a user's share in an expense |

---

### 🔹 Enums

| Enum | Values |
|------|--------|
| `SplitType` | `EQUAL`, `EXACT`, `PERCENTAGE` |

---

### 🔹 Strategy Pattern

Split calculation logic is separated using the **Strategy Pattern**:

| Strategy | Purpose |
|-----------|----------|
| `EqualSplitStrategy` | Divides amount equally |
| `ExactSplitStrategy` | Uses exact provided amounts |
| `PercentageSplitStrategy` | Calculates split based on percentages |

This makes the system:
- Extensible
- Clean
- Easy to maintain
- Interview-friendly

---

### 🔹 Balance Tracking

Balances are maintained using a nested dictionary:

