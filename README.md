# --ThemeParkSystem--

# 🎢 Copington Adventure Theme Park Ticketing System

A robust, console-based ticketing and point-of-sale (POS) machine built in C# (.NET). This application manages visitor ticket tiers (Adult, Child, Senior), ride wristbands, lead booker validation, parking selections, and cash/note transactions with automated change calculation.

Originally conceptualized in Python and refactored into strongly-typed C#, this project emphasizes defensive programming, procedural subroutines, and continuous daily transaction processing limits.

---

## ✨ Features & Architecture

* **Modular Subroutines:** The system breaks operations down into single-responsibility functions (e.g., `AdultTotal()`, `Wristband()`, `LeadSurname()`, `NoteInput()`).
* **Robust Error Handling:** Uses `try-catch` blocks and `int.TryParse` logic to prevent crashes from invalid text inputs or accidental blank submissions.
* **Smart Input Validation:** 
  * Ensures ticket quantities are zero or positive integers.
  * Validates lead booker surnames to ensure they contain no blank spaces or symbols, automatically formatting them with proper capitalization (e.g., `smith` $\rightarrow$ `Smith`).
* **Automated POS Cash Register:** Accepts physical notes (£10 and £20), tracks running totals, calculates remaining balances dynamically, and dispenses correct change.
* **Daily Capacity Control:** Features a stateful transaction loop capped at 500 customers to simulate real-world hardware kiosk limitations.

---

## 💻 Code Structure Overview

```csharp
Program.cs
│
├── WelcomeMessage()         // Displays branding banner
├── AdultTotal()             // Handles adult ticket calculations & validation
├── ChildTotal()             // Handles child ticket calculations & validation
├── SeniorTotal()            // Handles senior ticket calculations & validation
├── Entrance()               // Aggregates total ticket costs
├── Wristband()              // Handles ride wristband additions
├── LeadSurname()            // Validates and formats customer surname
├── Parking()                // Handles free parking preference selection
├── NoteInput()              // POS machine cash intake & change dispenser
├── RunBookingSystem()       // Pipelines a single customer checkout transaction
└── Main()                   // Manages daily capacity loop (up to 500 customers)
