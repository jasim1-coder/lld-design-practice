# 🎬 BookMyShow – Low Level Design (LLD)

This project demonstrates the **Low Level Design (LLD)** of a simplified **BookMyShow-style movie ticket booking system**, implemented in **C# (.NET)**.

The focus is on **clean object-oriented design**, **SOLID principles**, and **interview-level clarity**, not production complexity.

---

## 📌 Problem Statement

Design a system that allows users to:
- View movies
- View shows for a movie
- View available seats
- Book movie tickets
- Make payment and confirm booking

---

## ✅ Functional Requirements

- List available movies
- Display shows for a movie
- Display available seats for a show
- Book seats for a user
- Confirm booking after payment

---

## ❌ Assumptions / Non-Functional Requirements

- Single city
- No seat lock timeout
- No concurrency handling
- In-memory data only
- No database or web API

---

## 🧠 Core Entities

- **User**
- **Movie**
- **Show**
- **Seat**
- **Booking**
- **Payment**

---

## 🧩 Design Principles & Patterns

- **Single Responsibility Principle (SRP)**
- **Separation of Concerns**
- Business logic handled via services
- Entities kept simple and predictable

---

## 📁 Project Structure

